using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Rigidbody2D CoinRb;

    [SerializeField] public float ValueCoin;

    private void Start()
    {
        CoinRb=GetComponent<Rigidbody2D>();
        CoinRb.AddForce(new Vector2(Random.Range(-3f, 3f), 5f), ForceMode2D.Impulse);
    }
    /*public void Splash()
    {
        CoinRb.AddForce(new Vector2(Random.Range(-3f, 3f), 2f), ForceMode2D.Impulse);
    }*/
}
