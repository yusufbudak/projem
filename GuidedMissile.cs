using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissile : MonoBehaviour
{
    private Transform target; // Hedef transform
    public float speed = 10f; // F�ze h�z�
    public float rotateSpeed = 10f; // D�nme h�z�
    public float maxLifetime = 10f; // Maksimum ya�am s�resi
    private float currentLifetime = 0f; // Ge�erli ya�am s�resi
    public GameObject explosion;

    void Update()
    {
        // Hedefe do�ru y�nelme
        if (target != null)
        {
            Vector3 targetDirection = target.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), rotateSpeed * Time.deltaTime);
        }

        // �leri do�ru ilerleme
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Ya�am s�resini kontrol et
        currentLifetime += Time.deltaTime;
        if (currentLifetime >= maxLifetime)
        {
            Destroy(gameObject); // F�zeyi yok et
        }
    }

    // Hedefi ayarlama
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // F�zenin �arp��ma i�lemi alg�lay�c�s�
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(collision.gameObject);
    }
}
