using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kotusenaryo : MonoBehaviour
{
    public GameObject objectToWatch; // �zlenecek obje
    public string messageToShow = "BA�ARISIZ OLDUN!\nB�RAZDAN ANA MEN�YE Y�NLEND�R�LECEKS�N..."; // G�sterilecek mesaj
    public TextMeshProUGUI messageText; // G�sterilecek metin
    public string sceneToLoad = "menu"; // Y�klenecek sahne
    public float delayBeforeLoading = 2f; // Y�kleme �ncesi gecikme s�resi

    private bool sceneLoadingStarted = false; // Sahne y�kleme ba�lat�ld� m�?

    private void Update()
    {
        // E�er izlenen obje yoksa veya yok olduysa
        if (objectToWatch == null)
        {
            // Metni ekranda g�ster
            ShowMessage();

            // Sahne y�kleme ba�lat�lmad�ysa
            if (!sceneLoadingStarted)
            {
                // Y�kleme ba�lat
                Invoke("LoadSceneWithDelay", delayBeforeLoading);
                sceneLoadingStarted = true;
            }
        }
    }

    // Metni ekranda g�steren fonksiyon
    void ShowMessage()
    {
        messageText.text = messageToShow;
    }

    // Gecikmeli olarak sahneyi y�kleyen fonksiyon
    void LoadSceneWithDelay()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
