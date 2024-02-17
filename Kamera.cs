using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    //kamera objemmizi tan�mlad�k
    public GameObject camera;
    //mouse'umuza hassasiyet ekliyoruz cs oynayanlar bilir
    public float mouse_sensivity;
    //mouse'umuzun kordinatlar�n� hesapl�yoruz
    public float XmouseRotation;
    public float YmouseRotation;
    //kameram�z�n kafas�n� �evirince karakterimizinde d�nmesini istiyorum bu y�zden obje tan�mlad�k
    public GameObject obje;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //x mouse rotation'�na s�n�r ekliyoruz e�er s�n�f eklemezsek karakterimiz kafas�n� 360 derece �evirebilir
        XmouseRotation = Mathf.Clamp(XmouseRotation, -30, 30);
        YmouseRotation = Mathf.Clamp(YmouseRotation, -30, 30);

        XmouseRotation -= Input.GetAxis("Mouse Y") * mouse_sensivity * Time.deltaTime;
        YmouseRotation += Input.GetAxis("Mouse X") * mouse_sensivity * Time.deltaTime;
        //biz mouse'u �evirdi�imizde ben kameran�nda d�nemsini istiyorum bunun i�in bu kodu giriyoruz
        camera.transform.rotation = Quaternion.Euler(XmouseRotation, YmouseRotation, 0);
        //ben kamera d�nd���nde karakterimizinde d�nmesini istiyorum bunun i�in bu kodu giriyoruz
        //ancak sadece y y�n�nde d�nmesini istiyorum ��nk� ben sadece etrafa bakmak i�in d�nemsini istiyorum karaktermizin ters d�nmesini de�il
        
    }
}