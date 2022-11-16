using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float SHIP_OFFSET_VERTICAL = 1f;
    private const float SHIP_OFFSET_HORIZONTAL = 0.5f;

    [SerializeField] private float _speed = 1f;

    private Vector2 _borders;
    private Rigidbody2D _rigidBody;
    private Vector2 _forceDirection;

    private void Awake()
    {
        _borders = GameObjectList.GetObjects("Border").First().GetComponent<Border>().GetBorderds();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        this.transform.position = new Vector2(Random.Range(-1 * _borders.x + SHIP_OFFSET_HORIZONTAL, _borders.x - SHIP_OFFSET_HORIZONTAL),
                                              _borders.y + SHIP_OFFSET_VERTICAL);
        _forceDirection = new Vector2(0, -1);
    }

    private void FixedUpdate()
    {
        _rigidBody.AddForce(_forceDirection * _speed);
        if (this.transform.position.y < -1 * (_borders.y + SHIP_OFFSET_VERTICAL))
            Destroy(this.gameObject);
    }
}
