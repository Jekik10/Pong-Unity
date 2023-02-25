using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallScript : MonoBehaviour
{
    static public Rigidbody2D rb;
    static float _increment;
    static Vector2 _direction;
    System.Random r = new System.Random();
    public static Vector2 actualPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float _generated = (float)r.NextDouble() * 2f - 1f;

        //This check is intended to prevent the ball from spawning with an angle that is too small
        while (_generated < 0.05 && _generated > -0.05)
            _generated = (float)r.NextDouble() * 2f - 1f;
        _direction = new Vector2(-1, _generated); 
        _increment = 1;
    }
    void Update()
    {
        rb.velocity = _direction * _increment * 3;
        actualPosition = rb.position;
    }

    //methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //bounce on cursor
        _direction.x = _direction.x * -1;
        incrementVelocity();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //bounce on walls
        _direction.y = _direction.y * -1;
    }
    public static void stop()
    {
        _direction = new Vector2(0, 0);
    }
    public void incrementVelocity()
    {
        _increment += 0.5f;
    }

    //Getters and Setters
    public static void setIncrement(float f)
    {
        _increment = f;
    }
    public static float getIncrement()
    {
        return _increment;
    }
    public static void setPosition(Vector2 position)
    {
        rb.position = position;
    }
    public static void setDirection(Vector2 direction)
    {
        _direction = direction;
    }
}