using UnityEngine;
using UnityEngine.SceneManagement;
public class LifeSystem : MonoBehaviour
{
    public static int life = 3;
    public Vector3 playerRespawnPoint;
    private string _nameScene;

    // Start is called before the first frame update
    void Start()
    {
        _nameScene = SceneManager.GetActiveScene().name;
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
        SceneManager.LoadScene(_nameScene);
    }

    // TP vers le spawnpoint lorsqu'on touche la zone de déclenchement
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("DamageZone"))
        {
            life -= 1;
            RespawnPlayer();
        }
    
        else  if (other.CompareTag("Spawnpoint"))
        {
            Debug.Log(other.transform.position);
            SetRespawnPoint(other.transform.position);
        }
    }

    void RespawnPlayer()
    {
        if (playerRespawnPoint != Vector3.zero)
        {
            transform.position = playerRespawnPoint;
        }
        else
        {
            loadScene();
        }
    }

    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        playerRespawnPoint = newRespawnPoint;
    }
}