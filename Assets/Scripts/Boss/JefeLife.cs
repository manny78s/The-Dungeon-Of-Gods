using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeLife : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Animator Boss_Anim;
    [SerializeField] public PLMovement PnjScript;
    //[SerializeField] private DropEnem DropScript;

    [Space]

    [Header("Stats")]
    [SerializeField] public float Life;
    [SerializeField] private float inmuneTime;
    [SerializeField] private bool Inm;
    // Start is called before the first frame update
    void Start()
    {
        Boss_Anim = GetComponent<Animator>();
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
        if(other.gameObject.tag=="")
        {

        }
    }
}
