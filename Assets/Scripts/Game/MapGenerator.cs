using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [Header("Preferences")]
    public Vector2 mapSize;
    public int tileSize;
    public int townDistance;

    [Header("Tiles")]
    public GameObject mainTown;
    public GameObject[] otherTowns;
    public GameObject[] grassTiles;

    List<Vector3> otherTownPos;

    [Header("Noise")]
    [Range(10, 1000)]
    public float noiseScale;
    [Range(0, 1)]
    public float noiseWeight;
    [Range(0, 1)]
    public float noiseContrast;

    void Start() 
    {
        otherTownPos = new List<Vector3>();

        //Generate Grass Tiles
        for (float x = -mapSize.x; x < mapSize.x + tileSize; x += tileSize)
        {
            for (float z = -mapSize.y; z < mapSize.y + tileSize; z += tileSize)
            {
                GameObject newTile = Instantiate(grassTiles[UnityEngine.Random.Range(0, grassTiles.Length)], transform);
                newTile.transform.position = new Vector3(x, 0, z);
            }
        }

        //Delete Random Tiles
        for (int i = 0; i < otherTowns.Length + 1; i++)
        {
            if (i == 0)
            {
                for (int c = 0; c < transform.childCount; c++)
                {
                    if (transform.GetChild(c).position == Vector3.zero)
                    {
                        Destroy(transform.GetChild(c).gameObject);
                    }
                }
            }
            else
            {
                Vector3 RandomPos = transform.GetChild(0).position;

                for (int p = 0; p < 1; p += 0)
                {
                    if (RandomPos.x == -mapSize.x || RandomPos.x == mapSize.x || RandomPos.z == -mapSize.y || RandomPos.z == mapSize.y)
                    {
                        RandomPos = transform.GetChild(UnityEngine.Random.Range(0, transform.childCount)).position;
                    }
                    else
                    {
                        if (otherTownPos.Count > 0)
                        {
                            for (int t = 0; t < otherTownPos.Count; t++)
                            {
                                if (RandomPos == otherTownPos[t] || Vector3.Distance(RandomPos, otherTownPos[t]) < townDistance)
                                {
                                    RandomPos = transform.GetChild(UnityEngine.Random.Range(0, transform.childCount)).position;
                                    break;
                                }
                                else
                                {
                                    if (t == otherTownPos.Count - 1)
                                    {
                                        otherTownPos.Add(RandomPos);
                                        p++;
                                    }
                                }
                            }
                        }
                        else
                        {
                            otherTownPos.Add(RandomPos);
                            break;
                        }
                    }
                }
            }
        }

        for (int i = 0; i < otherTownPos.Count; i++)
        {
            for (int c = 0; c < transform.childCount; c++)
            {
                if (otherTownPos[i] == transform.GetChild(c).position)
                {
                    Destroy(transform.GetChild(c).gameObject);
                }
            }
        }

        //Instantiate Towns
        for (int i = 0; i < otherTownPos.Count; i++)
        {
            if (otherTownPos[i] == Vector3.zero)
            {
                GameObject newTown = Instantiate(mainTown, transform);
                newTown.transform.position = Vector3.zero;
                otherTownPos.RemoveAt(i);
                break;
            }
        }

        for (int i = 0; i < otherTowns.Length; i++)
        {
            GameObject newTown = Instantiate(otherTowns[i], transform);
            newTown.transform.position = otherTownPos[i];
        }

        GameObject newTown2 = Instantiate(mainTown, transform);
        newTown2.transform.position = Vector3.zero;
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

    Vector3 RandomVector()
    {
        float random = UnityEngine.Random.Range(0, 8);

        if (random == 0)
        {
            return Vector3.forward;
        }
        else if (random == 1)
        {
            return Vector3.back;
        }
        else if (random == 2)
        {
            return Vector3.right;
        }
        else if (random == 3)
        {
            return Vector3.left;
        }
        else if (random == 4)
        {
            return Vector3.forward + Vector3.right;
        }
        else if (random == 5)
        {
            return Vector3.forward + Vector3.left;
        }
        else if (random == 6)
        {
            return Vector3.back + Vector3.right;
        }
        else if (random == 7)
        {
            return Vector3.back + Vector3.left;
        }

        return Vector3.zero;
    }
}
