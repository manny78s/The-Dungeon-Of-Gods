using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelections : MonoBehaviour
{
    public PLMovement PNJscript1;
    public CombSystem PNJscript2;
    public GameObject canvas;
    public GameObject UI;
    public GameObject SettingsMenu;
    public GameObject Collec;
    //[SerializeField] private string Scene;
    public void Play(string Scene)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(Scene);
    }
    public void Resumir()
    {
        UI.SetActive(true);
        canvas.SetActive(false);
        PNJscript1.enabled = true;
        PNJscript2.enabled = true;
    }

    public void VolverMenu(string Scene)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene(Scene);
    }
    public void Collecsions()
    {
        UI.SetActive(false);
        Collec.SetActive(true);
    }

    public void VolverCollect()
    {
        UI.SetActive(true);
        Collec.SetActive(false);
    }


    public void Settings()
    {
        UI.SetActive(false);
        SettingsMenu.SetActive(true);
    }
    public void VolverSettings()
    {
        UI.SetActive(true);
        SettingsMenu.SetActive(false);
    }

    public void Quit()
    {
        //Debug.Log("Salir");
        Application.Quit();
    }
}
