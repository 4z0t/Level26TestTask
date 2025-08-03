using UnityEngine;

public class TurretRotator : MonoBehaviour
{
    [SerializeField]
    [Range(-90, 90)]
    private float _maxPitchDegrees = 70;
    [SerializeField]
    [Range(-90, 90)]
    private float _minPitchDegrees = -70;

    [SerializeField] private GameObject _turret;

    public (float Pitch, float Yaw) SetRotation(float pitch, float yaw)
    {
        pitch = Mathf.Clamp(pitch, _minPitchDegrees, _maxPitchDegrees);
        _turret.transform.rotation = Quaternion.Euler(pitch, yaw, 0);
        return (pitch, yaw);
    }

}
