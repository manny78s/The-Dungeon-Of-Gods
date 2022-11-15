using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombSystem : MonoBehaviour
{
    [SerializeField] public bool Atacando;
    [SerializeField] private int Combo;
    public Animator PL_Anim;
    public string SceneAct;
    [SerializeField] float Estoque;
    [SerializeField] private float EspReload;
    private bool ActiveEsp;
    [SerializeField] Transform father;
    [SerializeField] public PLMovement PL_Script;
    // Start is called before the first frame update
    void Start()
    {
        PL_Anim = GetComponent<Animator>();
        father = GetComponentInParent<Transform>();
        ActiveEsp = true;
        PL_Script = GetComponentInParent<PLMovement>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(PL_Script.InGround == true || PL_Script.InPlataform == true)
        {
            Combos_();
        }
        if(ActiveEsp == true)
        {
            Atac_ESP();
        }
    }
    public void StartCombo()
    {
        Atacando = false;
        if (Combo<2)
        {
            Combo++;
        }
    }
    public void FinishComb()
    {
        Atacando = false;
        Combo = 0;
    }
    public void Combos_()
    {
        if(Input.GetMouseButtonDown(0) && !Atacando)
        {
            Atacando = true;
            PL_Anim.SetTrigger("" + Combo);
        }
    }
    public void Atac_ESP()
    {
        if (Input.GetButtonDown("Especial"))
        {
            PL_Anim.SetBool("Especial", true);
            this.GetComponentInParent<PLMovement>().enabled = false;
            StartCoroutine(ReloadESP());
            if (this.transform.parent.transform.localScale.x > 0)
            {
                this.GetComponentInParent<Rigidbody2D>().AddForce(Vector2.right * Estoque, ForceMode2D.Impulse);
            }
            if (this.transform.parent.transform.localScale.x < 0)
            {
                this.GetComponentInParent<Rigidbody2D>().AddForce(Vector2.right * -Estoque, ForceMode2D.Impulse);
            }
        }
    }

    public void FinalizarESP()
    {
        PL_Anim.SetBool("Especial", false);
        this.GetComponentInParent<PLMovement>().enabled = true;
    }
    public void FinalizarDaño()
    {
        PL_Anim.SetBool("Dañado", false);
    }
    public void Dead()
    {
        PL_Anim.SetBool("NoLifePoint", false);
    }
    public void cambio()
    {
        SceneManager.LoadScene(SceneAct);
    }
  

    IEnumerator ReloadESP()
    {
        ActiveEsp = false;
        yield return new WaitForSeconds(EspReload);
        ActiveEsp = true;
    }

}
