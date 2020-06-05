using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Vector2 mapSize;

    [Range(10, 1000)]
    public float noiseScale;
    [Range(0, 1)]
    public float noiseWeight;
    [Range(0, 1)]
    public float noiseContrast;

    void Start()
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.transform.SetParent(transform);

        ground.transform.localScale = new Vector3(mapSize.x, 1, mapSize.y);
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
