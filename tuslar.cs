using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class tuslar : MonoBehaviour
{
    public Canvas canvasToOpen; // Açýlacak olan Canvas

    void Start()
    {
        // Baþlangýçta Canvas'i kapat
        canvasToOpen.gameObject.SetActive(false);
    }

    public void OpenCanvas()
    {
        // Butona týklandýðýnda Canvas'i aç
        canvasToOpen.gameObject.SetActive(true);
    }
}
