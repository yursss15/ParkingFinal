using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour
{
    public GameObject city, cyber;

    void Start()
    {
         PlayerPrefs.SetString("NowMap", "City"); // —брос магазина
        if (GameManager.Instance.CurrentCity == "Cyber")
            cyber.SetActive(true);
        else
            city.SetActive(true);
    }
}
