using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampa_buts : MonoBehaviour
{
    int Trampas_bots;
    // Start is called before the first frame update
    void Start()
    {
        Trampas_bots = LayerMask.NameToLayer("Trampas_bots");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trampa_bots");
    }
}
