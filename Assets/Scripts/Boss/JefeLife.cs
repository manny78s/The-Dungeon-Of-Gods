using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeLife : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Animator Boss_Anim;
    [SerializeField] public PLMovement PnjScript;
    [SerializeField] private GameObject TextWin;
    [SerializeField] private GameObject PauseMe;
    [SerializeField] private GameObject ResumeButt;
    [SerializeField] private GameObject UIpl;
    //[SerializeField] private DropEnem DropScript;

    [Space]

    [Header("Stats")]
    [SerializeField] public float Life;
    [SerializeField] public float MaxLife;
    [SerializeField] private float inmuneTime;
    [SerializeField] private bool Inm;

    [Space]
    [Header("DañoPl")]
    [SerializeField] private float DañoC1;
    [SerializeField] private float DañoC2;
    [SerializeField] private float EspC;

    // Start is called before the first frame update
    void Start()
    {
        Boss_Anim = GetComponent<Animator>();
        MaxLife = Life;
    }

    // Update is called once per frame
    void Update()
    {
        if (Life <= 0)
        {
            Life = 0;
            Boss_Anim.SetBool("Dead", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="AtacC1")
        {
            Life -= DañoC1;
        }
        if(other.gameObject.tag=="AtacC2")
        {
            Life -= DañoC2;
        }
        if(other.gameObject.tag=="EspecialC")
        {
            Life -= EspC;
        }
    }
    public void DeadEvent()
    {
        PnjScript.enabled = false;
    }
     public void DeadFin()
    {
        TextWin.SetActive(true);
        ResumeButt.SetActive(false);
        UIpl.SetActive(false);
        PauseMe.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
