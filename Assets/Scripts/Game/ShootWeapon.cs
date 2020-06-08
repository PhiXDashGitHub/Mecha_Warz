using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootWeapon : MonoBehaviour
{
    private float Energy, MaxEnergy;
    public GameObject weapon, weapon2;
    public bool isautomatic1,isautomatic2;
    public Slider energyslider;

    public void Start()
    {
        energyslider.maxValue = MaxEnergy;
        Energy = this.GetComponent<PlayerCharacter>().energy;
        MaxEnergy = this.GetComponent<PlayerCharacter>().maxenergy;
    }

    void Update()
    {
        energyslider.value = Energy;
        this.GetComponent<PlayerCharacter>().energy = Energy;
        this.GetComponent<PlayerCharacter>().maxenergy = MaxEnergy;

        if (isautomatic1 && Energy > 0)
        {
            if (Input.GetMouseButton(0))
            {
                weapon.SetActive(true);
                Energy -= Time.deltaTime*2;
            }
            else
            {
                weapon.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(1) && Energy > 10)
        {
            weapon2.GetComponent<ParticleSystem>().Play();
            Energy -= 10;
        }
        else
        {
            weapon2.GetComponent<ParticleSystem>().Stop();
        }

        if (Energy < MaxEnergy)
        {
            Energy += Time.deltaTime;
        }
    }
}
