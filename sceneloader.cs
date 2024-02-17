using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    public string sceneName; // Y�klenecek sahnenin ad�
    public float delay = 10f; // Ge�i� s�resi (saniye)

    void Start()
    {
        
        // Belirtilen s�re sonunda yeni sahneye ge�i� yap
        Invoke("LoadScene", delay);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
