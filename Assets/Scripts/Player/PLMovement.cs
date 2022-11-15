using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLMovement : MonoBehaviour
{
    [Header("Player_Comp")]
    
    public Rigidbody2D PL_Rigid;
    public BoxCollider2D PL_Colider;
    public Animator PL_Anim;
    public Transform PL_Scale;
    [SerializeField] public bool IcanMove = true;

    [Space]

    [Header("Stats_Movement")]

    [SerializeField] float JumpForce;
    [SerializeField] public float NorSpeed;
    [SerializeField] public float RunSpeed;

    [Space]

    [Header("Stats_Atacks")]
    [SerializeField] public float DañoC1;
    [SerializeField] public float DañoC2;
    [SerializeField] public float DañoL1;
    [SerializeField] public float DañoL2;
    [SerializeField] public float DañoEspL;
    [SerializeField] public float DañoEspC;

    [Space]

    [Header("CollSuelo")]

    public bool InGround;
    public bool InPlataform;
    public Transform ColBase;
    [SerializeField] private Vector2 BoxDimencions;
    [SerializeField] LayerMask Ground;
    [SerializeField] LayerMask Plataforms;

    [Space]

    [Header("JumpController")]

    [Range(0, 1)][SerializeField] float CancelarSalto;
    [SerializeField] private float MultiplicadorGravedad;
    private bool JumpBottonUp = true;
    private float GravityScale;
    private bool jump;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(ColBase.position,BoxDimencions);
    }
    void Start()
    {
        PL_Rigid = GetComponent<Rigidbody2D>();
        PL_Colider = GetComponent<BoxCollider2D>();
        PL_Anim = GetComponentInChildren<Animator>();
        PL_Scale = GetComponent<Transform>();
        IcanMove = true;
        GravityScale = PL_Rigid.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(IcanMove==true)
        {
            Movement();
            AnimAndFlip();

            if (Input.GetButton("Saltar"))
            {
                jump = true;
            }
            if (Input.GetButtonUp("Saltar"))
            {
                BottonJumpUp();
            }
        }
        YSpeed();

        InGround = Physics2D.OverlapBox(ColBase.position, BoxDimencions, 0, Ground);
        InPlataform = Physics2D.OverlapBox(ColBase.position, BoxDimencions, 0, Plataforms);
    }
    private void FixedUpdate()
    {
        if(jump == true && JumpBottonUp && InGround == true || jump == true && JumpBottonUp && InPlataform == true)
        {
            JumpMovement();
        }
        if (PL_Rigid.velocity.y < 0 && !InGround || PL_Rigid.velocity.y < 0 && !InPlataform)
        {
            PL_Rigid.gravityScale = GravityScale * MultiplicadorGravedad;
        }
        else
        {
            PL_Rigid.gravityScale = GravityScale;
        }

        jump = false;
    }
    //Movimiento y animaciones de movimiento
    void Movement()
    {
        float Hor = Input.GetAxis("Horizontal");
        PL_Rigid.velocity = new Vector2(Hor*NorSpeed,PL_Rigid.velocity.y);

        if(Input.GetButton("Izquierda") && Input.GetKey(KeyCode.LeftShift)|| Input.GetButton("Derecha") && Input.GetKey(KeyCode.LeftShift))
        {
            PL_Rigid.velocity = new Vector2(Hor*RunSpeed,PL_Rigid.velocity.y);
        }
        if(Input.GetButton("Izquierda") && Input.GetKey(KeyCode.RightControl) || Input.GetButton("Derecha") && Input.GetKey(KeyCode.RightControl))
        {
            PL_Rigid.velocity = new Vector2(Hor * RunSpeed, PL_Rigid.velocity.y);
        }
    }
    void AnimAndFlip()
    {
        //Caminar Flip and Anim
        if(Input.GetButton("Izquierda"))
        {
            PL_Scale.localScale = new Vector3(-1, 1, 1);
            PL_Anim.SetBool("Caminar", true);
        }
        if(Input.GetButton("Derecha"))
        {
            PL_Scale.localScale = new Vector3(1, 1, 1);
            PL_Anim.SetBool("Caminar", true);
        }
        if (Input.GetButtonUp("Izquierda") || Input.GetButtonUp("Derecha"))
        {
            PL_Anim.SetBool("Caminar", false);
            PL_Anim.SetBool("Correr", false);
        }
        //Correr Flip and Anim
        if (Input.GetButton("Izquierda") && Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Izquierda") && Input.GetKey(KeyCode.RightControl))
        {
            PL_Scale.localScale = new Vector3(-1, 1, 1);
            PL_Anim.SetBool("Correr", true);
        }
        if(Input.GetButton("Derecha") && Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Derecha") && Input.GetKey(KeyCode.RightControl))
        {
            PL_Scale.localScale = new Vector3(1, 1, 1);
            PL_Anim.SetBool("Correr", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            PL_Anim.SetBool("Correr", false);
        }
    }
    //Salto y animacion
    void JumpMovement()
    {
        PL_Rigid.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        InGround = false;
        InPlataform = false;
        JumpBottonUp = false;
        jump = false;
    }
    private void BottonJumpUp()
    {
        if (PL_Rigid.velocity.y > 0)
        {
            PL_Rigid.AddForce(Vector2.down * PL_Rigid.velocity.y * (1 - CancelarSalto), ForceMode2D.Impulse);
        }
        JumpBottonUp = true;
        jump = false;
    }
    private void YSpeed()
    {
        PL_Anim.SetFloat("AcelerationY", PL_Rigid.velocity.y);
        if (InGround == true || InPlataform == true)
        {
            PL_Anim.SetBool("Ground", true);
        }
        else
        {
            PL_Anim.SetBool("Ground", false);
        }
    }
}
