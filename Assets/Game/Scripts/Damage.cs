using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float _damageValue;


    public float DamageValue
    {
        get => _damageValue;
        private set { _damageValue = value; }
    }

    public virtual void ApplyDamage(GameObject gameObject)
    {
        Health health = gameObject.GetComponent<Health>();
        if (health)
        {
            health.TakeDamage(this);
        }
    }
}
