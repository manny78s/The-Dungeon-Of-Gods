using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LifePL : MonoBehaviour
{
    public Animator PL_Anim;
    public Rigidbody2D PL_Rigid;
    [SerializeField] public float Life;
    [SerializeField] private float TotalLife;
    public float Shield;
    [Header("UICOMP")]

    [SerializeField] public Slider LifeBarr;
    [SerializeField] public GameObject LifeBoss;
    [SerializeField] GameObject Boss;
    [SerializeField] public GameObject Texto;
    [SerializeField] public GameObject Panel;

    [Header("EfectoDaño ")]

    [SerializeField] public float KnockBackForceX;
    [SerializeField] public float KnockBackForceY;
    [SerializeField] public bool Inmune;
    [SerializeField] private float TimeInmune;
    [SerializeField] private float OffControlTime;
    [SerializeField] public bool GasD;
    [SerializeField] private float TimeDGas;
    [SerializeField] private float DañoG;

    // Start is called before the first frame update
    void Start()
    {
        PL_Anim = GetComponentInChildren<Animator>();
        Shield = 1;
        PL_Rigid = GetComponentInChildren<Rigidbody2D>();
        Boss = GameObject.FindGameObjectWithTag("God");
        Boss.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void Update()
    {

        LifeBarr.GetComponent<Slider>().maxValue = TotalLife;
        LifeBarr.GetComponent<Slider>().value = Life; 
        /*if(Boss.activeInHierarchy == false)
        {
            Texto.SetActive(true);
            Panel.SetActive(true);
        }*/
 
    }
    private void FixedUpdate()
    {
        if (Life <= 0)
        {
            PL_Anim.SetBool("NoLifePoint", true);
            Life = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pinchos")
        {
            PL_Anim.SetBool("NoLifePoint", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemAtacC" && !Inmune)
        {
            Life -= other.GetComponentInParent<Enemys>().Damage;
            StartCoroutine(NoControll());
            PL_Anim.SetBool("Dañado", true);
            StartCoroutine(Inmunity());

            if(other.transform.position.x > transform.position.x)
            {
                PL_Rigid.AddForce(new Vector2(-KnockBackForceX, KnockBackForceY),ForceMode2D.Force);
            }
            else
            {
                PL_Rigid.AddForce(new Vector2(KnockBackForceX, KnockBackForceY), ForceMode2D.Force);
            }
            if(Life <= 0)
            {
                PL_Anim.SetBool("NoLifePoint", true);
            }
        }

        if(other.gameObject.tag == "Batalla")
        {
            LifeBoss.SetActive(true);
        }

        if (other.gameObject.tag == "Cofre" && Input.GetKey(KeyCode.E))
        {
            Debug.Log("Abrete sesamo");
            other.GetComponent<Cofre>().Anim.SetBool("Abierto", true);
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Abrete sesamo");
                other.GetComponent<Cofre>().Anim.SetBool("Abierto", true);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "GasZ")
        {
            StartCoroutine(DañoGas());
            if(GasD== true)
            {
                GasD = false;
            }
            /*else
            {
                PL_Anim.SetBool("Dañado", false);
            }*/
        }
    }

    IEnumerator Inmunity()
    {
        Inmune = true;
        yield return new WaitForSeconds(TimeInmune);
        Inmune = false;
    }
    IEnumerator NoControll()
    {
        this.GetComponent<PLMovement>().enabled = false;
        this.GetComponentInChildren<CombSystem>().enabled = false;
        yield return new WaitForSeconds(OffControlTime);
        this.GetComponent<PLMovement>().enabled = true;
        this.GetComponentInChildren<CombSystem>().enabled = true;
    }
    IEnumerator DañoGas()
    {
        yield return new WaitForSeconds(TimeDGas);
        Life -= DañoG;
        PL_Anim.SetBool("Dañado", true);
        PL_Anim.SetBool("Dañado", false);
        yield return new WaitForSeconds(TimeDGas);
        Life -= DañoG;
        PL_Anim.SetBool("Dañado", true);
        PL_Anim.SetBool("Dañado", false);
        yield return new WaitForSeconds(TimeDGas);
        Life -= DañoG;
        PL_Anim.SetBool("Dañado", true);
        PL_Anim.SetBool("Dañado", false);
    }
}
