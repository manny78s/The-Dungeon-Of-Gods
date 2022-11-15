using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaboss : MonoBehaviour
{
    public GameObject abrir;
     bool puerta_abierta ;
    void Start()
    {

        abrir.SetActive(false);

        //if(puerta_abierta == true)
        {
             
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
            abrir.SetActive(true);
    }

    private void Update()
    {
        if (abrir.activeInHierarchy==true && puerta_abierta==false)
        {
            abrir.SetActive(false);
        }
    }
}
