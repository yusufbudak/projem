using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Camera cam;
    public LayerMask targetMask;

    public float focusTime;
    private GameObject focusObject;

    public Transform exitPoint;
    public GameObject rocketPrefab;

    private AudioSource audioSource;
    private ObjectDeleter objectDeleter; // ObjectDeleter scriptini referans olarak tutacak deðiþken

    private void Awake()
    {
        cam=Camera.main;
        audioSource=GetComponent<AudioSource>();
        objectDeleter = GetComponent<ObjectDeleter>(); // ObjectDeleter scriptini referans olarak al
    }

    private void Start()
    {
        // Launcher scripti çalýþtýðýnda ObjectDeleter scriptini çalýþtýr
        if (objectDeleter != null)
        {
            objectDeleter.DeleteNextObject();
        }
    }

    private void Update()
    {
        FocusTimer();
        if (Input.GetMouseButtonDown(0))
        {
            if(focusTime >= 1)
            {
                GameObject temp = Instantiate(rocketPrefab, exitPoint.position, Quaternion.identity);
                temp.transform.forward = transform.forward;
                if(temp.TryGetComponent(out Rocket rocket))
                {
                    rocket.target = focusObject.transform;
                }
                focusObject = null;

                // Launcher'daki roket fýrlatma iþlemi tamamlandýktan sonra ObjectDeleter scriptini çalýþtýr
                if (objectDeleter != null)
                {
                    objectDeleter.DeleteNextObject();
                }
            }
        }
    }
    private void FocusTimer()
    {
        if (focusObject)
        {
            focusTime += Time.deltaTime;
            audioSource.pitch+=0.0005f;
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            focusTime = 0;
            audioSource.Stop();
            audioSource.pitch = 1;
        }
    }
    private void FixedUpdate()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetMask))
        {
            focusObject = hit.collider.gameObject;
        }
        else
        {
            focusObject=null;
        }
    }
    


}
