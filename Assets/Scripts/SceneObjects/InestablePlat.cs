using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InestablePlat : MonoBehaviour
{
    int TimeEstable;
    public Animator inestableAnim;

    private void Update()
    {
        if(TimeEstable == 1)
        {
            inestableAnim.SetInteger("TimeDes", 1);
        }
        if(TimeEstable == 2)
        {
            inestableAnim.SetInteger("TimeDes", 2);
        }
        if(TimeEstable==3)
        {
            inestableAnim.SetInteger("TimeDes", 3);
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
        {
            StartCoroutine(AnimDes());
            if(Input.GetButton("Bajar"))
            {
                Collider2D CollisionPlayer = other.collider.GetComponent<Collider2D>();
                //bajar
                Physics2D.IgnoreCollision(CollisionPlayer,GetComponent<Collider2D>(), true);
                StartCoroutine(IngoreColin(CollisionPlayer));
            }
        }
    }
    IEnumerator IngoreColin(Collider2D PlayerCollider)
    {
        Physics2D.IgnoreCollision(PlayerCollider, GetComponent<Collider2D>(), true);
        yield return new WaitForSeconds(0.9f);
        Physics2D.IgnoreCollision(PlayerCollider, GetComponent<Collider2D>(), false);
    }
    IEnumerator AnimDes()
    {
        yield return new WaitForSeconds(1f);
        TimeEstable = 1;
        yield return new WaitForSeconds(0.8f);
        TimeEstable = 2;
        yield return new WaitForSeconds(0.5f);
        TimeEstable = 3;
    }

    void OffPlataform ()
    {
        gameObject.SetActive(false);
    }
}
