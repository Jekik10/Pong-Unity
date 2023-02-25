using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Script : MonoBehaviour
{
    public BallScript palla;
    public LogicScript logic;
    public Rigidbody2D rb;
    public float movementVelocity;
    int frames = 0;
    void Start()
    {
        movementVelocity = 1;
    }

    void Update()
    {
        if (frames == 3)
        {
            Vector2 coordinates = BallScript.actualPosition;
            if (coordinates.y > rb.position.y + 0.8 && rb.position.y < 4.1)
            {
                rb.MovePosition(rb.position + (Vector2.up * new Vector2(1, movementVelocity)));
            }
            if (coordinates.y < rb.position.y - 0.8 && rb.position.y > -4.1)
            {
                rb.MovePosition(rb.position - (Vector2.up * new Vector2(1, movementVelocity)));
            }
            frames = 0;
        }
        else
            frames += 1;
    }
}

//manual second player
//if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
//{
//    //questo if permette di mantenere l'elemento fermo se entrambe le freccie sono premute
//}
//else
//{
//    if (Input.GetKey(KeyCode.D) && rb.position.y < 4.1)
//    {
//        rb.MovePosition(rb.position + (Vector2.up * new Vector2(1, movementVelocity)));
//    }
//    if (Input.GetKey(KeyCode.A) && rb.position.y > -4.1)
//    {
//        rb.MovePosition(rb.position - (Vector2.up * new Vector2(1, movementVelocity)));
//    }
//}
