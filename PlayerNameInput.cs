using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    public InputField inputField; // Oyuncunun ismini gireceði InputField

    private void Start()
    {
        // Kayýtlý oyuncu ismini yükle (eðer daha önce kaydedilmiþse)
        string savedName = PlayerPrefs.GetString("PlayerName", ""); // Kaydedilmiþ ismi al, yoksa boþ bir string döndürür
        inputField.text = savedName; // InputField'a kaydedilmiþ ismi yaz
    }

    // Bu fonksiyon, "Save" butonuna baðlý olmalý ve oyun içinde çaðrýlmalýdýr
    public void SavePlayerName()
    {
        string playerName = inputField.text; // InputField'dan oyuncunun girdiði ismi al

        // Oyuncu ismini kaydet
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
    }
}
