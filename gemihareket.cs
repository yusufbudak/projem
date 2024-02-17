using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemihareket : MonoBehaviour
{
    public delegate void OnEnemyDestroyed();
    public static event OnEnemyDestroyed onEnemyDestroyed;

    public GameObject rocketPrefab; // Roket prefabý
    public Transform firePoint; // Roketin ateþlendiði nokta
    public float fireDistance = 10f; // Roketin ateþleneceði mesafe

    public float speed = 5f; // Ýleri hareket hýzý
    public Transform targetObject; // Hedef objenin Transform bileþeni
    // Düþman uçaðý yok olduðunda GameController'a bildirim göndermek için olay
    

    // Düþman uçaðý yok olduðunda çaðrýlacak fonksiyon
    void OnDestroy()
    {
        // Düþman uçaðý yok olduðunda onEnemyDestroyed olayýný tetikle
        if (onEnemyDestroyed != null)
            onEnemyDestroyed();
    }

    void Start()
    {
        // targetObject deðiþkenine baþka bir objeyi atamak için sahnede hedef objeyi bulun ve atayýn
        targetObject = GameObject.Find("hedef").transform;
    }

    void Update()
    {
        // Hedef objenin pozisyonunu al
        Vector3 targetPosition = new Vector3(0, 0, 0); // Hedef objenin pozisyonunu buraya atmalýsýnýz

        // Geminin pozisyonunu al
        Vector3 shipPosition = transform.position;

        // Hedefe olan mesafeyi hesapla
        float distanceToTarget = Vector3.Distance(shipPosition, targetPosition);

        // Eðer gemi hedefe belirli bir mesafede ise roketi ateþle
        if (distanceToTarget <= fireDistance)
        {
            FireRocket();
        }

        // Yön vektörünü hesapla (sadece y ekseni)
        Vector3 direction = transform.forward;

        // Hareket vektörünü oluþtur ve hýzla çarp
        Vector3 movement = direction * speed * Time.deltaTime;

        // Objenin pozisyonunu güncelle
        transform.position += movement;
    }

    void FireRocket()
    {
        // Roket prefabýný ve ateþleme noktasýný kullanarak roketi ateþle
        Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
    }
}
