using System.Collections;
using UnityEngine;


public class LifeEnem : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] Animator Enem_Anim;
    [SerializeField] public PLMovement PnjScript;
    [SerializeField] private DropEnem DropScript;

    [Space]

    [Header("Stats")]
    [SerializeField] public float Life;
    //[SerializeField] public float Shield;
    [SerializeField] private float inmuneTime;
    [SerializeField] private bool Inm;

    void Start()
    {
 
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
            Life -= PnjScript.Da�oC1;
            Enem_Anim.SetBool("Da�ado", true);
            //StartCoroutine(Inmo());
            if(Life <= 0)
            {
                Enem_Anim.SetBool("Dead", true);
            }
        }
        if(other.gameObject.tag == "AtacC2" && !Inm)
        {
            Life -= PnjScript.Da�oC2;
            Enem_Anim.SetBool("Da�ado", true);
            StartCoroutine(Inmo());
            if (Life <= 0)
            {
                Enem_Anim.SetBool("Dead", true);
            }
        }
        if(other.gameObject.tag == "EspecialC")
        {
            Life -= PnjScript.Da�oEspC;
            Enem_Anim.SetBool("Da�ado", true);

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
    IEnumerator Inmo()
    {
        Inm = true;
        yield return new WaitForSeconds(inmuneTime);
        Inm = false;
    }

}
