using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnButton : MonoBehaviour
{
   public int SceneToLoad;
   public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
