using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI dusmanText;
    public TextMeshProUGUI nextSceneInfoText;
    private int score = 0;
    private int dusman = 0;
    public int nextLevelScoreThreshold = 10; // Bir sonraki a�amaya ge�mek i�in gereken puan e�i�i

    void Start()
    {
        // Skoru s�f�rla
        ResetGame();

        // Skoru s�f�rla
        score = 0;
        // EnemyAI scriptindeki onEnemyDestroyed olay�na abone ol
        EnemyAI.onEnemyDestroyed += IncreaseScore;
        // EnemyAI scriptindeki onEnemyDestroyed olay�na abone ol
        EnemyAI.onEnemyDestroyed += IncreaseDusman;

        // Skoru g�ncelle
        UpdateScore();
    }

    // Oyun durumunu s�f�rlama fonksiyonu
    public void ResetGame()
    {
        score = 0;
        dusman = 0;
        UpdateScore();
        UpdateDusman();
    }

    void OnDestroy()
    {
        // Oyun sona erdi�inde skoru kaydet
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }



    // Puan� art�ran fonksiyon
    void IncreaseScore()
    {
        score += 150;
        // Puan� g�ncelle
        UpdateScore();
        // Puan belirli bir e�i�i ge�ti�inde bir sonraki a�amaya ge�
        CheckNextLevel();
    }

    void IncreaseDusman()
    {
        dusman += 1;
        // Puan� g�ncelle
        UpdateDusman();
    }

    // Puan� g�ncelleme fonksiyonu
    void UpdateScore()
    {
        scoreText.text = "" + score.ToString();
    }

    void UpdateDusman()
    {
        dusmanText.text = "" + dusman.ToString();
    }

    // Bir sonraki a�amaya ge�me kontrol�
    void CheckNextLevel()
    {
        if (dusman == nextLevelScoreThreshold)
        {
            // Belirli bir puana ula��ld���nda bir sonraki a�amaya ge�
            NextLevelWithDelay();
        }
    }

    // Belirli bir puana ula��ld���nda bir sonraki a�amaya ge�me fonksiyonu
    void NextLevelWithDelay()
    {
        // UI'da belirli bir puan e�i�ine ula��ld���n� g�ster
        nextSceneInfoText.text = "***TEBR�KLER BA�ARDIN***\nG�K VATAN G�VENDE\nYEN� G�REV�N Y�KLEN�YOR...";

        // 10 saniye sonra bir sonraki sahneyi y�kle
        Invoke("LoadNextScene", 10f);
    }

    // Bir sonraki sahneyi y�kleme fonksiyonu
    void LoadNextScene()
    {
        // Bir sonraki sahneyi y�kle
        SceneManager.LoadScene("gorev2txt");
    }
}