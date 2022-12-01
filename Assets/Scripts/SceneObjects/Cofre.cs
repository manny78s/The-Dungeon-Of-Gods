using UnityEngine;
using UnityEngine.UI;

public class Cofre : MonoBehaviour
{
    public Animator Anim;
    public GameObject Coin;

    [SerializeField] private bool ConKey;
    [SerializeField] private Image Key;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }
    public void KeyDrop()
    {
        if(ConKey== true)
        {
            Key.color = new Color(255, 255, 255);
        }
    }
}
