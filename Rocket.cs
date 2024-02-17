using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Transform target;

    public float speed;
    public float rotateSpeed;
    public float lifeTime = 25f; // F�zenin �mr�
    private bool hasExploded = false; // Patlama efektinin bir kere �al��mas�n� sa�lamak i�in

    private Rigidbody rb;
    public GameObject explosion;
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
        // �arp��an nesnenin hedef olup olmad���n� kontrol et
        if (collision.gameObject.transform == target)
        {
            // Patlama efekti ve yok etme i�lemi
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            // Hedef d���nda bir nesneye �arp�ld�ysa sadece patlama efekti olu�tur
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Belirtilen �m�r s�resinden sonra kendini yok et
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f && !hasExploded)
        {
            hasExploded = true;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
