using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pausemenu;
    FullScreenMode fullscreenmode = FullScreenMode.ExclusiveFullScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MainMenu")
        {
            Pausemenu.SetActive(true);
        }
    }

    public void Graphicsetting(int index)
    {
        if (index == 0)
        {
            Screen.SetResolution(960,540,fullscreenmode);
        }
        else if (index == 1)
        {
            Screen.SetResolution(1280, 720, fullscreenmode);
        }
        else
        {
            Screen.SetResolution(1920, 1080, fullscreenmode);
        }
    }
    public void Setfullscreenmode(int index)
    {
        if (index == 0)
        {
            fullscreenmode = FullScreenMode.Windowed;
        }
        else if (index == 1)
        {
            fullscreenmode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            fullscreenmode = FullScreenMode.ExclusiveFullScreen;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
