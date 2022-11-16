using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Border : MonoBehaviour
{
    private const float SHIP_BORDER_OFFSET_VERTICAL = 1f;
    private const float SHIP_BORDER_OFFSET_HORIZONTAL = 0.5f;

    private float _borderHorizontal, _borderVertical;
    private GameObject _player;
    

    private float BorderPositionCorrection(float playerPosition, float border, float borderOffset)
    {
        float newPlayerPosition = playerPosition;
        if (Math.Abs(playerPosition) > border - borderOffset)
        {
            int direction = 1;
            if (playerPosition < 0)
                direction = -1;
             newPlayerPosition = direction * (border - borderOffset);
        }
        return newPlayerPosition;
    }

    private void Awake()
    {
        _borderVertical = Camera.main.orthographicSize;
        _borderHorizontal = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
        _player = GameObjectList.GetObjects("Player").First();
    }

    private void FixedUpdate()
    {
        List<GameObject> objects = GameObjectList.GetObjects();

    }

    private void LateUpdate()
    {
        _player.transform.position = new Vector2(BorderPositionCorrection(_player.transform.position.x, _borderHorizontal, SHIP_BORDER_OFFSET_HORIZONTAL),
                                                 BorderPositionCorrection(_player.transform.position.y, _borderVertical, SHIP_BORDER_OFFSET_VERTICAL));
    }
}
