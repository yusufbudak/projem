using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Butonlar : MonoBehaviour
{
    public string sceneName; // Yüklenecek sahnenin adý
    public string sceneName2; // Yüklenecek sahnenin adý
    public Button button; // Sahne geçiþini tetikleyecek düðme
    public Button button2;
    public AudioClip buttonSound; // Buttona basýldýðýnda çalýnacak ses dosyasý
    public AudioClip buttonSound2; // Buttona basýldýðýnda çalýnacak ses dosyasý
    private AudioSource audioSource; // Ses kaynaðý

    public void Cikis()
    {
        Application.Quit();
    }

    void Start()
    {
        // Düðmeye týklanýnca LoadSceneOnClick fonksiyonunu çaðýr
        button.onClick.AddListener(LoadSceneOnClick);
        // Düðmeye týklanýnca LoadSceneOnClick fonksiyonunu çaðýr
        button2.onClick.AddListener(LoadSceneOnClick2);

        // Ses kaynaðýný al
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Eðer AudioSource bileþeni yoksa bir tane ekleyelim
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void LoadSceneOnClick()
    {
        // Button sesini çal
        if (buttonSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }

        // Sahne geçiþini yap
        SceneManager.LoadScene(sceneName);
    }
    public void LoadSceneOnClick2()
    {
        // Button sesini çal
        if (buttonSound2 != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonSound2);
        }

        // Sahne geçiþini yap
        SceneManager.LoadScene(sceneName2);
    }
    
}
