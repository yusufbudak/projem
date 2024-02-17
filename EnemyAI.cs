using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Hedefimiz, genellikle oyuncu
    public Transform baseTarget; // Hedefin yok edilmesi gereken hava üssü
    public float moveSpeed = 5f; // Uçaðýn hareket hýzý
    public float rotateSpeed = 1f; // Uçaðýn dönme hýzý
    public float attackRange = 20f; // Füze ateþleme menzili
    public float maneuverDistance = 10f; // Manevra yapma mesafesi
    public float baseAttackDistance = 15f; // Hava üssüne saldýrma mesafesi
    public float maxAltitude = 50f; // Maksimum yükseklik
    public float minAltitude = 10f; // Minimum yükseklik
    public GameObject missilePrefab; // Füze prefabý
    public Transform missileSpawnPoint; // Füzenin çýkýþ noktasý
    public float missileSpeed = 10f; // Füzenin hýzý
    public float fireInterval = 2f; // Füze ateþleme aralýðý
    private float fireTimer = 2f; // Füze ateþleme zamanlayýcýsý

    // Düþman uçaðý yok olduðunda GameController'a bildirim göndermek için olay
    public delegate void OnEnemyDestroyed();
    public static event OnEnemyDestroyed onEnemyDestroyed;

    // Düþman uçaðý yok olduðunda çaðrýlacak fonksiyon
    void OnDestroy()
    {
        // Düþman uçaðý yok olduðunda onEnemyDestroyed olayýný tetikle
        if (onEnemyDestroyed != null)
            onEnemyDestroyed();
    }

    private void Update()
    {
        // Düþman uçaðýnýn yüksekliðini kontrol et ve sýnýrlarýný belirle
        float currentAltitude = transform.position.y;
        float clampedAltitude = Mathf.Clamp(currentAltitude, minAltitude, maxAltitude);
        transform.position = new Vector3(transform.position.x, clampedAltitude, transform.position.z);

        // Hedefe doðru yönelme
        Vector3 targetDirection = target.position - transform.position;

        if (targetDirection.magnitude <= attackRange)
        {
            // Eðer oyuncu menzilindeyse, oyuncuyu hedef al
            EngagePlayer();
        }
        else if (targetDirection.magnitude <= baseAttackDistance)
        {
            // Eðer hava üssüne saldýrma mesafesine yakýnsa, hava üssüne saldýr
            AttackBase();
        }
        else
        {
            // Eðer oyuncu menzilinde deðilse, hava üssüne yönel
            ReturnToBase();
        }
    }

    void EngagePlayer()
    {
        // Belirli bir mesafeden daha yakýnsa füze ateþle
        if (target != null)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireInterval)
            {
                fireTimer = 0f;
                FireMissile();
            }
        }

        // Hedefe doðru ilerleme
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        // Hedefe doðru yönelme
        Vector3 targetDirection = target.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), rotateSpeed * Time.deltaTime);
    }

    void ReturnToBase()
    {
        // Hava üssüne doðru yönelme
        Vector3 baseDirection = baseTarget.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(baseDirection), rotateSpeed * Time.deltaTime);

        // Hava üssüne doðru ilerleme
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void AttackBase()
    {
        // Belirli bir mesafeden daha yakýnsa füze ateþle
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireInterval)
        {
            fireTimer = 0f;
            FireMissile();
        }

        // Hedefe doðru ilerleme
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        // Hedefe doðru yönelme
        Vector3 targetDirection = baseTarget.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), rotateSpeed * Time.deltaTime);
    }

    void FireMissile()
    {
        // Füze prefabýndan yeni bir füze oluþtur
        GameObject missileObject = Instantiate(missilePrefab, missileSpawnPoint.position, missileSpawnPoint.rotation);

        // Füze scriptine eriþ
        Missile missileScript = missileObject.GetComponent<Missile>();

        // Hedefi füze scriptine ata
        missileScript.target = target;
    }
    

}
