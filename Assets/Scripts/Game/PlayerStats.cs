using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    PlayerCharacter character;
    public Slider magicMeter;
    public TextMeshProUGUI levelMeter;
    public SkinnedMeshRenderer meshRenderer;

    public int magic;
    public int level;
    public int progressionLevel;

    public int magicToLevelUp;

    void Awake()
    {
        character = GetComponent<PlayerCharacter>();
    }

    void Start()
    {
        magic = PlayerPrefs.GetInt(gameObject.name + "Magic");
        level = PlayerPrefs.GetInt(gameObject.name + "Level");
        progressionLevel = PlayerPrefs.GetInt(gameObject.name + "ProgressionLevel");

        Color col = new Color();

        col.r = (float)Convert.ToDouble(PlayerPrefs.GetString("CharColor" + PlayerPrefsX.GetStringArray("CharNames")[PlayerPrefs.GetInt("SaveState")]).Split(':')[0]);
        col.g = (float)Convert.ToDouble(PlayerPrefs.GetString("CharColor" + PlayerPrefsX.GetStringArray("CharNames")[PlayerPrefs.GetInt("SaveState")]).Split(':')[1]);
        col.b = (float)Convert.ToDouble(PlayerPrefs.GetString("CharColor" + PlayerPrefsX.GetStringArray("CharNames")[PlayerPrefs.GetInt("SaveState")]).Split(':')[2]);
        col.a = (float)Convert.ToDouble(PlayerPrefs.GetString("CharColor" + PlayerPrefsX.GetStringArray("CharNames")[PlayerPrefs.GetInt("SaveState")]).Split(':')[3]);

        var block = new MaterialPropertyBlock();

        block.SetColor("_BaseColor", col);
        meshRenderer.SetPropertyBlock(block);
    }

    void Update()
    {
        //Clamp Values
        level = Mathf.Clamp(level, 1, 100);
        progressionLevel = Mathf.Clamp(progressionLevel, 0, 3);

        //Character Stats
        character.maxHealth = 100 + (level / 2);
        character.maxMagicShield = 100 + (level / 2);
        character.maxShield = 4 + (level / 10);
        character.maxToughness = (level / 4) + 10 * progressionLevel;
        character.maxEnlightenment = (level / 4) + 10 * progressionLevel;

        //Character Resistance
        character.fireResistance = progressionLevel / 4.0f;
        character.waterResistance = progressionLevel / 4.0f;
        character.iceResistance = progressionLevel / 4.0f;
        character.electricResistance = progressionLevel / 4.0f;
        character.piercingResistance = progressionLevel / 4.0f;
        character.bludgeoningResistance = progressionLevel / 4.0f;
        character.slashingResistance = progressionLevel / 4.0f;
        character.poisonResistance = progressionLevel / 4.0f;

        //Magic & Level
        if (magic >= magicToLevelUp)
        {
            level++;
            magic -= magicToLevelUp;
        }

        //UI
        magicMeter.maxValue = magicToLevelUp;
        magicMeter.value = magic;
        levelMeter.text = level.ToString();

        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveVariables();
        }
    }

    public void AddMagic(int amount)
    {
        magic += amount;
    }

    public void SaveVariables()
    {
        PlayerPrefs.SetInt(gameObject.name + "Magic", magic);
        PlayerPrefs.SetInt(gameObject.name + "Level", level);
        PlayerPrefs.SetInt(gameObject.name + "ProgressionLevel", progressionLevel);
    }
}
