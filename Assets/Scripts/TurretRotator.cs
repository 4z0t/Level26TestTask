using UnityEngine;

public class TurretRotator : MonoBehaviour
{
    [SerializeField] private float _maxPitchDegrees = 70;
    [SerializeField] private float _minPitchDegrees = -70;

    [SerializeField] private GameObject _turret;

    public void SetRotation(float yaw, float pitch)
    {
        pitch = Mathf.Clamp(pitch, _minPitchDegrees, _maxPitchDegrees);
        _turret.transform.rotation =  Quaternion.Euler(pitch, yaw, 0);
    }

}
