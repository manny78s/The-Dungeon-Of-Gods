using UnityEngine;

public class Key : MonoBehaviour
{
    public int KeyAmount;
    [SerializeField] private OpenDoor script; 
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Key")
        {
            KeyAmount += 1;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Door")
        {
            if(KeyAmount>=1)
            {
                script.abierto = true;
            }
        }
    }
}
