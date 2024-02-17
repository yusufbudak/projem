using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class tuslar : MonoBehaviour
{
    public Canvas canvasToOpen; // A��lacak olan Canvas

    void Start()
    {
        // Ba�lang��ta Canvas'i kapat
        canvasToOpen.gameObject.SetActive(false);
    }

    public void OpenCanvas()
    {
        // Butona t�kland���nda Canvas'i a�
        canvasToOpen.gameObject.SetActive(true);
    }
}
