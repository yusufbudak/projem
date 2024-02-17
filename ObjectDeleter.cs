using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ObjectDeleter : MonoBehaviour
{
    // Objeleri s�rayla silmek i�in dizi ve indis
    public GameObject[] objectsToDelete;
    private int currentIndex = 0;
    public float delayBeforeNextScene = 10f;


    // TextMeshPro metin �gesi referans�
    public TextMeshProUGUI objectCountText;
    public TextMeshProUGUI gameOverText;

    void Start()
    {
        // Ba�lang��ta dizideki ilk objeyi silelim
        DeleteNextObject();
    }

    // Bir sonraki objeyi silen fonksiyon
    public void DeleteNextObject()
    {
        if (currentIndex < objectsToDelete.Length)
        {
            Destroy(objectsToDelete[currentIndex]);
            currentIndex++;

            // Objelerin say�s�n� g�ncelle
            UpdateObjectCount();
        }
        else
        {
            // Oyun bitti�inde metni g�ster ve oyunu durdur
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0f; // Oyunu durdur

            Debug.Log("Silinecek obje kalmad�. Oyun bitti.");
        }
    }

    // Objelerin say�s�n� g�ncelleyen fonksiyon
    private void UpdateObjectCount()
    {
        // Kalan obje say�s�n� g�ncelle
        int remainingObjects = objectsToDelete.Length - currentIndex;
        objectCountText.text = "" + remainingObjects.ToString();
    }


}
