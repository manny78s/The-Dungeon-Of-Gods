using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderBoss : MonoBehaviour
{
    [SerializeField] public Slider LifeBarr;
    [SerializeField] public JefeLife LifeAct;
    public float LifeMax;
    public TextMeshProUGUI Texto;
    public GameObject Slider;
    // Start is called before the first frame update
    void Start()
    {
        LifeAct= GetComponent<JefeLife>();
    }

    // Update is called once per frame
    void Update()
    {
        LifeMax = LifeAct.MaxLife;
        Texto.text = LifeAct.Life.ToString() + "%";
        LifeBarr.GetComponent<Slider>().maxValue = LifeMax;
        LifeBarr.GetComponent<Slider>().value = LifeAct.Life;
        if(LifeAct.Life<=0)
        {
            Slider.SetActive(false);
        }
    }
}
