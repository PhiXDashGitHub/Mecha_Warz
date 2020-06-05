using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Slider Colorslider;
    public GameObject Colorsliderfill;
    public GameObject[] Mechs3D;
    public static Color mechcolor;

    public void Update()
    {
        mechcolor = Color.HSVToRGB(Colorslider.value, 1, 1);
        Colorsliderfill.GetComponent<Image>().color = mechcolor;
        Debug.Log(mechcolor.ToString());

        for (int i = 0; i< Mechs3D.Length;i++)
        {
            if (Mechs3D[i].activeSelf)
            {
                Mechs3D[i].GetComponent<SkinnedMeshRenderer>().material.color = mechcolor;
            }
        }
    }
}
