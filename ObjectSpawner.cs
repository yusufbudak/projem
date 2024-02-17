using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Olu�turulacak obje
    public Transform[] spawnPoints; // Spawner noktalar�
    public float spawnInterval = 3f; // Spawner aral���
    private float spawnTimer = 0f; // Ge�en s�re

    public int maxSpawnCount = 10; // Maksimum spawn say�s�
    private int currentSpawnCount = 0; // Mevcut spawn say�s�

    void Update()
    {
        // Spawn zamanlay�c�s�n� g�ncelle
        spawnTimer += Time.deltaTime;

        // Belirli bir aral�kta spawn yap ve spawn say�s�n� kontrol et
        if (spawnTimer >= spawnInterval && currentSpawnCount < maxSpawnCount)
        {
            SpawnObject();
            spawnTimer = 0f; // Zamanlay�c�y� s�f�rla
        }
    }

    void SpawnObject()
    {
        // Rastgele bir spawn noktas� se�
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Se�ilen spawn noktas�nda objeyi olu�tur
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);

        // Mevcut spawn say�s�n� artt�r
        currentSpawnCount++;
    }

}
