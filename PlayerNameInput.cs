using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    public InputField inputField; // Oyuncunun ismini girece�i InputField

    private void Start()
    {
        // Kay�tl� oyuncu ismini y�kle (e�er daha �nce kaydedilmi�se)
        string savedName = PlayerPrefs.GetString("PlayerName", ""); // Kaydedilmi� ismi al, yoksa bo� bir string d�nd�r�r
        inputField.text = savedName; // InputField'a kaydedilmi� ismi yaz
    }

    // Bu fonksiyon, "Save" butonuna ba�l� olmal� ve oyun i�inde �a�r�lmal�d�r
    public void SavePlayerName()
    {
        string playerName = inputField.text; // InputField'dan oyuncunun girdi�i ismi al

        // Oyuncu ismini kaydet
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
    }
}
