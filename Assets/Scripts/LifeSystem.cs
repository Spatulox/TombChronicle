using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour

{
    public static int life = 3;
    public Vector3 playerRespawnPoint;
    public Text lifeText;
    private string _nameScene;
    

    // Start is called before the first frame update
    void Start()
    {
        _nameScene = SceneManager.GetActiveScene().name;
        if (life<3)
        {
            life = 3;
        }
        UpdateLifeText(); 
    }
    
    public void UpdateLifeText()
    {
        if (lifeText != null) 
        {
            lifeText.text = "\u2764\ufe0f " + life;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //check si tu es a cour de vie
        if (life<=0)
        {
            loadScene();
        }
        
        
    }
    
    //relance la scene
    public void loadScene()
    {
        SceneManager.LoadScene(_nameScene);
    }

    private IEnumerator FlashLifeText()
    {
        Color originalColor = lifeText.color;
        lifeText.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        lifeText.color = originalColor;
        
        UpdateLifeText();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("DamageZone"))
        {
            life -= 1;
            StartCoroutine(FlashLifeText());
            UpdateLifeText();
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
    
    private IEnumerator DeathAnimation()
    {
        float duration = 1.0f; 
        float alpha = 1.0f; 
        while (duration > 0f)
        {
            duration -= Time.deltaTime; 
            alpha = Mathf.PingPong(Time.time * 2, 1.0f);
            if (lifeText != null)
            {
                lifeText.color = new Color(lifeText.color.r, lifeText.color.g, lifeText.color.b, alpha);
            }
            yield return null;
        }
        loadScene();
    }
    
}


