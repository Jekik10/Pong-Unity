using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetP1Script : MonoBehaviour
{
    public LogicScript l;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        l.addScoreP2();
    }
}
