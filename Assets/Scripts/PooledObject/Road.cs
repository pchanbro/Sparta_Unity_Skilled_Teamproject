using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Road : PoolAble
{


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ResetWall"))
        {
            ReleaseObject();
        }
    }
}
