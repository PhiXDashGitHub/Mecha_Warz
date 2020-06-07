using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Maxhealth;
    int health;

    public void Start()
    {
        health = Maxhealth;
    }
    public void Takedamage(int pdamage)
    {
        health -= pdamage;
        health = Mathf.Clamp(health,0,Maxhealth);
        if (health == 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
