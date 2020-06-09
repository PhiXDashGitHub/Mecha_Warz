using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    private string[] charnamestemp;
    private int index;
    public int CharSex;
    
    //Class Names: Basic , Melee , Ranged , Bio , Hybrid , Support
    private string Class = "Basic";

    public GameObject[] MechDisplay;
    public GameObject CharCreator;
    public GameObject CharName;
    public GameObject ButtonParent;

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
                ButtonParent.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerPrefsX.GetStringArray("CharNames")[i];
                if (charnamestemp[i] != "")
                {
                    MechDisplay[i].SetActive(true);

                    Color col = new Color();

                    col.r = (float)Convert.ToDouble(PlayerPrefs.GetString("CharColor" + PlayerPrefsX.GetStringArray("CharNames")[i]).Split(':')[0]);
                    col.g = (float)Convert.ToDouble(PlayerPrefs.GetString("CharColor" + PlayerPrefsX.GetStringArray("CharNames")[i]).Split(':')[1]);
                    col.b = (float)Convert.ToDouble(PlayerPrefs.GetString("CharColor" + PlayerPrefsX.GetStringArray("CharNames")[i]).Split(':')[2]);
                    col.a = (float)Convert.ToDouble(PlayerPrefs.GetString("CharColor" + PlayerPrefsX.GetStringArray("CharNames")[i]).Split(':')[3]);

                    var block = new MaterialPropertyBlock();

                    block.SetColor("_BaseColor", col);
                    MechDisplay[i].transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().SetPropertyBlock(block);


                    Class = PlayerPrefs.GetString("CharClass"+ PlayerPrefsX.GetStringArray("CharNames")[i]);
                }
                else
                {
                    ButtonParent.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = "+";
                }
            }
        }
        else
        {
            for(int i = 0; i < ButtonParent.transform.childCount; i++)
            {
                ButtonParent.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = "+";
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

        PlayerPrefs.SetFloat(newcharname + "MaxHealth", 100);
        PlayerPrefs.SetFloat(newcharname + "MaxMagicShield", 100);
        PlayerPrefs.SetFloat(newcharname + "MaxShield", 4);
        PlayerPrefs.SetFloat(newcharname + "MaxToughness", 0);
        PlayerPrefs.SetFloat(newcharname + "MaxEnlightenment", 0);
        PlayerPrefs.SetFloat(newcharname + "MaxEnergy", 100);
        PlayerPrefs.SetFloat(newcharname + "FireResistance", 0);
        PlayerPrefs.SetFloat(newcharname + "WaterResistance", 0);
        PlayerPrefs.SetFloat(newcharname + "IceResistance", 0);
        PlayerPrefs.SetFloat(newcharname + "ElectricResistance", 0);
        PlayerPrefs.SetFloat(newcharname + "PiercingResistance", 0);
        PlayerPrefs.SetFloat(newcharname + "BludgeoningResistance", 0);
        PlayerPrefs.SetFloat(newcharname + "SlashingResistance", 0);
        PlayerPrefs.SetFloat(newcharname + "PoisonResistance", 0);

        PlayerPrefs.SetInt(newcharname + "Magic", 0);
        PlayerPrefs.SetInt(newcharname + "Level", 1);
        PlayerPrefs.SetInt(newcharname + "ProgressionLevel", 0);

        for (int i = 0; i< charnamestemp.Length;i ++)
        {
            if(newcharname == charnamestemp[i])
            {
                newcharname += 1;
            }
        }
        charnamestemp[index] = newcharname;
        PlayerPrefsX.SetStringArray("CharNames", charnamestemp);
        PlayerPrefs.SetInt("CharSex" + charnamestemp[index], CharSex);
        PlayerPrefs.SetString("CharClass" + charnamestemp[index], Class);
        PlayerPrefs.SetString("CharColor" + charnamestemp[index], CharacterSelect.mechcolor.r + ":" + CharacterSelect.mechcolor.g + ":" + CharacterSelect.mechcolor.b + ":" + CharacterSelect.mechcolor.a);
        StartGame(charnamestemp[index]);
    }

    public void StartGame(string charname)
    {
        PlayerPrefs.SetInt("SaveState", index);
        SceneManager.LoadScene(1);
    }

    public void CreateCharMenu()
    {
        CharCreator.SetActive(true);
    }

    public void SetCharSex(int psex)
    {
        CharSex = psex;
    }
    public void SetCharClass(string pClass)
    {
        Class = pClass;
    }
    public void ClearAllCharacters()
    {
        PlayerPrefs.DeleteAll();
    }
}
