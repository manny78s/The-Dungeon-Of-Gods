using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LifeEnem : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D Enem_Rigid;
    [SerializeField] Animator Enem_Anim;
    [SerializeField] public PLMovement PnjScript;
    [SerializeField] private DropEnem DropScript;

    [Space]

    [Header("Stats")]
    [SerializeField] public float Life;
    [SerializeField] public float Shield;

    void Start()
    {
        Enem_Rigid = GetComponent<Rigidbody2D>();
        Enem_Anim = GetComponent<Animator>();
        DropScript = GetComponent<DropEnem>();
    }
    private void Update()
    {
        if(Life<=0)
        {
            Life = 0;
            Enem_Anim.SetBool("Dead", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "AtacC1")
        {
            Life -= PnjScript.DañoC1;
            Enem_Anim.SetBool("Dañado", true);
            if(Life <= 0)
            {
                Enem_Anim.SetBool("Dead", true);
            }
        }
        if(other.gameObject.tag == "AtacC2")
        {
            Life -= PnjScript.DañoC2;
            Enem_Anim.SetBool("Dañado", true);
            if (Life <= 0)
            {
                Enem_Anim.SetBool("Dead", true);
            }
        }
        if(other.gameObject.tag == "EspecialC")
        {
            Life -= PnjScript.DañoEspC;
            Enem_Anim.SetBool("Dañado", true);
            if (Life <= 0)
            {
                Enem_Anim.SetBool("Dead", true);
            }
        }
    }

    public void Muerto()
    {
        Enem_Anim.SetBool("Dead", false);
        this.gameObject.SetActive(false);
        DropScript.Drop();
    }

}
