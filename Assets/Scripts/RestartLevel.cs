using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    public void Restart()
    {
        panel1.SetActive(true);
        panel2.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1f;
    }
    
}
