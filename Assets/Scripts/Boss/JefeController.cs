using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JefeController : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] public NavMeshAgent Nav_God;
    [SerializeField] public Animator Anim_God;

    [Space]

    [Header("Stats")]
    [SerializeField] public float Speed;
    [SerializeField] public float Damage1;
    [SerializeField] public float Damage2;
    [SerializeField] public float LighthingDmg;

    [Space]

    [Header("Detect_Player")]
    [SerializeField] public Transform Player;
    [SerializeField] float RadioAtaque1;
    [SerializeField] float RadioAtaque2;
    [SerializeField] float RadioRayo;
    [SerializeField] float Detec;
    [SerializeField] bool PLDetec;
    [SerializeField] private LayerMask PL;

    [Space]

    [Header("AtakManager")]
    [SerializeField] public float WaitAtac1;
    [SerializeField] public float WaitAtac2;
    [SerializeField] public float WaitRayo;
    [SerializeField] private bool Ataque1;
    [SerializeField] private bool Ataque2;
    [SerializeField] private bool Rayo;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, RadioAtaque1);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere (transform.position, RadioAtaque2);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, RadioRayo);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, Detec);
    }
    void Start()
    {
        Nav_God = GetComponentInChildren<NavMeshAgent>();
        Anim_God = GetComponentInChildren<Animator>();
        Nav_God.speed = Speed;
        Nav_God.SetDestination(Player.position);
    }

    // Update is called once per frame
    void Update()
    {
        Ataque1 = Physics2D.OverlapCircle(transform.position, RadioAtaque1,PL);
        Ataque2 = Physics2D.OverlapCircle(transform.position, RadioAtaque2,PL);
        Rayo = Physics2D.OverlapCircle(transform.position, RadioRayo,PL);
        PLDetec = Physics2D.OverlapCircle(transform.position, Detec, PL);

        Girar();
        if(HeLlegado() == true)
        {
            Nav_God.isStopped = true;
            WaitAtac1 += 1 * Time.deltaTime;
            WaitAtac2 += 1 * Time.deltaTime;
            if(Ataque1==true&&WaitAtac1>=2)
            {
                Anim_God.SetBool("Puñetazo",true);
            }
            if(Ataque2==true&&WaitAtac2>=4)
            {
                Anim_God.SetBool("Pisada",true);
            }
        }
        if(PLDetec == true)
        {
            Nav_God.SetDestination(Player.position);
            if(Rayo==true)
            {
                WaitRayo += 1 * Time.deltaTime;
                if(WaitRayo >=6)
                {
                    Anim_God.SetBool("Rayo", true);
                }
            }
        }
    }

    private void Girar()
    {
        if (transform.position.x > Player.position.x)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }
    public bool HeLlegado()
    {
        return Nav_God.remainingDistance <= Nav_God.stoppingDistance && !Nav_God.pathPending;
    }
    public void DesRay()
    {
        Anim_God.SetBool("Rayo", false);
    }
    public void DesPunch()
    {
        Anim_God.SetBool("Puñetazo", false);
    }
    public void DesImp()
    {
        Anim_God.SetBool("Pisada", false);
    }
}
