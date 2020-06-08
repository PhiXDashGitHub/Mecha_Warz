using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    //Stats
    public float maxHealth;
    private float health;
    public float maxMagicShield;
    private float magicShield;
    public float maxShield;
    private float shield;
    public float maxToughness;
    private float toughness;
    public float maxEnlightenment;
    private float enlightenment;
    public float maxenergy;
    public float energy;
    //Resistance
    public float fireResistance;
    public float waterResistance;
    public float iceResistance;
    public float electricResistance;
    public float piercingResistance;
    public float bludgeoningResistance;
    public float slashingResistance;
    public float poisonResistance;

    //Ui
    public GameObject healthSlider;

    void Start()
    {
        health = maxHealth;
        magicShield = maxMagicShield;
        shield = 1;

        StartCoroutine(RegenerateHealth());
        StartCoroutine(RegenerateMagicShield());
        StartCoroutine(RegenerateShield());

        healthSlider.GetComponent<Slider>().maxValue = maxHealth;
    }

    void Update()
    {
        //Clamp Values
        health = Mathf.Clamp(health, 0, maxHealth);
        magicShield = Mathf.Clamp(magicShield, 0, maxMagicShield);
        shield = Mathf.Clamp(shield, 0, 1);
        toughness = Mathf.Clamp(toughness, 0, 25);
        enlightenment = Mathf.Clamp(enlightenment, 0, 25);
        HealthSlider.GetComponent<Slider>().maxValue = maxHealth;
        HealthSlider.GetComponent<Slider>().value = health;


        healthSlider.GetComponent<Slider>().value = health;

    }

    IEnumerator RegenerateHealth()
    {
        if (health < maxHealth)
        {
            health++;
        }

        yield return new WaitForSeconds(3);
        StartCoroutine(RegenerateHealth());
    }

    IEnumerator RegenerateMagicShield()
    {
        if (magicShield < maxMagicShield)
        {
            magicShield++;
        }

        yield return new WaitForSeconds(3);
        StartCoroutine(RegenerateMagicShield());
    }

    IEnumerator RegenerateShield()
    {
        if (shield < 1)
        {
            shield = 1;
        }

        yield return new WaitForSeconds(10);
        StartCoroutine(RegenerateShield());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && other.GetComponent<Weapon>())
        {
            health -= other.GetComponent<Weapon>().Damage;
            Destroy(other.gameObject);
        }
    }
}
