using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootWeaponRange : MonoBehaviour
{
    public GameObject Expolsion, Laser;
    public GameObject[] Gunparent;
    float Delay = 0;
    public Slider energyslider;
    public float Energy, MaxEnergy;

    public void Start()
    {
        energyslider.maxValue = MaxEnergy;
        Energy = this.GetComponent<PlayerCharacter>().energy;
        MaxEnergy = this.GetComponent<PlayerCharacter>().maxenergy;
    }

    void Update()
    {
        Energy = Mathf.Clamp(Energy, 0, MaxEnergy);
        energyslider.maxValue = MaxEnergy;
        energyslider.value = Energy;
        this.GetComponent<PlayerCharacter>().energy = Energy;
        this.GetComponent<PlayerCharacter>().maxenergy = MaxEnergy;

        if (Input.GetMouseButtonDown(1) && Energy > 5)
        {
            GameObject go = Instantiate(Expolsion, TurretControl.mousePos, Quaternion.identity);
            Destroy(go,1.5f);
            Energy -= 5;
        }
        if (Input.GetMouseButton(0) && Delay <= 0 && Energy > 1)
        {
            GameObject go = Instantiate(Laser, Gunparent[Random.Range(0,Gunparent.Length)].transform.position, Gunparent[Random.Range(0, Gunparent.Length)].transform.rotation);
            Destroy(go, 5f);
            Delay = Time.deltaTime * 10;
            Energy -= Time.deltaTime * 10f;
        }
        else
        {
            if (Delay > 0)
            {
                Delay -= Time.deltaTime;
            }
        }

        if (Energy < MaxEnergy)
        {
            Energy += Time.deltaTime;
        }
    }
}
