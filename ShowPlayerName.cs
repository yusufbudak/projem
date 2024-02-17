using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPlayerName : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;

    void Start()
    {
        // PlayerPrefs'ten oyuncu ad�n� al
        string playerName = PlayerPrefs.GetString("PlayerName", "");

        // Metin alan�n�n i�eri�ini oyuncu ad�yla g�ncelle
        playerNameText.text = "" + playerName;
    }
}
