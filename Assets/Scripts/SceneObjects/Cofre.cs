using UnityEngine;

public class Cofre : MonoBehaviour
{
    public Animator Anim;
    public GameObject Coin;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }
}
