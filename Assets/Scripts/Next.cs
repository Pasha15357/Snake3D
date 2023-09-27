using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel1;
    public GameObject panel2;

    public void nextGame()
    {
        panel.SetActive(false);
        panel1.SetActive(true);
        panel2.SetActive(true);
        Time.timeScale = 1f;
    }
}
