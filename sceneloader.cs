using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    public string sceneName; // Yüklenecek sahnenin adý
    public float delay = 10f; // Geçiþ süresi (saniye)

    void Start()
    {
        
        // Belirtilen süre sonunda yeni sahneye geçiþ yap
        Invoke("LoadScene", delay);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
