using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loadSceneScript : MonoBehaviour
{
    public string sceneToLoad;
    
    public void LoadScene()
    {   
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(sceneToLoad);
    }
}
