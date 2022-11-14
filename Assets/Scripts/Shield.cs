using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Set dynamic ")]
    [SerializeField] private int _shieldLevel = 4;

    private Material _shieldMaterial;

    private const float SHIELD_OFFSET = 0.2f;

    private void SetShieldLevel(int shieldLevel)
    {
        _shieldMaterial.mainTextureOffset = new Vector2(SHIELD_OFFSET * shieldLevel, 0);
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
