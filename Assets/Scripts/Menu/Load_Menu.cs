using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Menu : MonoBehaviour
{
    public Animator Iniciar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("presionaste enter");
            Iniciar.SetBool("Play",true);
            StartCoroutine(Anim());          
        }
    }
    IEnumerator Anim()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Menu");
    }
}
