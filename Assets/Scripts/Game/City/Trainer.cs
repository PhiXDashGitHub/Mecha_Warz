using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainer : MonoBehaviour
{
    public GameObject Player;
    private int slot;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void NewPerc()
    {
        if(Player.GetComponent<PlayerStats>().progressionLevel >= 25 || slot < 1)
        {
            slot++;
            AddFirstPerc();
        }
        else if (Player.GetComponent<PlayerStats>().progressionLevel >= 50 || slot < 2)
        {
            slot++;
            AddSecPerc();
        }
        else if (Player.GetComponent<PlayerStats>().progressionLevel >= 75 || slot < 3)
        {
            slot++;
            AddThrPerc();
        }
    }

    public void AddFirstPerc()
    {

    }

    public void AddSecPerc()
    {

    }

    public void AddThrPerc()
    {

    }
}
