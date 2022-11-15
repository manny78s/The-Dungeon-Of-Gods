using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderBoss : MonoBehaviour
{
    [SerializeField] public Slider LifeBarr;
    [SerializeField] public LifeEnem LifeAct;
    public float Life;
    public TextMeshProUGUI Texto;
    public GameObject Slider;
    // Start is called before the first frame update
    void Start()
    {
        LifeAct= GetComponent<LifeEnem>();
    }

    // Update is called once per frame
    void Update()
    {
        Life = LifeAct.Life;
        Texto.text = Life.ToString() + "%";
        LifeBarr.GetComponent<Slider>().value = Life;
        if(Life<=0)
        {
            Slider.SetActive(false);
        }
    }
}
