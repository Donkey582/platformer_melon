using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemcollect : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Playerscript>().collect(value);
            Destroy(gameObject);
        }
    }
}
