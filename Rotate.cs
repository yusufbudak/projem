using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 50f; // D�nme h�z�

    void Update()
    {
        // Objeyi kendi etraf�nda y ekseninde d�nd�rme
        transform.Rotate(new Vector3(0, 0, 1 * rotationSpeed * Time.deltaTime));
    }
}
