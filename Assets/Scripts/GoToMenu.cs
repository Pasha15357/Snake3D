using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    public void OnPlayHandler()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
