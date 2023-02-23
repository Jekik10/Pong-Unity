using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Script : MonoBehaviour
{
    public ScriptPalla palla;
    public Rigidbody2D rb;
    public float movementVelocity = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //movimento leftArrow = alto, rightArrow = basso
        //utilizzo GetKey per avere la possibilità di tenere premuto

        //UTILIZZA IL NUOVO SISTEMA DI INPUT-----------------------------------------------
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            //questo if permette di mantenere l'elemento fermo se entrambe le freccie sono premute
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow) && rb.position.y < 4.1)
            {
                rb.MovePosition(rb.position + (Vector2.up * new Vector2(1, movementVelocity)));
            }
            if (Input.GetKey(KeyCode.DownArrow) && rb.position.y > -4.1)
            {
                rb.MovePosition(rb.position - (Vector2.up * new Vector2(1, movementVelocity)));
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        palla = collision.GetComponent<ScriptPalla>();
        palla.incrementVelocity();
        palla.rb.velocity = new Vector2(1, Random.Range(-1.0f, 1.0f)) * 3 * palla.increment;
    }
}
