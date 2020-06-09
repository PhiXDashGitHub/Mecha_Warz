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

    public int magic;
    public int level;
    public int progressionLevel;

    public int magicToLevelUp;

    void Awake()
    {
        character = GetComponent<PlayerCharacter>();
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
    }

    public void AddMagic(int amount)
    {
        magic += amount;
    }
}
