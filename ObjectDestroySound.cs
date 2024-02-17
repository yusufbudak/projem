using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroySound : MonoBehaviour
{
    public AudioClip destroySound; // Oyun objesi yok olduðunda çalýnacak ses

    private void OnDestroy()
    {
        if (destroySound != null)
        {
            // Eðer yok olduðunda çalýnacak bir ses belirtilmiþse, sesi çal
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
        }
    }
}
