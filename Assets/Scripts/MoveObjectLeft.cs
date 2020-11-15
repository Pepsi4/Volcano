using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectLeft : MonoBehaviour
{
    private float Speed = 0.003f;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Debug.Log(Speed);
        rb2d.MovePosition(new Vector2(rb2d.position.x - Speed, rb2d.position.y));
    }
}
