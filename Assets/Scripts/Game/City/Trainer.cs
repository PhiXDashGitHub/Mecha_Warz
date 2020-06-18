using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainer : MonoBehaviour
{
    private GameObject Player;
    public GameObject Menu;
    private int slot;
    public GameObject[] Upgardes;

    void Start()
    {
        Player = FindObjectOfType<PlayerStats>().gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Menu.SetActive(true);

            if (Player.GetComponent<PlayerStats>().progressionLevel >= 1)
            {
                Upgardes[0].SetActive(false);
            }
            if (Player.GetComponent<PlayerStats>().progressionLevel >= 2)
            {
                Upgardes[1].SetActive(false);
            }
            if (Player.GetComponent<PlayerStats>().progressionLevel >= 3)
            {
                Upgardes[2].SetActive(false);
            }
        }
    }

    public void NewPerc(int index)
    {
        if(Player.GetComponent<PlayerStats>().progressionLevel >= 1 && slot < 1)
        {
            slot++;
            AddFirstPerc(index);
        }
        else if (Player.GetComponent<PlayerStats>().progressionLevel >= 2 && slot < 2)
        {

            slot++;
            AddSecPerc(index);
        }
        else if (Player.GetComponent<PlayerStats>().progressionLevel >= 3 && slot < 3)
        {
            slot++;
            AddThrPerc(index);
        }
    }

    public void AddFirstPerc(int index)
    {
        if(index == 1)
        {
            Player.GetComponent<PlayerStats>().maxHealthbuff += 100;
        }
        else
        {
            Player.GetComponent<PlayerStats>().maxShieldbuff += 20;
        }
    }

    public void AddSecPerc(int index)
    {
        if (index == 1)
        {
            Player.GetComponent<PlayerStats>().maxShieldbuff += 30;
        }
        else
        {
            Player.GetComponent<PlayerCharacter>().maxenergy += 50;
        }
    }

    public void AddThrPerc(int index)
    {
        if (index == 1)
        {
            Player.GetComponent<PlayerStats>().maxToughnessbuff += 40;
        }
        else
        {
            Player.GetComponent<PlayerStats>().maxEnlightenmentbuff += 100;
        }
    }
}
