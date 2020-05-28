using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    PlayerCharacter character;

    public int level;
    public int progressionLevel;

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
        character.fireResistance = progressionLevel / 4;
        character.waterResistance = progressionLevel / 4;
        character.iceResistance = progressionLevel / 4;
        character.electricResistance = progressionLevel / 4;
        character.piercingResistance = progressionLevel / 4;
        character.bludgeoningResistance = progressionLevel / 4;
        character.slashingResistance = progressionLevel / 4;
        character.poisonResistance = progressionLevel / 4;
    }
}
