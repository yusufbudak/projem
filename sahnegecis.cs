using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahnegecis : MonoBehaviour
{
    public string targetSceneName; // Ge�i� yap�lacak hedef sahnenin ad�

    public void LoadTargetScene()
    {
        // Belirlenen hedef sahneye ge�i� yap
        SceneManager.LoadScene(targetSceneName);
    }
}
