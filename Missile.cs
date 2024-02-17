using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform target; // Hedef transform
    public float speed = 30f; // Füze hýzý
    public float rotateSpeed = 20f; // Dönme hýzý
    public GameObject explosion; // Patlama efekti prefabý
    public float lifeTime = 5f; // Füzenin ömrü
    private bool hasExploded = false; // Patlama efektinin bir kere çalýþmasýný saðlamak için

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
        DoRotate();
    }
    private void DoRotate()
    {
        Vector3 targetDir = target.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(targetDir);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rot, rotateSpeed * Time.deltaTime));
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Çarpýþan nesnenin hedef olup olmadýðýný kontrol et
        if (collision.gameObject.transform == target)
        {
            // Patlama efekti ve yok etme iþlemi
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            // Hedef dýþýnda bir nesneye çarpýldýysa sadece patlama efekti oluþtur
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        // Belirtilen ömür süresinden sonra kendini yok et
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f && !hasExploded)
        {
            hasExploded = true;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}