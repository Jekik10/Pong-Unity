using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class P1Script : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementVelocity;
    void Start()
    {
        movementVelocity = 1;
    }
    
    public void OnMovement(InputValue value)
    {
        float val = value.Get<float>();
        //Debug.Log(val);
        if (val == 1 && rb.position.y < 4.1)
            rb.MovePosition(rb.position + (Vector2.up * new Vector2(1, movementVelocity)));
        if (val == -1 && rb.position.y > -4.1)
            rb.MovePosition(rb.position + (Vector2.down * new Vector2(1, movementVelocity)));
    }
}
