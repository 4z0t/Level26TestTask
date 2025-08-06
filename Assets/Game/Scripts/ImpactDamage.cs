using UnityEngine;

public class ImpactDamage : Damage
{
    private void OnCollisionEnter(Collision collision) => ApplyDamage(collision.collider.gameObject);

}
