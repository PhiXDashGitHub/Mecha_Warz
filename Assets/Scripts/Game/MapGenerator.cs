using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [Header("Preferences")]
    public Vector2 mapSize;
    public float tileSize;
    public float townDistance;

    [Header("Tiles")]
    public GameObject mainTown;
    public GameObject[] otherTowns;

    [Header("Noise")]
    [Range(10, 1000)]
    public float noiseScale;
    [Range(0, 1)]
    public float noiseWeight;
    [Range(0, 1)]
    public float noiseContrast;

    void Start() 
    {
        //Generate Main Town
        GameObject mainTownInstance = Instantiate<GameObject>(mainTown, transform);
        mainTownInstance.transform.position = Vector3.zero;

        //Generate other Towns
        for (int i = 0; i < otherTowns.Length; i++)
        {
            GameObject otherTownInstance = Instantiate<GameObject>(otherTowns[i], transform);
            Vector3 randPos = new Vector3(UnityEngine.Random.Range(-townDistance, townDistance), 0, UnityEngine.Random.Range(-townDistance, townDistance));
            otherTownInstance.transform.position = mainTownInstance.transform.position + randPos;
        }
    }

    Texture2D GenerateNoiseTexture(int width, int height)
    {
        Texture2D result = new Texture2D(width * 2, height * 2);

        for (int x = 0; x < width * 2; x++)
        {
            for (int y = 0; y < height * 2; y++)
            {
                float xCoord = (float)x / width * noiseScale;
                float yCoord = (float)y / height * noiseScale;

                float noise = Mathf.PerlinNoise(xCoord, yCoord);

                noise += (0.5f - noise) * (1 - noiseContrast);
                noise += (1 - noise) * (1 - noiseWeight);

                Color col = new Color(noise, noise, noise);

                result.SetPixel(x, y, col);
            }
        }

        result.Apply();
        return result;
    }
}
