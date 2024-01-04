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

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(_nameScene);
    }
}
