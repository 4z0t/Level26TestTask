using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(TurretRotator))]
[RequireComponent (typeof(TurretShooter))]
public class Input : MonoBehaviour
{
    [SerializeField] private TurretRotator _rotator;
    [SerializeField] private TurretShooter _shooter;

    [Header("���������")]
    public float sensitivity = 0.5f; // ����������������

    private float yaw;               // �������������� ����
    private float pitch;             // ������������ ����
    private Vector2 lookInput;       // ������� ������ �� Input System


    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
        if (lookInput.magnitude > 0.1f) // ���������� �����-��������
        {
            // ������ ����
            yaw += lookInput.x * sensitivity;
            pitch -= lookInput.y * sensitivity; // "-" ��� �������� ���������

            (pitch, yaw) = _rotator.SetRotation(pitch, yaw);
        }
    }

    public void OnShoot(InputValue value)
    {
        _shooter.IsShooting = value.isPressed;
    }

    //float progress = 0f;

    //// Update is called once per frame
    //void Update()
    //{
    //    progress = (Time.deltaTime + progress) % 1;
    //    _rotator.SetRotation(Mathf.Lerp(-45, 45, Mathf.Sin(progress * Mathf.PI)), Mathf.Lerp(0, 360, progress));
    //}
}
