using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPlayerName : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;

    void Start()
    {
        // PlayerPrefs'ten oyuncu adýný al
        string playerName = PlayerPrefs.GetString("PlayerName", "");

        // Metin alanýnýn içeriðini oyuncu adýyla güncelle
        playerNameText.text = "" + playerName;
    }
}
