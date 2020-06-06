using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Damage;

    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            other.gameObject.GetComponent<Enemy>().Takedamage(Damage);
        }
    }
}
