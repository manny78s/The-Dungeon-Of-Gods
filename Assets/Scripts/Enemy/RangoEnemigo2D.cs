using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemigo2D : MonoBehaviour
{
    public Animator ani;
    public Enemigo2D enemigo;
    public BoxCollider2D RangoBox;

    private void Start()
    {
        RangoBox = GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
           ani.SetBool("Caminar", false);
           ani.SetBool("Correr", false);
           ani.SetBool("Atacar", true);
           enemigo.atacando = true;
           RangoBox.enabled = false;            
        }
    }

}
