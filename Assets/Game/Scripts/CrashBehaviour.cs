using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Splines;

[RequireComponent (typeof(Health))]
public class CrashBehaviour : MonoBehaviour
{
    [SerializeField] private float _forwardSpeedMult;
    [SerializeField] private float _decayTime;
    [SerializeField] private AudioResource _explosionSound;
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private bool _explodeOnGround;
    [SerializeField] private float _explosionForce;

    private bool _exploded = false;

    private void OnEnable()
    {
        GetComponent<Health>().OnDeath += OnDeath;
    }

    private void OnDeath(object sender, Health health)
    {
        SplineAnimate splineAnimate = GetComponent<SplineAnimate>();
        if (splineAnimate)
        {
            splineAnimate.enabled = false;
            float speed = splineAnimate.MaxSpeed;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddForce(transform.rotation * Vector3.forward * rb.mass * _forwardSpeedMult * speed, ForceMode.Impulse);
            }
        }
    }

    protected virtual void PlayImpactSound()
    {
        var audio = GetComponent<AudioSource>();
        if (!audio)
            return;

        if (!_explosionSound)
        {
            audio.enabled = false;
            return;
        }

        audio.loop = false;
        audio.resource = _explosionSound;
        audio.Play();
    }

    protected virtual void PlayImpactEffect()
    {
        if (!_explosionEffect)
            return;

        var effect = Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        Destroy(effect, _decayTime);
    }


    protected virtual void OnImpactGround(Collision collision)
    {
        foreach (Animator  anim in GetComponents<Animator>())
        {
            anim.enabled = false;
        }

        foreach (Transform childTransform in transform)
        {
            childTransform.AddComponent<Rigidbody>();
            childTransform.AddComponent<BoxCollider>();
            var collider = childTransform.GetComponent<BoxCollider>();
            collider.enabled = true;
            Destroy(childTransform.gameObject, _decayTime);
        }

        transform.DetachChildren();
        var rb = GetComponent<Rigidbody>();
        rb.AddExplosionForce(_explosionForce, transform.position, 10, 0.5f, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_exploded)
            return;

        if (collision.collider.CompareTag("Terrain"))
        {
            _exploded = true;
            if(_explodeOnGround)
            {
                OnImpactGround(collision);
            }

            PlayImpactEffect();
            PlayImpactSound();
            Destroy(gameObject, _decayTime);
        }
    }

    private void OnDisable()
    {
        GetComponent<Health>().OnDeath -= OnDeath;
    }

}
