using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kotusenaryo : MonoBehaviour
{
    public GameObject objectToWatch; // Ýzlenecek obje
    public string messageToShow = "BAÞARISIZ OLDUN!\nBÝRAZDAN ANA MENÜYE YÖNLENDÝRÝLECEKSÝN..."; // Gösterilecek mesaj
    public TextMeshProUGUI messageText; // Gösterilecek metin
    public string sceneToLoad = "menu"; // Yüklenecek sahne
    public float delayBeforeLoading = 2f; // Yükleme öncesi gecikme süresi

    private bool sceneLoadingStarted = false; // Sahne yükleme baþlatýldý mý?

    private void Update()
    {
        // Eðer izlenen obje yoksa veya yok olduysa
        if (objectToWatch == null)
        {
            // Metni ekranda göster
            ShowMessage();

            // Sahne yükleme baþlatýlmadýysa
            if (!sceneLoadingStarted)
            {
                // Yükleme baþlat
                Invoke("LoadSceneWithDelay", delayBeforeLoading);
                sceneLoadingStarted = true;
            }
        }
    }

    // Metni ekranda gösteren fonksiyon
    void ShowMessage()
    {
        messageText.text = messageToShow;
    }

    // Gecikmeli olarak sahneyi yükleyen fonksiyon
    void LoadSceneWithDelay()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
