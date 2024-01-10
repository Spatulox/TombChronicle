using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; 
    public float lifeTime = 5f;
    void Start()
    {
        
        Destroy(gameObject, lifeTime);
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
       
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}