using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    private int highScore = 0;

    void Start()
    {
        // Kaydedilmiþ en yüksek skoru yükle
        LoadHighScore();

        // En yüksek skoru ekrana yazdýr
        UpdateHighScoreText();
    }

    // En yüksek skoru yükleme fonksiyonu
    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // En yüksek skoru kaydetme fonksiyonu
    public void SaveHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            UpdateHighScoreText();
        }
    }

    // En yüksek skoru ekrana yazdýrma fonksiyonu
    void UpdateHighScoreText()
    {
        highScoreText.text = "En Yüksek Skor: " + highScore.ToString();
    }
}
