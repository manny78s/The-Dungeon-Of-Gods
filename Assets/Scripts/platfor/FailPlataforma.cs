using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPlataforma : MonoBehaviour
{
    Rigidbody2D rb;
    float fallDelay = 2f;
    [SerializeField] private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    IEnumerator ConstPlat()
    {

        yield return new WaitForSeconds(1.5f);
        Anim.SetBool("Destruir",false);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Anim.SetBool("Destruir",true);
            StartCoroutine(ConstPlat());
        }
    }
    public void ConsPlat()
    {
        Anim.SetBool("Destruir", false);
    }
}
