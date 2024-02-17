using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahnegecis : MonoBehaviour
{
    public string targetSceneName; // Geçiþ yapýlacak hedef sahnenin adý

    public void LoadTargetScene()
    {
        // Belirlenen hedef sahneye geçiþ yap
        SceneManager.LoadScene(targetSceneName);
    }
}
