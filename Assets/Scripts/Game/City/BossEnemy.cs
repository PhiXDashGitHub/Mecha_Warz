using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BossEnemy : MonoBehaviour
{
    public GameObject Boss;
    int bosskilled;
    public string cityname;
    public void Awake()
    {
        try
        {
            if (PlayerPrefs.GetInt("Boss" + cityname + GameObject.FindGameObjectWithTag("Player").name) == 1)
            {
                Destroy(Boss);
            }
        }
        catch (Exception)
        {
            Debug.Log("Boss is not killed yet");
        }
    }
    public void Update()
    {
        if (Boss == null)
        {
            bosskilled = 1;
            PlayerPrefs.SetInt("Boss" + cityname + GameObject.FindGameObjectWithTag("Player").name, bosskilled);
        }
    }
    public void OnApplicationQuit()
    {
        if (Boss != null)
        {
            bosskilled = 0;
            PlayerPrefs.SetInt("Boss" + cityname + GameObject.FindGameObjectWithTag("Player").name, bosskilled);
        }
    }
}
