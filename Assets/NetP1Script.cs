using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetP1Script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LogicScript.addScore(2);
    }
}
