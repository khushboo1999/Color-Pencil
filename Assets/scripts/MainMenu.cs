using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject QuitPanel;
    public GameObject SettingsPanel;
    
    public GameObject musicOff;
    public GameObject soundOff;

    private void Start()
    {
        
        if (!AudioManager.instance.Sound().isActiveAndEnabled)
            soundOff.SetActive(true);
        else soundOff.SetActive(false);

        if (!AudioManager.instance.Music().isActiveAndEnabled)
            musicOff.SetActive(true);
        else musicOff.SetActive(false);
    }

    
    public void Classic()
    {
        gameManager.instance.FadeToLevel(1);

    }

    public void Challenge()
    {
        gameManager.instance.FadeToLevel(2);

    }

    public void Quit(string ButtonName)
    {
        QuitPanel.SetActive(!QuitPanel.activeSelf);

        if (ButtonName =="yes")
        {
            Debug.Log("quitting...");
            Application.Quit();
        }

        if (ButtonName == "no")
        {
            QuitPanel.SetActive(false);
        }


    }

    public void Settings(string ButtonName)
    {
        SettingsPanel.SetActive(!SettingsPanel.activeSelf);

        if (ButtonName == "music")
        {
            musicOff.SetActive(!musicOff.activeSelf);
            AudioManager.instance.Music().enabled = !AudioManager.instance.Music().isActiveAndEnabled;
        }


        if (ButtonName == "sound")
        {
            AudioManager.instance.Sound().enabled = !AudioManager.instance.Sound().isActiveAndEnabled;
           soundOff.SetActive(!soundOff.activeSelf);
        }

    }

    public void Shop()
    {
        gameManager.instance.FadeToLevel(4);
    }
}
