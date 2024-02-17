using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flightControl : MonoBehaviour
{
    public float speed;
    public float maxspeed;
    public float minspeed;
    public float rotspeed1;
    public float rotspeed2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (speed < maxspeed) speed++;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (speed > minspeed) speed--;
        }

        speed -= transform.forward.y * Time.deltaTime * 50;
        if (speed < minspeed / 2) speed = minspeed;
        if (speed > maxspeed * 2) speed = maxspeed;

        
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward*Time.deltaTime*rotspeed1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * rotspeed1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * rotspeed1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * rotspeed1);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * rotspeed2);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(-Vector3.down * Time.deltaTime * rotspeed2);
        }

    }
}
