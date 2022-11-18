using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzas : MonoBehaviour
{
    Rigidbody2D rg;
    public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        rg= GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rg.bodyType = RigidbodyType2D.Dynamic;
            rg.gravityScale = Random.Range(2f,8f);
            Destroy(this.gameObject,1.5f);
        }
    }
}
