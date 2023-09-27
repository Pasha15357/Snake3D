using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class Menu : MonoBehaviour
{
    

    public void OnPlayHandler()
    {
        
        SceneManager.LoadScene(1);
    }

    public void OnExitHandler()
    {
        Application.Quit();
    }

    public void OpenHelpFiles()
    {
        string pathToHelpFile = "F:\\�����\\6 �������\\!��������\\������\\�������\\NewProject.chm";
        Process.Start(pathToHelpFile);
    }
}
