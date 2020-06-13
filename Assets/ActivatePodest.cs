using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePodest : MonoBehaviour
{
    public GameObject parent;

    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(parent.activeSelf);
        }
    }
}
