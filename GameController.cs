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
    public int nextLevelScoreThreshold = 10; // Bir sonraki aþamaya geçmek için gereken puan eþiði

    void Start()
    {
        // Skoru sýfýrla
        ResetGame();

        // Skoru sýfýrla
        score = 0;
        // EnemyAI scriptindeki onEnemyDestroyed olayýna abone ol
        EnemyAI.onEnemyDestroyed += IncreaseScore;
        // EnemyAI scriptindeki onEnemyDestroyed olayýna abone ol
        EnemyAI.onEnemyDestroyed += IncreaseDusman;

        // Skoru güncelle
        UpdateScore();
    }

    // Oyun durumunu sýfýrlama fonksiyonu
    public void ResetGame()
    {
        score = 0;
        dusman = 0;
        UpdateScore();
        UpdateDusman();
    }

    void OnDestroy()
    {
        // Oyun sona erdiðinde skoru kaydet
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }



    // Puaný artýran fonksiyon
    void IncreaseScore()
    {
        score += 150;
        // Puaný güncelle
        UpdateScore();
        // Puan belirli bir eþiði geçtiðinde bir sonraki aþamaya geç
        CheckNextLevel();
    }

    void IncreaseDusman()
    {
        dusman += 1;
        // Puaný güncelle
        UpdateDusman();
    }

    // Puaný güncelleme fonksiyonu
    void UpdateScore()
    {
        scoreText.text = "" + score.ToString();
    }

    void UpdateDusman()
    {
        dusmanText.text = "" + dusman.ToString();
    }

    // Bir sonraki aþamaya geçme kontrolü
    void CheckNextLevel()
    {
        if (dusman == nextLevelScoreThreshold)
        {
            // Belirli bir puana ulaþýldýðýnda bir sonraki aþamaya geç
            NextLevelWithDelay();
        }
    }

    // Belirli bir puana ulaþýldýðýnda bir sonraki aþamaya geçme fonksiyonu
    void NextLevelWithDelay()
    {
        // UI'da belirli bir puan eþiðine ulaþýldýðýný göster
        nextSceneInfoText.text = "***TEBRÝKLER BAÞARDIN***\nGÖK VATAN GÜVENDE\nYENÝ GÖREVÝN YÜKLENÝYOR...";

        // 10 saniye sonra bir sonraki sahneyi yükle
        Invoke("LoadNextScene", 10f);
    }

    // Bir sonraki sahneyi yükleme fonksiyonu
    void LoadNextScene()
    {
        // Bir sonraki sahneyi yükle
        SceneManager.LoadScene("gorev2txt");
    }
}