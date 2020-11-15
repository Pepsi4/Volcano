using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.003f;

    [SerializeField]
    private bool _moveToRight = true;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (_moveToRight)
        {
            _speed = -_speed;
        }
    }

    void Update()
    {
            rb2d.MovePosition(new Vector2(rb2d.position.x - _speed, rb2d.position.y));
        
    }
}
