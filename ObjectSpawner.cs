using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Oluþturulacak obje
    public Transform[] spawnPoints; // Spawner noktalarý
    public float spawnInterval = 3f; // Spawner aralýðý
    private float spawnTimer = 0f; // Geçen süre

    public int maxSpawnCount = 10; // Maksimum spawn sayýsý
    private int currentSpawnCount = 0; // Mevcut spawn sayýsý

    void Update()
    {
        // Spawn zamanlayýcýsýný güncelle
        spawnTimer += Time.deltaTime;

        // Belirli bir aralýkta spawn yap ve spawn sayýsýný kontrol et
        if (spawnTimer >= spawnInterval && currentSpawnCount < maxSpawnCount)
        {
            SpawnObject();
            spawnTimer = 0f; // Zamanlayýcýyý sýfýrla
        }
    }

    void SpawnObject()
    {
        // Rastgele bir spawn noktasý seç
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Seçilen spawn noktasýnda objeyi oluþtur
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);

        // Mevcut spawn sayýsýný arttýr
        currentSpawnCount++;
    }

}
