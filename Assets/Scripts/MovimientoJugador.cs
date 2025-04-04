using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 direction;

    Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        rigidBody.velocity = direction * speed;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
}
