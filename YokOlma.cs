using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokOlma : MonoBehaviour
{
    public GameObject explosionPrefab; // Patlama efektini i�eren prefab

    private void OnCollisionEnter(Collision collision)
    {
        // �arp��t���nda patlama efektini tetikle
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        // Kendi nesneyi yok et
        Destroy(gameObject);

        
    }
}
