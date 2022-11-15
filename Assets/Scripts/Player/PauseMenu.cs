using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public PLMovement PNJscript1;
    [SerializeField] public CombSystem PNJscript2;
    [SerializeField] public GameObject Canvas;
    [SerializeField] public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        PNJscript1 = GetComponent<PLMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PNJscript1.enabled = false;
            PNJscript2.enabled = false;
            Canvas.SetActive(true);
            UI.SetActive(false);
        }
        /*if (Input.GetKeyDown(KeyCode.Escape) && ContEscape == 1)
        {
            PNJscript.enabled = true;
            Canvas.SetActive(false);
            ContEscape = 0;
        }*/
    }
}
