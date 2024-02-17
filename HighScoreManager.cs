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
        // Kaydedilmi� en y�ksek skoru y�kle
        LoadHighScore();

        // En y�ksek skoru ekrana yazd�r
        UpdateHighScoreText();
    }

    // En y�ksek skoru y�kleme fonksiyonu
    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // En y�ksek skoru kaydetme fonksiyonu
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

    // En y�ksek skoru ekrana yazd�rma fonksiyonu
    void UpdateHighScoreText()
    {
        highScoreText.text = "En Y�ksek Skor: " + highScore.ToString();
    }
}
