using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.ConstrainedExecution;

public class ChooseCity : MonoBehaviour
{
    [SerializeField]
    string cityName;

    public static event Action buttonClicked;
     

    private void Start()
    {
        SetColor();
    }

    public void SetCurrentCity()
    {
        
        if (cityName == "City" || (cityName == "Cyber" && PlayerPrefs.GetString("NowMap") == "Cyber"))
        {
            GameManager.Instance.CurrentCity = cityName;
            PlayerPrefs.SetString("CurrentCity", cityName);
            buttonClicked?.Invoke();
        }
        
    }
    public void SetColor()
    {
        if (PlayerPrefs.GetString("CurrentCity") == cityName)
        {
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            GetComponent<Image>().color = Color.gray;
        }
    }

    private void OnEnable()
    {
        ChooseCity.buttonClicked += SetColor;
    }

    private void OnDisable()
    {
        ChooseCity.buttonClicked -= SetColor;
    }
}
