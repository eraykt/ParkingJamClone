using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public bool _canMove;

    public enum Direction
    {
        Further,
        Side
    }

    public Direction way;

    private float _wayDirection;

    private void Update()
    {
        if (_canMove)
        {
            if (way == Direction.Further)
            {
                transform.position += new Vector3(_wayDirection * Time.deltaTime * 5, 0f, 0f);
            }

            else if (way == Direction.Side)
            {
                transform.position += new Vector3(0f, 0f, _wayDirection * Time.deltaTime * 5);
            }
        }
    }

    public void DriveCar(float wayDirection)
    {
        _wayDirection = wayDirection;

        _canMove = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _canMove = false;

        if (way == Direction.Further)
        {
            transform.position += new Vector3(-_wayDirection * 0.5f, 0f, 0f);
            _wayDirection = 0;
        }

        else if (way == Direction.Side)
        {
            transform.position += new Vector3(0f, 0f, -_wayDirection * 0.5f);
            _wayDirection = 0;
        }
    }
}