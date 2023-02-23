using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPalla : MonoBehaviour
{
    public Rigidbody2D rb;
    public float increment;
    int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        increment = 1;
        rb.velocity = Vector2.left * 3 * increment;
        rb.velocity = new Vector2(-1, Random.Range(-1.0f, 1.0f)) * 3 * increment;

    }



    // Update is called once per frame
    void Update()
    {

        
    }
    //DA QUI DEVI CAVARE TUTTA LA LOGICA DI RESTART E PIAZZARLA IN LOGIC--------------------------
    public void restart()
    {
        points += 1;
        if (increment > 2)
        {
            increment = increment / 2;
        }
        rb.position = new Vector2(0, 0);
        if(points%2 == 0)
        {
            rb.velocity = new Vector2(-1, Random.Range(-1.0f, 1.0f)) * 3 * increment;
        }
        else
        {
            rb.velocity = new Vector2(1, Random.Range(-1.0f, 1.0f)) * 3 * increment;
        }


    }
    public void stop()
    {
        rb.position = new Vector2(0, 0);
        rb.velocity = new Vector2(0, 0);
    }

    //CAVA TUTTI I BOUNCE E METTILI DI BASE IN LOGIC---------------------------------
    public void incrementVelocity()
    {
        increment += 0.2f;
    }
    public Vector2 getCoordinates()
    {
        return rb.position;
    }
}
