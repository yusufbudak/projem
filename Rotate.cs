using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 50f; // Dönme hýzý

    void Update()
    {
        // Objeyi kendi etrafýnda y ekseninde döndürme
        transform.Rotate(new Vector3(0, 0, 1 * rotationSpeed * Time.deltaTime));
    }
}
