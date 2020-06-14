using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootWeaponHeal : MonoBehaviour
{
    public GameObject Laser,Heart;
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
            this.GetComponent<PlayerCharacter>().GetHealed(10);
            GameObject go = Instantiate(Heart, this.transform.position+ new Vector3(0,2,0),Quaternion.identity);
            Destroy(go, 5f);
            Energy -= 20;
        }
        if (Input.GetMouseButton(0) && Delay <= 0 && Energy > 1)
        {
            GameObject go = Instantiate(Laser, Gunparent[Random.Range(0, Gunparent.Length)].transform.position, Gunparent[Random.Range(0, Gunparent.Length)].transform.rotation);
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
