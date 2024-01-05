using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LifeSystem : MonoBehaviour
{
    public static int life=3;
    public string nameScene;
    public Vector3 playerRespawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (life==0)
        {
            life = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //check si tu es a cour de vie
        if (life==0)
        {
            loadScene();
        }
        
        
    }
    
    //relance la scene
    public void loadScene()
    {
        SceneManager.LoadScene(sceneName: nameScene);
    }

    // TP vers le spawnpoint lorsqu'on touche la zone de déclenchement
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DamageZone"))
        {
            life -= 1;
            RespawnPlayer();
        }
        else if (other.CompareTag("Spawnpoint"))
        {
            SetRespawnPoint(other.transform.position);
        }
    }

    void RespawnPlayer()
    {
        transform.position = playerRespawnPoint;
    }

    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        playerRespawnPoint = newRespawnPoint;
    }
}