using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator anim;
    public bool abierto = false;
    private Key keys;
    void Start()
    {
        anim = GetComponent<Animator>();
        keys = FindObjectOfType<Key>();
        abierto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (abierto == true && keys.KeyAmount >= 1)
        {
            //keys.KeyAmount += 1;
            anim.SetTrigger("OpenDoor");
            //abierto = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
