using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    private string[] charnamestemp;
    private int index;
    public int CharSex;
    public Sprite[] Charpriv;
    public GameObject CharCreator;
    public GameObject CharName;
    public GameObject CharDisplay;

    public void Start()
    {
        try
        {
            charnamestemp = PlayerPrefsX.GetStringArray("CharNames");
        }
        catch (Exception)
        {
            charnamestemp = new string[0];
        }
        if (charnamestemp.Length > 0)
        {
            for (int i = 0; i < charnamestemp.Length; i++)
            {
                this.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerPrefsX.GetStringArray("CharNames")[i];
                if (PlayerPrefsX.GetStringArray("CharNames")[i] != "")
                {
                    this.transform.GetChild(i).GetComponent<Image>().sprite = Charpriv[PlayerPrefs.GetInt("CharSex" + PlayerPrefsX.GetStringArray("CharNames")[i])];
                }
                
            }
        }
        else
        {
            for(int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = "+";
            }
        }
    }

    public void Selectcharacter(int pindex)
    {
        index = pindex;

        try
        {
            charnamestemp = PlayerPrefsX.GetStringArray("CharNames");
            CharSex = PlayerPrefs.GetInt("CharSex" + charnamestemp[index]);
            if (charnamestemp[index] == "")
            {
                CreateCharMenu();
                return;
            }
            StartGame(charnamestemp[index]);
        } catch(Exception)
        {
            charnamestemp = new string[3] {"","","" };
            CreateCharMenu();
        }
    }

    public void CreatCharacter()
    {
        string newcharname = CharName.GetComponent<TextMeshProUGUI>().text;
        charnamestemp[index] = newcharname;
        PlayerPrefsX.SetStringArray("CharNames", charnamestemp);
        PlayerPrefs.SetInt("CharSex" + charnamestemp[index], CharSex);
        StartGame(charnamestemp[index]);
    }

    public void StartGame(string charname)
    {
        GameObject game = new GameObject();
    }

    public void CreateCharMenu()
    {
        CharCreator.SetActive(true);
    }

    public void SetCharSex(int psex)
    {
        CharSex = psex;
        CharDisplay.GetComponent<Image>().sprite = Charpriv[psex];
    }

    public void ClearAllCharacters()
    {
        PlayerPrefs.DeleteAll();
    }
}
