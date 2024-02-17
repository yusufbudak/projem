using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissile : MonoBehaviour
{
    private Transform target; // Hedef transform
    public float speed = 10f; // Füze hýzý
    public float rotateSpeed = 10f; // Dönme hýzý
    public float maxLifetime = 10f; // Maksimum yaþam süresi
    private float currentLifetime = 0f; // Geçerli yaþam süresi
    public GameObject explosion;

    void Update()
    {
        // Hedefe doðru yönelme
        if (target != null)
        {
            Vector3 targetDirection = target.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), rotateSpeed * Time.deltaTime);
        }

        // Ýleri doðru ilerleme
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Yaþam süresini kontrol et
        currentLifetime += Time.deltaTime;
        if (currentLifetime >= maxLifetime)
        {
            Destroy(gameObject); // Füzeyi yok et
        }
    }

    // Hedefi ayarlama
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Füzenin çarpýþma iþlemi algýlayýcýsý
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(collision.gameObject);
    }
}
