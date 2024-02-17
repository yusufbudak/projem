using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemihareket : MonoBehaviour
{
    public delegate void OnEnemyDestroyed();
    public static event OnEnemyDestroyed onEnemyDestroyed;

    public GameObject rocketPrefab; // Roket prefab�
    public Transform firePoint; // Roketin ate�lendi�i nokta
    public float fireDistance = 10f; // Roketin ate�lenece�i mesafe

    public float speed = 5f; // �leri hareket h�z�
    public Transform targetObject; // Hedef objenin Transform bile�eni
    // D��man u�a�� yok oldu�unda GameController'a bildirim g�ndermek i�in olay
    

    // D��man u�a�� yok oldu�unda �a�r�lacak fonksiyon
    void OnDestroy()
    {
        // D��man u�a�� yok oldu�unda onEnemyDestroyed olay�n� tetikle
        if (onEnemyDestroyed != null)
            onEnemyDestroyed();
    }

    void Start()
    {
        // targetObject de�i�kenine ba�ka bir objeyi atamak i�in sahnede hedef objeyi bulun ve atay�n
        targetObject = GameObject.Find("hedef").transform;
    }

    void Update()
    {
        // Hedef objenin pozisyonunu al
        Vector3 targetPosition = new Vector3(0, 0, 0); // Hedef objenin pozisyonunu buraya atmal�s�n�z

        // Geminin pozisyonunu al
        Vector3 shipPosition = transform.position;

        // Hedefe olan mesafeyi hesapla
        float distanceToTarget = Vector3.Distance(shipPosition, targetPosition);

        // E�er gemi hedefe belirli bir mesafede ise roketi ate�le
        if (distanceToTarget <= fireDistance)
        {
            FireRocket();
        }

        // Y�n vekt�r�n� hesapla (sadece y ekseni)
        Vector3 direction = transform.forward;

        // Hareket vekt�r�n� olu�tur ve h�zla �arp
        Vector3 movement = direction * speed * Time.deltaTime;

        // Objenin pozisyonunu g�ncelle
        transform.position += movement;
    }

    void FireRocket()
    {
        // Roket prefab�n� ve ate�leme noktas�n� kullanarak roketi ate�le
        Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
    }
}
