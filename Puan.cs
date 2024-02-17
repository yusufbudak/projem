using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puan : MonoBehaviour
{
    public TextMeshProUGUI puan;
    float puanSayaci = 0;
    void OnCollisionEnter(Collision Other)
    {
        string objName= Other.gameObject.name;
        if (objName.Equals("f35") && objName.Equals("DDG51"))
            puanSayaci += 1;
        puan.text = puanSayaci + "";

    }
}
