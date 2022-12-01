using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimLife : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject PlScripts;
    [SerializeField] private GameObject BossScript;
    [SerializeField] private GameObject Muro;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }
    private void Awake()
    {
        PlScripts = GameObject.FindGameObjectWithTag("Player");
        //BossScript = GameObject.FindGameObjectWithTag("God");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DesAnim()
    {
        //BossScript.GetComponent<SpriteRenderer>().enabled = true;
        //BossScript.GetComponent<Animator>().enabled = true;
        BossScript.SetActive(true);
        PlScripts.GetComponent<PLMovement>().enabled = true;
        animator.enabled = false;
        
    }
    public void DesPl()
    {
        PlScripts.GetComponent<PLMovement>().enabled = false;
        Muro.SetActive(true);

    }
}
