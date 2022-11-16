using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Set dynamic ")]
    [SerializeField] private int _shieldLevel = 4;
    [SerializeField] private float _shieldRotationSpeed = 0.1f;

    private Material _shieldMaterial;
    private const float SHIELD_OFFSET = 0.2f;
    

    private void SetShieldLevel(int shieldLevel)
    {
        _shieldMaterial.mainTextureOffset = new Vector2(SHIELD_OFFSET * shieldLevel, 0);
    }

    private void ShieldRotation(float shieldRotationSpeed)
    {
        var rotationZ = -(shieldRotationSpeed * Time.time * 360) % 360;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    private void Update()
    {
        ShieldRotation(_shieldRotationSpeed);
    }
    private void FixedUpdate()
    {
        SetShieldLevel(_shieldLevel);
    }

    private void Start()
    {
        _shieldMaterial = GetComponent<Renderer>().material;
    }
}
