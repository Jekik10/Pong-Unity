using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Script : MonoBehaviour
{
    public ScriptPalla palla;
    public LogicScript logic;
    public Rigidbody2D rb;
    public float movementVelocity;
    int frames = 0;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();
        movementVelocity = 1;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (frames == 3)
        {
            Vector2 coordinates = logic.getCoordinates();
            if (coordinates.y > rb.position.y + 1 && rb.position.y < 4.1)
            {
                rb.MovePosition(rb.position + (Vector2.up * new Vector2(1, movementVelocity)));
            }
            if (coordinates.y < rb.position.y - 1 && rb.position.y > -4.1)
            {
                rb.MovePosition(rb.position - (Vector2.up * new Vector2(1, movementVelocity)));
            }
            frames = 0;
        }
        else
            frames += 1;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        palla = collision.GetComponent<ScriptPalla>();
        palla.incrementVelocity();
        palla.rb.velocity = new Vector2(-1, Random.Range(-1.0f, 1.0f)) * 3 * palla.increment;

    }
}
