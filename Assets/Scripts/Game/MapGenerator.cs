using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Tilemap tileMap;
    public TileBase testGround;

    public Transform grid;
    public BoxCollider2D mapBounds;

    [Range(10, 1000)]
    public float noiseScale;
    [Range(0, 1)]
    public float noiseWeight;
    [Range(0, 1)]
    public float noiseContrast;

    void Start()
    {
        grid.position = Vector3.right * mapBounds.size.x / 2 + Vector3.up * mapBounds.size.y / 2;
        tileMap.BoxFill(Vector3Int.CeilToInt(transform.position + Vector3.left * mapBounds.size.x + Vector3.down * mapBounds.size.y), testGround, (int)-mapBounds.size.x, (int)-mapBounds.size.y, (int)mapBounds.size.x, (int)mapBounds.size.y);

        AddMapVariation();
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

    public void AddMapVariation()
    {
        Texture2D noiseTexture = GenerateNoiseTexture((int)mapBounds.size.x, (int)mapBounds.size.y);

        for (int x = -tileMap.size.x; x < tileMap.size.x; x++)
        {
            for (int y = -tileMap.size.y; y < tileMap.size.y; y++)
            {
                Vector3Int pos = tileMap.WorldToCell(new Vector3(x, y, 0));
                tileMap.SetTileFlags(pos, TileFlags.None);

                Color col = tileMap.GetColor(pos);
                Color.RGBToHSV(col, out float hue, out float sat, out float val);

                val = noiseTexture.GetPixel(x + tileMap.size.x, y + tileMap.size.y).grayscale;

                col = Color.HSVToRGB(hue, sat, val);
                tileMap.SetColor(pos, col);
            }
        }
    }
}
