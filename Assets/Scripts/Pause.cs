using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel1;
    public GameObject panel2;

    public void pause()
    {
        panel.SetActive(true);
        panel1.SetActive(false);
        panel2.SetActive(false);
        Time.timeScale = 0;
    }
}
