using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Damage;
    public bool ismeshweapon;

    public void Update()
    {
        if (ismeshweapon)
        {
            transform.position += transform.forward * Time.deltaTime* 50;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (ismeshweapon)
        {
            if (other.gameObject.GetComponent<Enemy>())
            {
                other.gameObject.GetComponent<Enemy>().Takedamage(Damage);
            }
        }
    }

    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            other.gameObject.GetComponent<Enemy>().Takedamage(Damage);
        }
    }
}
