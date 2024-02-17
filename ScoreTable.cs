using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTable : MonoBehaviour
{
    public TextMeshProUGUI scoreTableText; // Skor tablosunun metin alaný

    void Start()
    {
        // Skor tablosunu baþlatýrken, PlayerPrefs'ten skoru alýn
        int savedScore = PlayerPrefs.GetInt("Score", 0);

        // Skor tablosu metin alanýný güncelle
        scoreTableText.text = "En Yüksek Skor: " + savedScore.ToString();
    }
}
