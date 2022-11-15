using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Romper : MonoBehaviour
{
    [SerializeField] Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="AtacC1" || collision.gameObject.tag=="AtacC2")
        {
            Anim.SetBool("Destruir",true);
        }
    }
    void desactive()
    {
        this.gameObject.SetActive(false);
    }
}
