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
    public string endGameMessage = "Time is up!"; // Oyunun biti� mesaj�
    public string sceneToLoad = "MainMenu"; // Y�klenecek sahne
    public float timeToShowMessage = 5f; // Mesaj�n ekranda kalma s�resi
    public float delayBeforeLoading = 5f; // Y�kleme �ncesi gecikme s�resi

    public float zamanSayaci = 400f; // Ba�lang�� s�resi
    private bool gameEnded = false; // Oyunun bitip bitmedi�ini kontrol etmek i�in

    void Update()
    {
        // Oyun bitmediyse ve zaman s�f�rdan b�y�kse
        if (!gameEnded && zamanSayaci > 0)
        {
            zamanSayaci -= Time.deltaTime; // Zaman� azalt
            zaman.text = Mathf.RoundToInt(zamanSayaci).ToString(); // Zaman� ekrana yaz
        }
        else if (!gameEnded) // Zaman s�f�r oldu ve oyun hen�z bitmediyse
        {
            zamanText.text = "0"; // Zaman� s�f�r olarak g�ster
            EndGame(); // Oyunu bitir
        }
    }

    // Oyunun bitirilmesi i�in
    void EndGame()
    {
        gameEnded = true; // Oyunun bitti�ini belirt
        zamanText.text = endGameMessage; // Biti� mesaj�n� ekranda g�ster

        // Belirli bir s�re sonra belirledi�iniz sahneyi y�kle
        Invoke("LoadSceneWithDelay", delayBeforeLoading);
    }

    // Gecikmeli olarak sahneyi y�kleyen fonksiyon
    void LoadSceneWithDelay()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
