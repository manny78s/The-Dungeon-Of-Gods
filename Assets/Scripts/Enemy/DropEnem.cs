using UnityEngine;

public class DropEnem : MonoBehaviour
{
    [SerializeField] private GameObject Coin;
    [SerializeField] private GameObject Origen;
    [SerializeField] private int DropRate;
    [SerializeField] private int MinDrop;
    [SerializeField] private int MaxDrop;


    
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
}
