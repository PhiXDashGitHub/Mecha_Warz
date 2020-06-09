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

    //UI
    public Slider healthSlider;
    public Slider magicShieldSlider;

    void Start()
    {
        maxHealth = PlayerPrefs.GetFloat(gameObject.name + "MaxHealth");
        maxMagicShield = PlayerPrefs.GetFloat(gameObject.name + "MaxMagicShield");
        maxShield = PlayerPrefs.GetFloat(gameObject.name + "MaxShield");
        maxToughness = PlayerPrefs.GetFloat(gameObject.name + "MaxToughness");
        maxEnlightenment = PlayerPrefs.GetFloat(gameObject.name + "MaxEnlightenment");
        maxenergy = PlayerPrefs.GetFloat(gameObject.name + "MaxEnergy");
        fireResistance = PlayerPrefs.GetFloat(gameObject.name + "FireResistance");
        waterResistance = PlayerPrefs.GetFloat(gameObject.name + "WaterResistance");
        iceResistance = PlayerPrefs.GetFloat(gameObject.name + "IceResistance");
        electricResistance = PlayerPrefs.GetFloat(gameObject.name + "ElectricResistance");
        piercingResistance = PlayerPrefs.GetFloat(gameObject.name + "PiercingResistance");
        bludgeoningResistance = PlayerPrefs.GetFloat(gameObject.name + "BludgeoningResistance");
        slashingResistance = PlayerPrefs.GetFloat(gameObject.name + "SlashingResistance");
        poisonResistance = PlayerPrefs.GetFloat(gameObject.name + "PoisonResistance");

        health = maxHealth;
        magicShield = maxMagicShield;
        shield = 1;

        StartCoroutine(RegenerateHealth());
        StartCoroutine(RegenerateMagicShield());
        StartCoroutine(RegenerateShield());

        healthSlider.maxValue = maxHealth;
        magicShieldSlider.maxValue = maxMagicShield;
    }

    void Update()
    {
        //Clamp Values
        health = Mathf.Clamp(health, 0, maxHealth);
        magicShield = Mathf.Clamp(magicShield, 0, maxMagicShield);
        shield = Mathf.Clamp(shield, 0, 1);
        toughness = Mathf.Clamp(toughness, 0, 25);
        enlightenment = Mathf.Clamp(enlightenment, 0, 25);

        //Set UI
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
        magicShieldSlider.maxValue = maxMagicShield;
        magicShieldSlider.value = magicShield;

        if (health <= 0)
        {
            Dead();
        }
    }

    public void GetHurt(float damage)
    {
        float actualDamage = damage * (1.5f - magicShield / 100);
        Debug.Log(actualDamage);
        magicShield -= damage;

        health -= actualDamage;
    }

    public void Dead()
    {
        GetComponent<PlayerMovement>().enabled = false;
        FindObjectOfType<TurretControl>().enabled = false;
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
            GetHurt(other.GetComponent<Weapon>().Damage);
            Destroy(other.gameObject);
        }
    }
}
