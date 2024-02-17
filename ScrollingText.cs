using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingText : MonoBehaviour
{
    public TextMeshProUGUI textMesh; // Scroll edilecek TextMeshProUGUI nesnesi
    public float scrollSpeed = 1f; // Metnin kayma hýzý

    void Update()
    {
        // Metnin pozisyonunu güncelle ve yukarý doðru kaydýr
        Vector3 newPosition = textMesh.rectTransform.localPosition;
        newPosition.y += scrollSpeed * Time.deltaTime;
        textMesh.rectTransform.localPosition = newPosition;

        // Metin ekranýn üst kenarýna ulaþtýðýnda tekrar aþaðýya doðru kaydýr
        if (newPosition.y >= Screen.height)
        {
            newPosition.y = -Screen.height / 2f; // Metni ekranýn alt kenarýna yerleþtir
            textMesh.rectTransform.localPosition = newPosition;
        }
    }
}
