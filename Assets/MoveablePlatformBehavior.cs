using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatformBehavior : MonoBehaviour
{
    [SerializeField]
    PlatformMovementTypes _types;

    [SerializeField]
    float _horizontalSpeed = 5;
    [SerializeField]
    float _verticalSpeed = 3;
    [SerializeField]
    float _horizontalDistance = 5;
    [SerializeField]
    float _verticalDistance = 3;

    Vector2 _startPosition;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        switch(_types)
        {
            case PlatformMovementTypes.HORIZONTAL:
                transform.position = new Vector2(Mathf.PingPong(_horizontalSpeed * Time.time, _horizontalDistance) + _startPosition.x,
                                         transform.position.y);
                break;
            case PlatformMovementTypes.VERTICAL:
                transform.position = new Vector2(transform.position.x,
                                                 Mathf.PingPong(_verticalSpeed * Time.time, _verticalDistance) + _startPosition.y);
                break;
            case PlatformMovementTypes.DIAGONAL_RIGHT:
                transform.position = new Vector2(Mathf.PingPong(_horizontalSpeed * Time.time, _horizontalDistance) + _startPosition.x,
                                                  Mathf.PingPong(_verticalSpeed * Time.time, _verticalDistance) + _startPosition.y);
                break;
            case PlatformMovementTypes.DIAGONAL_LEFT:
                transform.position = new Vector2(_startPosition.x - Mathf.PingPong(_horizontalSpeed * Time.time, _horizontalDistance) ,
                                                 Mathf.PingPong(_verticalSpeed * Time.time, _verticalDistance) + _startPosition.y);
                break;
            case PlatformMovementTypes.CUSTOM:
                break;
        }
    }
}
