using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Zaman : MonoBehaviour
{
    public TextMeshProUGUI zaman;
    public TextMeshProUGUI zamanText;
    public string endGameMessage = "Time is up!"; // Oyunun bitiþ mesajý
    public string sceneToLoad = "MainMenu"; // Yüklenecek sahne
    public float timeToShowMessage = 5f; // Mesajýn ekranda kalma süresi
    public float delayBeforeLoading = 5f; // Yükleme öncesi gecikme süresi

    public float zamanSayaci = 400f; // Baþlangýç süresi
    private bool gameEnded = false; // Oyunun bitip bitmediðini kontrol etmek için

    void Update()
    {
        // Oyun bitmediyse ve zaman sýfýrdan büyükse
        if (!gameEnded && zamanSayaci > 0)
        {
            zamanSayaci -= Time.deltaTime; // Zamaný azalt
            zaman.text = Mathf.RoundToInt(zamanSayaci).ToString(); // Zamaný ekrana yaz
        }
        else if (!gameEnded) // Zaman sýfýr oldu ve oyun henüz bitmediyse
        {
            zamanText.text = "0"; // Zamaný sýfýr olarak göster
            EndGame(); // Oyunu bitir
        }
    }

    // Oyunun bitirilmesi için
    void EndGame()
    {
        gameEnded = true; // Oyunun bittiðini belirt
        zamanText.text = endGameMessage; // Bitiþ mesajýný ekranda göster

        // Belirli bir süre sonra belirlediðiniz sahneyi yükle
        Invoke("LoadSceneWithDelay", delayBeforeLoading);
    }

    // Gecikmeli olarak sahneyi yükleyen fonksiyon
    void LoadSceneWithDelay()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
