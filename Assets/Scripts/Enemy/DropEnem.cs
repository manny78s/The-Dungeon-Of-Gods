using UnityEngine;
using UnityEngine.UI;

public class DropEnem : MonoBehaviour
{
    [SerializeField] private GameObject Coin;
    [SerializeField] private GameObject Origen;
    [SerializeField] private int DropRate;
    [SerializeField] private int MinDrop;
    [SerializeField] private int MaxDrop;

    [SerializeField] private bool ConKey;
    [SerializeField] private Image Key;
    [SerializeField] private PLMovement K;

    public void Drop()
    {
        int rand = Random.Range(1, 100);

        //print(rand);

        if(rand < DropRate)
        {
            int amont = Random.Range(MinDrop, MaxDrop);

            for(int i = 0; i < amont; i++)
            {
                Instantiate(Coin, Origen.transform.position,Origen.transform.rotation);
                
            }
        }
    }

    public void KeyDrop()
    {
        if (ConKey == true)
        {
            Key.color = new Color(255, 255, 255);
            K.KeyIn = true;
        }
    }
}
