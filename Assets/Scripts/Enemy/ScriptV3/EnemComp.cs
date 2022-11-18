using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemComp : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private Transform GroundControl1;
    [SerializeField] private Transform GroundControl2;
    [SerializeField] private bool LookRigth;
    [SerializeField] private LayerMask IsGround;
    [SerializeField] private Animator Anim;
    [SerializeField] private float Distance;
    [SerializeField] private Vector2 BoxDimencions;
    [SerializeField] private float AngleBox;

    [SerializeField] private float Speed1;
    [SerializeField] private float Speed2;
    [SerializeField] private bool Player;
    [SerializeField] private LayerMask IsPlayer;


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D InfoGround = Physics2D.Raycast(GroundControl1.position, Vector2.down, Distance,IsGround);
        Player = Physics2D.OverlapBox(this.transform.position, BoxDimencions, AngleBox, IsPlayer);

        Rb.velocity = new Vector2(Speed1, Rb.velocity.y);
        Anim.SetBool("Caminar", true);

        if(InfoGround== false)
        {
            FlipR();
        }

        if(Player == true)
        {
            Rb.velocity = new Vector2(Speed2, Rb.velocity.y);
        }
    }
    // Update is called once per frame
    void FlipR()
    {
        LookRigth = !LookRigth;
        //transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        Speed1 *= -1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(GroundControl1.transform.position, GroundControl1.transform.position + Vector3.down * Distance);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, BoxDimencions);

    }
}
