using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemys : MonoBehaviour
{
    [Header("Components")]
    public NavMeshAgent NavAge;
    [SerializeField] Animator Enem_Anim;

    [Space]
    [Header("Stats")]
    [SerializeField] public float NorSpeed;
    [SerializeField] public float RunSpeed;
    [SerializeField] public float AtacSpeed;
    [SerializeField] public float Damage;

    //public patrulla patroll;

    [Space]

    [Header("Detect_Player")]
    [SerializeField] public Transform Player;
    [SerializeField] float RadioSeguir;
    [SerializeField] float RadioAtaque;
    [SerializeField] private bool SeguirPL;
    [SerializeField] private bool AtaquePL;
    [SerializeField] private LayerMask PL;

    [Header("patrulla")]

    [SerializeField] private Transform[] PatrolPoint;
    [SerializeField] private float StopDis;
    [SerializeField] private float Espera;
    private int x;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, RadioSeguir);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,RadioAtaque);

    }
    void Start()
    {
        NavAge = GetComponent<NavMeshAgent>();
        NavAge.stoppingDistance = StopDis;
        x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SeguirPL = Physics2D.OverlapCircle(transform.position, RadioSeguir, PL);
        AtaquePL = Physics2D.OverlapCircle(transform.position, RadioAtaque, PL);
        SeguirPNJ();
        if(Espera>=3)
        {
            Espera = 0;
            x = 1;
            NavAge.isStopped = false;
        }
    }

     private void SeguirPNJ()
     {
        if (SeguirPL == true)
        {
            Girar();
            NavAge.speed = RunSpeed;
            NavAge.destination = Player.position;
            Enem_Anim.SetBool("Correr", true);
            NavAge.isStopped = false;
        }
        else
        {
            Enem_Anim.SetBool("Correr",false);
            NavAge.speed = NorSpeed;
            patrulla();
        }

        if (AtaquePL == true)
        {
            Girar();
            NavAge.isStopped = true;
            AtacSpeed += 1 *Time.deltaTime;
            if(AtacSpeed >=2)
            {
                Enem_Anim.SetBool("Atacar", true);
                AtacSpeed = 0;
            }
        }
        else
        {
            NavAge.isStopped=false;
        }
     }
    private void patrulla()
    {
        NavAge.speed = NorSpeed;
        NavAge.destination = PatrolPoint[x].position;
        Enem_Anim.SetBool("Caminar",true);
        GirarPatrulla();
        if(HeLlegado() == true)
        {
            Espera += 1 * Time.deltaTime;
            NavAge.isStopped = true;
        }
        if(x == 1 && Espera >= 2)
        {
            Espera = 0;
            x = 0;
            NavAge.isStopped = false;
        }
        if(NavAge.isStopped == true)
        {
            Enem_Anim.SetBool("Caminar", false);
        }

    }

    private void GirarPatrulla()
    {

        if(transform.position.x < PatrolPoint[x].position.x)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }
    private void Girar()
    {
        if (transform.position.x < Player.position.x)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "AtacC1"|| other.gameObject.tag == "AtacC2"|| other.gameObject.tag == "EspecialC")
        {
            NavAge.isStopped = true;
        }
    }

    public bool HeLlegado()
    {
        return NavAge.remainingDistance <= NavAge.stoppingDistance && !NavAge.pathPending;
    }
    public void Finalizar()
    {
        Enem_Anim.SetBool("Atacar", false);
    }

    public void Recuperar()
    {
        Enem_Anim.SetBool("Dañado", false);
        NavAge.isStopped = false;
    }
    public void Detengase()
    {
        NavAge.isStopped = true;
        Enem_Anim.SetBool("Dañado", false);
    }

}
