using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccludeTiles : MonoBehaviour
{
    public float occludeRange;
    public Transform map;

    void Update()
    {
        for (int i = 0; i < map.childCount; i++)
        {
            map.GetChild(i).gameObject.SetActive(Vector3.Distance(transform.position, map.GetChild(i).position) < occludeRange);
        }
    }
}
