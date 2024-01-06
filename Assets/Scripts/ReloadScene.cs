using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    private string _nameScene;
    // Start is called before the first frame update
    void Start()
    {
        _nameScene = SceneManager.GetActiveScene().name;
    }
    
    public void ReloadSceneX()
    {
        SceneManager.LoadScene(_nameScene);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
