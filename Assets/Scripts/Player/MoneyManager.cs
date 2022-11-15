using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] public float Money;
    [SerializeField] public TextMeshProUGUI Cantidad;
    [SerializeField] public int TotalMoney;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalMoney=(int)Money;
        Cantidad.text="$ " + TotalMoney;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Bronce")
        {
            Money += other.GetComponent<Coin>().ValueCoin;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag=="Oro")
        {
            Money += other.GetComponent<Coin>().ValueCoin;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag=="Ultra")
        {
            Money += other.GetComponent<Coin>().ValueCoin;
            Destroy(other.gameObject);
        }
    }
}
