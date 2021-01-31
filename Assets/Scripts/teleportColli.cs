using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportColli : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "telewall")
        {
            gameObject.transform.position = new Vector2(400,10000);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
