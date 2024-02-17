using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshProLetterByLetter : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public AudioClip typeSound; // Yazý tipi sesi
    public float letterDelay = 0.1f; // Her harf arasýndaki gecikme süresi
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

        // AudioSource bileþenini al
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSource bileþeni yoksa, scriptin baðlý olduðu GameObject'e ekle
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Tüm harfleri yazdýysak iþlemi sonlandýr
        if (currentIndex >= originalText.Length)
            return;

        // Zamanlayýcýyý güncelle
        timer += Time.deltaTime;

        // Belirlenen gecikme süresi kadar zaman geçtiyse bir sonraki harfi yazdýr
        if (timer >= letterDelay)
        {
            currentText += originalText[currentIndex];
            textMeshPro.text = currentText;
            currentIndex++;
            timer = 0f;

            // Yazý tipi sesini çal
            if (typeSound != null)
            {
                audioSource.PlayOneShot(typeSound);
            }
        }
    }
}
