using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{

    [SerializeField] private Canvas _prototype;
    [SerializeField] private Vector3 _offset;

    private Canvas _canvas;

    void Start()
    {
        _canvas = Instantiate(_prototype, transform);
        _canvas.transform.localPosition += _offset;
    }

    private void OnEnable()
    {
        GetComponent<Health>().OnHealthChanged += OnHeathChanged;
    }

    private void UpdateHealthBar(Health health)
    {
        var t = _canvas.transform.Find("ForeGround");
        if (!t)
        {
            Debug.LogWarning("There is no ForeGround in HealthBar Canvas prototype");
            return;
        }

        Image img = t.GetComponent<Image>();
        img.fillAmount = health.CurrentHealth / health.MaxHealth;
    }

    private void OnHeathChanged(object sender, Health health) => UpdateHealthBar(health);

    private void Update()
    {
       _canvas.transform.rotation = Quaternion.LookRotation(_canvas.transform.position  - Camera.main.transform.position);
    }

    private void OnDisable()
    {
        GetComponent<Health>().OnHealthChanged -= OnHeathChanged;
    }

}
