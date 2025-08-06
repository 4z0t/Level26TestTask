using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

[RequireComponent (typeof(Health))]
public class CrashBehaviour : MonoBehaviour
{
    [SerializeField] private float _forwardSpeedMult;
    [SerializeField] private float _decayTime;
    [SerializeField] private float _explosionForce;

    private bool _exploded = false;

    private void OnEnable()
    {
        GetComponent<Health>().OnDeath += OnDeath;
    }

    private void OnDeath(object sender, Health health)
    {
        Debug.Log("dead");
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

    protected virtual void OnImpactGround(Collision collision)
    {
        if (_exploded)
            return;
        _exploded = true;

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

        GetComponent<Rigidbody>()
            .AddExplosionForce(_explosionForce, transform.position, 10, 0.5f, ForceMode.Impulse);

        Destroy(gameObject, _decayTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Terrain"))
        {
            OnImpactGround(collision);
        }
    }

    private void OnDisable()
    {
        GetComponent<Health>().OnDeath -= OnDeath;
    }

}
