using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    //kamera objemmizi tanýmladýk
    public GameObject camera;
    //mouse'umuza hassasiyet ekliyoruz cs oynayanlar bilir
    public float mouse_sensivity;
    //mouse'umuzun kordinatlarýný hesaplýyoruz
    public float XmouseRotation;
    public float YmouseRotation;
    //kameramýzýn kafasýný çevirince karakterimizinde dönmesini istiyorum bu yüzden obje tanýmladýk
    public GameObject obje;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //x mouse rotation'ýna sýnýr ekliyoruz eðer sýnýf eklemezsek karakterimiz kafasýný 360 derece çevirebilir
        XmouseRotation = Mathf.Clamp(XmouseRotation, -30, 30);
        YmouseRotation = Mathf.Clamp(YmouseRotation, -30, 30);

        XmouseRotation -= Input.GetAxis("Mouse Y") * mouse_sensivity * Time.deltaTime;
        YmouseRotation += Input.GetAxis("Mouse X") * mouse_sensivity * Time.deltaTime;
        //biz mouse'u çevirdiðimizde ben kameranýnda dönemsini istiyorum bunun için bu kodu giriyoruz
        camera.transform.rotation = Quaternion.Euler(XmouseRotation, YmouseRotation, 0);
        //ben kamera döndüðünde karakterimizinde dönmesini istiyorum bunun için bu kodu giriyoruz
        //ancak sadece y yönünde dönmesini istiyorum çünkü ben sadece etrafa bakmak için dönemsini istiyorum karaktermizin ters dönmesini deðil
        
    }
}