using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Hedefimiz, genellikle oyuncu
    public Transform baseTarget; // Hedefin yok edilmesi gereken hava �ss�
    public float moveSpeed = 5f; // U�a��n hareket h�z�
    public float rotateSpeed = 1f; // U�a��n d�nme h�z�
    public float attackRange = 20f; // F�ze ate�leme menzili
    public float maneuverDistance = 10f; // Manevra yapma mesafesi
    public float baseAttackDistance = 15f; // Hava �ss�ne sald�rma mesafesi
    public float maxAltitude = 50f; // Maksimum y�kseklik
    public float minAltitude = 10f; // Minimum y�kseklik
    public GameObject missilePrefab; // F�ze prefab�
    public Transform missileSpawnPoint; // F�zenin ��k�� noktas�
    public float missileSpeed = 10f; // F�zenin h�z�
    public float fireInterval = 2f; // F�ze ate�leme aral���
    private float fireTimer = 2f; // F�ze ate�leme zamanlay�c�s�

    // D��man u�a�� yok oldu�unda GameController'a bildirim g�ndermek i�in olay
    public delegate void OnEnemyDestroyed();
    public static event OnEnemyDestroyed onEnemyDestroyed;

    // D��man u�a�� yok oldu�unda �a�r�lacak fonksiyon
    void OnDestroy()
    {
        // D��man u�a�� yok oldu�unda onEnemyDestroyed olay�n� tetikle
        if (onEnemyDestroyed != null)
            onEnemyDestroyed();
    }

    private void Update()
    {
        // D��man u�a��n�n y�ksekli�ini kontrol et ve s�n�rlar�n� belirle
        float currentAltitude = transform.position.y;
        float clampedAltitude = Mathf.Clamp(currentAltitude, minAltitude, maxAltitude);
        transform.position = new Vector3(transform.position.x, clampedAltitude, transform.position.z);

        // Hedefe do�ru y�nelme
        Vector3 targetDirection = target.position - transform.position;

        if (targetDirection.magnitude <= attackRange)
        {
            // E�er oyuncu menzilindeyse, oyuncuyu hedef al
            EngagePlayer();
        }
        else if (targetDirection.magnitude <= baseAttackDistance)
        {
            // E�er hava �ss�ne sald�rma mesafesine yak�nsa, hava �ss�ne sald�r
            AttackBase();
        }
        else
        {
            // E�er oyuncu menzilinde de�ilse, hava �ss�ne y�nel
            ReturnToBase();
        }
    }

    void EngagePlayer()
    {
        // Belirli bir mesafeden daha yak�nsa f�ze ate�le
        if (target != null)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireInterval)
            {
                fireTimer = 0f;
                FireMissile();
            }
        }

        // Hedefe do�ru ilerleme
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        // Hedefe do�ru y�nelme
        Vector3 targetDirection = target.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), rotateSpeed * Time.deltaTime);
    }

    void ReturnToBase()
    {
        // Hava �ss�ne do�ru y�nelme
        Vector3 baseDirection = baseTarget.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(baseDirection), rotateSpeed * Time.deltaTime);

        // Hava �ss�ne do�ru ilerleme
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void AttackBase()
    {
        // Belirli bir mesafeden daha yak�nsa f�ze ate�le
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireInterval)
        {
            fireTimer = 0f;
            FireMissile();
        }

        // Hedefe do�ru ilerleme
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        // Hedefe do�ru y�nelme
        Vector3 targetDirection = baseTarget.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), rotateSpeed * Time.deltaTime);
    }

    void FireMissile()
    {
        // F�ze prefab�ndan yeni bir f�ze olu�tur
        GameObject missileObject = Instantiate(missilePrefab, missileSpawnPoint.position, missileSpawnPoint.rotation);

        // F�ze scriptine eri�
        Missile missileScript = missileObject.GetComponent<Missile>();

        // Hedefi f�ze scriptine ata
        missileScript.target = target;
    }
    

}
