using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshProLetterByLetter : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public AudioClip typeSound; // Yaz� tipi sesi
    public float letterDelay = 0.1f; // Her harf aras�ndaki gecikme s�resi
    private string originalText;
    private string currentText;
    private float timer = 0f;
    private int currentIndex = 0;
    private AudioSource audioSource;

    void Start()
    {
        originalText = textMeshPro.text;
        currentText = "";
        textMeshPro.text = currentText;

        // AudioSource bile�enini al
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSource bile�eni yoksa, scriptin ba�l� oldu�u GameObject'e ekle
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // T�m harfleri yazd�ysak i�lemi sonland�r
        if (currentIndex >= originalText.Length)
            return;

        // Zamanlay�c�y� g�ncelle
        timer += Time.deltaTime;

        // Belirlenen gecikme s�resi kadar zaman ge�tiyse bir sonraki harfi yazd�r
        if (timer >= letterDelay)
        {
            currentText += originalText[currentIndex];
            textMeshPro.text = currentText;
            currentIndex++;
            timer = 0f;

            // Yaz� tipi sesini �al
            if (typeSound != null)
            {
                audioSource.PlayOneShot(typeSound);
            }
        }
    }
}
