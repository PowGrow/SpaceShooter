using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private const float SHIP_OFFSET_VERTICAL = 1f;
    private const float SHIP_OFFSET_HORIZONTAL = 0.5f;

    [SerializeField] private float _speed = 1f;

    private Vector2 _borders;
    private Rigidbody2D _rigidBody;
    private Vector2 _forceDirection;

    private IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        _borders = GameObjectList.GetObjects("Border").First().GetComponent<Border>().GetBorderds();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        var random = Random.Range(0.0f, 1.0f);
        var direction = -1f;
        if (random > 0.5f)
            direction = 1f;
        this.transform.position = new Vector2(direction * (_borders.x + SHIP_OFFSET_HORIZONTAL),
                                              Random.Range (- 1 * _borders.y + SHIP_OFFSET_VERTICAL, _borders.y - SHIP_OFFSET_VERTICAL));
        _forceDirection = new Vector2(-1 * direction, 0);
        StartCoroutine(Destroy(2f));
    }

    private void FixedUpdate()
    {
        _rigidBody.AddForce(_forceDirection * _speed);
    }
}
