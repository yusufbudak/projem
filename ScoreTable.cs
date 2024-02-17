using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTable : MonoBehaviour
{
    public TextMeshProUGUI scoreTableText; // Skor tablosunun metin alan�

    void Start()
    {
        // Skor tablosunu ba�lat�rken, PlayerPrefs'ten skoru al�n
        int savedScore = PlayerPrefs.GetInt("Score", 0);

        // Skor tablosu metin alan�n� g�ncelle
        scoreTableText.text = "En Y�ksek Skor: " + savedScore.ToString();
    }
}
