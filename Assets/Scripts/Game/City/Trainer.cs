using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainer : MonoBehaviour
{
    private GameObject Player;
    public GameObject Menu;
    private int slot;
    public GameObject[] Upgardes;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Menu.SetActive(true);
            Player = other.gameObject;
        }
        if (Player.GetComponent<PlayerStats>().progressionLevel >= 1)
        {
            Upgardes[0].SetActive(false);
        }
        if(Player.GetComponent<PlayerStats>().progressionLevel >= 2)
        {
            Upgardes[1].SetActive(false);
        }
        if(Player.GetComponent<PlayerStats>().progressionLevel >= 3)
        {
            Upgardes[2].SetActive(false);
        }
    }

    public void NewPerc(int index)
    {
        if(Player.GetComponent<PlayerStats>().progressionLevel >= 1 || slot < 1)
        {
            slot++;
            AddFirstPerc(index);
        }
        else if (Player.GetComponent<PlayerStats>().progressionLevel >= 2 || slot < 2)
        {
            slot++;
            AddSecPerc(index);
        }
        else if (Player.GetComponent<PlayerStats>().progressionLevel >= 3 || slot < 3)
        {
            slot++;
            AddThrPerc(index);
        }
    }

    public void AddFirstPerc(int index)
    {
        if(index == 1)
        {
            Player.GetComponent<PlayerCharacter>().maxHealth *= 2;
        }
        else
        {
            Player.GetComponent<PlayerCharacter>().maxShield += 10;
        }
    }

    public void AddSecPerc(int index)
    {
        if (index == 1)
        {
            Player.GetComponent<PlayerCharacter>().maxShield = 20;
        }
        else
        {
            Player.GetComponent<PlayerCharacter>().maxenergy += 10;
        }
    }

    public void AddThrPerc(int index)
    {
        if (index == 1)
        {
            Player.GetComponent<PlayerCharacter>().maxToughness += 20;
        }
        else
        {
            Player.GetComponent<PlayerCharacter>().maxEnlightenment += 100;
        }
    }
}
