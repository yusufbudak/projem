using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResetter : MonoBehaviour
{
    // Sahne yüklendiðinde otomatik olarak çaðrýlýr
    void Start()
    {
        ResetGame(); // Oyun durumunu sýfýrla
    }

    // Oyun durumunu sýfýrlama fonksiyonu
    void ResetGame()
    {
        PlayerPrefs.DeleteKey("Score"); // Skoru sýfýrla
        PlayerPrefs.DeleteKey("Dusman"); // Düþman sayýsýný sýfýrla veya isteðe baðlý olarak sýfýrlamayabilirsiniz
    }
}
