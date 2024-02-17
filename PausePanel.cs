using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionsPanel;
    public GameObject optionsPanel1;

    void Update()
    {



        // Esc tuþuna basýldýðýnda oyunu duraklat veya devam ettir
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    void PauseGame()
    {
        // Oyunu duraklat
        Time.timeScale = 0f;
        // Pause menüsünü aktifleþtir
        pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        // Oyunu devam ettir
        Time.timeScale = 1f;
        // Pause menüsünü devre dýþý býrak
        pauseMenuUI.SetActive(false);
        // Options panelini gizle
        optionsPanel.SetActive(false);
    }

    public void OpenOptionsMenu()
    {
        // Options panelini aç
        optionsPanel.SetActive(true);
    }
    public void OpenOptionsMenu1()
    {
        // Options panelini aç
        optionsPanel1.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        // Oyunu devam ettir
        ResumeGame();
        // Ana menü sahnesine geri dön
        SceneManager.LoadScene("menu");
    }



    public void ToggleSound()
    {
        // Sesi kapat veya aç
        AudioListener.pause = !AudioListener.pause;
    }
    [SerializeField]
    private Toggle windowedToggle;


    public void WindowedToggle()
    {
        PlayerPrefs.SetInt("Windowed", windowedToggle.isOn ? 1 : 0);
        if (!windowedToggle.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    private void LoadWindowedToggle()
    {
        windowedToggle.isOn = PlayerPrefs.GetInt("Windowed") == 1;
    }
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Windowed"))
        {
            PlayerPrefs.SetInt("Windowed", 0);
        }
        else
        {
            LoadWindowedToggle();
        }

    }
    public Text volumeAmount;
    public void SetAudio(float value)
    {
        AudioListener.volume = value;
        volumeAmount.text = ((int)(value * 100)).ToString();
    }


}