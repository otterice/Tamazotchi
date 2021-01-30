using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meat_crunch : MonoBehaviour
{
    public GameObject meat_splatter;
    private void OnTriggerEnter2D(Collider2D other) {

        Debug.Log("meat eat");

        if (other.gameObject.name == "Petr hitbox") {
            GameObject m = Instantiate(meat_splatter) as GameObject;
            m.transform.position = transform.position;

            Destroy(gameObject);
        }

    }
}
