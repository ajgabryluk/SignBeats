using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PauseGame : MonoBehaviour
{
    public AudioSource music;
    public GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        music.Pause();
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        music.Play();
        Time.timeScale = 1f;
    }
}
