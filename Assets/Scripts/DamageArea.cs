using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageArea : MonoBehaviour


{
    public  LifeSystem life;
    public Text lifeText;
    

        // Start is called before the first frame update

    void Start()
    {
        life = GetComponent<LifeSystem>();
        if (life == null)
        {
            Debug.LogError("LifeSystem n'est pas trouvé sur l'objet.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            LifeSystem.life -= 1;
            life.UpdateLifeText();
            Debug.Log("touche");
        }
    }
}
