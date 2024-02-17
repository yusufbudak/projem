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
        // Oyun duraklatýldýðýnda veya devam ettirildiðinde fare durumunu güncelle
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
        UnlockAndShowCursor(); // Mevcut sahneden çýkýldýðýnda fareyi serbest býrak ve göster
    }

    void LockAndHideCursor()
    {
        // Fareyi kilitle ve gizle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockAndShowCursor()
    {
        // Fareyi serbest býrak ve göster
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
