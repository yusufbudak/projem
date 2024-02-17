using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingText : MonoBehaviour
{
    public TextMeshProUGUI textMesh; // Scroll edilecek TextMeshProUGUI nesnesi
    public float scrollSpeed = 1f; // Metnin kayma h�z�

    void Update()
    {
        // Metnin pozisyonunu g�ncelle ve yukar� do�ru kayd�r
        Vector3 newPosition = textMesh.rectTransform.localPosition;
        newPosition.y += scrollSpeed * Time.deltaTime;
        textMesh.rectTransform.localPosition = newPosition;

        // Metin ekran�n �st kenar�na ula�t���nda tekrar a�a��ya do�ru kayd�r
        if (newPosition.y >= Screen.height)
        {
            newPosition.y = -Screen.height / 2f; // Metni ekran�n alt kenar�na yerle�tir
            textMesh.rectTransform.localPosition = newPosition;
        }
    }
}
