using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroySound : MonoBehaviour
{
    public AudioClip destroySound; // Oyun objesi yok oldu�unda �al�nacak ses

    private void OnDestroy()
    {
        if (destroySound != null)
        {
            // E�er yok oldu�unda �al�nacak bir ses belirtilmi�se, sesi �al
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
        }
    }
}
