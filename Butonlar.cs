using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Butonlar : MonoBehaviour
{
    public string sceneName; // Y�klenecek sahnenin ad�
    public string sceneName2; // Y�klenecek sahnenin ad�
    public Button button; // Sahne ge�i�ini tetikleyecek d��me
    public Button button2;
    public AudioClip buttonSound; // Buttona bas�ld���nda �al�nacak ses dosyas�
    public AudioClip buttonSound2; // Buttona bas�ld���nda �al�nacak ses dosyas�
    private AudioSource audioSource; // Ses kayna��

    public void Cikis()
    {
        Application.Quit();
    }

    void Start()
    {
        // D��meye t�klan�nca LoadSceneOnClick fonksiyonunu �a��r
        button.onClick.AddListener(LoadSceneOnClick);
        // D��meye t�klan�nca LoadSceneOnClick fonksiyonunu �a��r
        button2.onClick.AddListener(LoadSceneOnClick2);

        // Ses kayna��n� al
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // E�er AudioSource bile�eni yoksa bir tane ekleyelim
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void LoadSceneOnClick()
    {
        // Button sesini �al
        if (buttonSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }

        // Sahne ge�i�ini yap
        SceneManager.LoadScene(sceneName);
    }
    public void LoadSceneOnClick2()
    {
        // Button sesini �al
        if (buttonSound2 != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonSound2);
        }

        // Sahne ge�i�ini yap
        SceneManager.LoadScene(sceneName2);
    }
    
}
