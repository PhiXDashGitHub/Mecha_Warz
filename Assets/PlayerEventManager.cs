using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    public GameObject playerEvent;

    public void AddEvent(string text, Color color)
    {
        GameObject playerEventInstance = Instantiate(playerEvent, transform);
        playerEventInstance.GetComponentInChildren<TextMeshProUGUI>().color = color;
        playerEventInstance.GetComponentInChildren<TextMeshProUGUI>().text = text;
        Destroy(playerEventInstance, 1);
    }
}
