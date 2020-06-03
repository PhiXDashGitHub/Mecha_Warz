using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Tilemap tileMap;
    public TileBase testGround;

    public Transform grid;
    public BoxCollider2D mapBounds;

    void Start()
    {
        grid.position = Vector3.right * mapBounds.size.x / 2 + Vector3.up * mapBounds.size.y / 2;
        tileMap.BoxFill(Vector3Int.CeilToInt(transform.position + Vector3.left * mapBounds.size.x + Vector3.down * mapBounds.size.y), testGround, (int)-mapBounds.size.x, (int)-mapBounds.size.y, (int)mapBounds.size.x, (int)mapBounds.size.y);

        for (int x = 0; x < tileMap.size.x; x++)
        {
            for (int y = 0; y < tileMap.size.y; y++)
            {
                Vector3Int pos = tileMap.WorldToCell(new Vector3(x, y, 0));
            }
        }
    }
}
