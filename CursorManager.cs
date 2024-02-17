using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        LockAndHideCursor();
    }

    void Update()
    {
        // Oyun duraklat�ld���nda veya devam ettirildi�inde fare durumunu g�ncelle
        if (Time.timeScale == 0f)
        {
            UnlockAndShowCursor();
        }
        else
        {
            LockAndHideCursor();
        }
    }
    void OnDisable()
    {
        UnlockAndShowCursor(); // Mevcut sahneden ��k�ld���nda fareyi serbest b�rak ve g�ster
    }

    void LockAndHideCursor()
    {
        // Fareyi kilitle ve gizle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockAndShowCursor()
    {
        // Fareyi serbest b�rak ve g�ster
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
