using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokOlma : MonoBehaviour
{
    public GameObject explosionPrefab; // Patlama efektini içeren prefab

    private void OnCollisionEnter(Collision collision)
    {
        // Çarpýþtýðýnda patlama efektini tetikle
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        // Kendi nesneyi yok et
        Destroy(gameObject);

        
    }
}
