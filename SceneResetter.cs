using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResetter : MonoBehaviour
{
    // Sahne y�klendi�inde otomatik olarak �a�r�l�r
    void Start()
    {
        ResetGame(); // Oyun durumunu s�f�rla
    }

    // Oyun durumunu s�f�rlama fonksiyonu
    void ResetGame()
    {
        PlayerPrefs.DeleteKey("Score"); // Skoru s�f�rla
        PlayerPrefs.DeleteKey("Dusman"); // D��man say�s�n� s�f�rla veya iste�e ba�l� olarak s�f�rlamayabilirsiniz
    }
}
