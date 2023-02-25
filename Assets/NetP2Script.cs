using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetP2Script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LogicScript.addScore(1);
    }
}
