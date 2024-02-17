using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ObjectDeleter : MonoBehaviour
{
    // Objeleri sýrayla silmek için dizi ve indis
    public GameObject[] objectsToDelete;
    private int currentIndex = 0;
    public float delayBeforeNextScene = 10f;


    // TextMeshPro metin ögesi referansý
    public TextMeshProUGUI objectCountText;
    public TextMeshProUGUI gameOverText;

    void Start()
    {
        // Baþlangýçta dizideki ilk objeyi silelim
        DeleteNextObject();
    }

    // Bir sonraki objeyi silen fonksiyon
    public void DeleteNextObject()
    {
        if (currentIndex < objectsToDelete.Length)
        {
            Destroy(objectsToDelete[currentIndex]);
            currentIndex++;

            // Objelerin sayýsýný güncelle
            UpdateObjectCount();
        }
        else
        {
            // Oyun bittiðinde metni göster ve oyunu durdur
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0f; // Oyunu durdur

            Debug.Log("Silinecek obje kalmadý. Oyun bitti.");
        }
    }

    // Objelerin sayýsýný güncelleyen fonksiyon
    private void UpdateObjectCount()
    {
        // Kalan obje sayýsýný güncelle
        int remainingObjects = objectsToDelete.Length - currentIndex;
        objectCountText.text = "" + remainingObjects.ToString();
    }


}
