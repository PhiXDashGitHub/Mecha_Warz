using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameObject DeathScreen;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI magicShieldText;

    void Awake()
    {
        gameObject.name = PlayerPrefsX.GetStringArray("CharNames")[PlayerPrefs.GetInt("SaveState")].ToString();
    }

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

        StartCoroutine(Autosave());
    }

    void Update()
    {
        //Clamp Values
        health = Mathf.Clamp(health, 0, maxHealth);
        magicShield = Mathf.Clamp(magicShield, 0, maxMagicShield);
        shield = Mathf.Clamp(shield, 0, 1);
        toughness = Mathf.Clamp(toughness, 0, 25);
        enlightenment = Mathf.Clamp(enlightenment, 0, 25);
        energy = Mathf.Clamp(energy, 0, maxenergy);

        //Set UI
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
        magicShieldSlider.maxValue = maxMagicShield;
        magicShieldSlider.value = magicShield;
        healthText.text = health.ToString("000") + "/" + maxHealth.ToString("000");
        energyText.text = energy.ToString("000") + "/" + maxenergy.ToString("000");
        magicShieldText.text = magicShield.ToString("000") + "/" + maxMagicShield.ToString("000");

        if (health <= 0)
        {
            Dead();
        }

    }

    public IEnumerator Autosave()
    {
        SaveVariables();
        yield return new WaitForSeconds(3);
        StartCoroutine(Autosave());
    }

    public void GetHurt(float damage)
    {
        float actualDamage = damage * (1.5f - magicShield / 100);
        Debug.Log(actualDamage);
        magicShield -= damage;

        health -= actualDamage;
        FindObjectOfType<PlayerEventManager>().AddEvent("-" + damage, Color.red);
    }

    public void GetHealed(float heal)
    {
        health += heal;
        FindObjectOfType<PlayerEventManager>().AddEvent("+" + heal, Color.green);
    }

    public void Dead()
    {
        GetComponent<PlayerMovement>().enabled = false;
        FindObjectOfType<TurretControl>().enabled = false;
        DeathScreen.SetActive(true);
    }

    public void ReSpawn()
    {
        GetComponent<PlayerMovement>().enabled = true;
        FindObjectOfType<TurretControl>().enabled = true;
        health = maxHealth;
        maxShield = maxMagicShield;
        energy = maxenergy;
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

    public void SaveVariables()
    {
        PlayerPrefs.SetFloat(gameObject.name + "MaxHealth", maxHealth);
        PlayerPrefs.SetFloat(gameObject.name + "MaxMagicShield", maxMagicShield);
        PlayerPrefs.SetFloat(gameObject.name + "MaxShield", maxShield);
        PlayerPrefs.SetFloat(gameObject.name + "MaxToughness", maxToughness);
        PlayerPrefs.SetFloat(gameObject.name + "MaxEnlightenment", maxEnlightenment);
        PlayerPrefs.SetFloat(gameObject.name + "MaxEnergy", maxenergy);
        PlayerPrefs.SetFloat(gameObject.name + "FireResistance", fireResistance);
        PlayerPrefs.SetFloat(gameObject.name + "WaterResistance", waterResistance);
        PlayerPrefs.SetFloat(gameObject.name + "IceResistance", iceResistance);
        PlayerPrefs.SetFloat(gameObject.name + "ElectricResistance", electricResistance);
        PlayerPrefs.SetFloat(gameObject.name + "PiercingResistance", piercingResistance);
        PlayerPrefs.SetFloat(gameObject.name + "BludgeoningResistance", bludgeoningResistance);
        PlayerPrefs.SetFloat(gameObject.name + "SlashingResistance", slashingResistance);
        PlayerPrefs.SetFloat(gameObject.name + "PoisonResistance", poisonResistance);
    }
}
