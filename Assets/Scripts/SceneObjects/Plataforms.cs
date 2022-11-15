using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforms : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
        {
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
}
