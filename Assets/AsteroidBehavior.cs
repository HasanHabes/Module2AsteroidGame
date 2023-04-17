using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    [SerializeField] Transform Asteroid; 
    

    [SerializeField] Transform Ship; 
    
    [SerializeField] Vector3 Asteroidvelocity; 
  
    [SerializeField] Vector3 Asteroidacceleration; 
     
    [SerializeField] GameObject AsteroidPiece; 
    int numberOfAsteroidPiece = 3; 
   
    
    float distance; // Start is called before the first frame update
    void Start()
    {
      float x = Random.Range(-14f, 14f); 
      float y = Random.Range(-7f, 7f); 
      float z = 0f; 
       

       
       if(gameObject.tag != "LittleAstroid")
       {
        transform.position = new Vector3(x, y, z);
       }
        Asteroid = transform;
        x = Random.Range(-1f, 1f); 
        y = Random.Range(-1f, 1f); 
        z = 0f; 
        Asteroidacceleration = new Vector3(x, y, z); 
    }

    // Update is called once per frame
    void Update()
    {
       Asteroidacceleration = Vector3.ClampMagnitude(Asteroidacceleration,2);
        Asteroidvelocity += Time.deltaTime * Asteroidacceleration;
        Asteroidvelocity = Vector3.ClampMagnitude(Asteroidvelocity,20);
        transform.position += Time.deltaTime * Asteroidvelocity;
        
       
    }
void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Bullet")
        {
            Destroy(collider.gameObject);
            if(gameObject.tag != "LittleAstroid")
            {
                for (int i = 0; i < numberOfAsteroidPiece; i++)
                {
                Instantiate(AsteroidPiece, transform.position, transform.rotation);
                }
            }
            Destroy(gameObject);
           UIScoreLive.instance.UpdateScore(1000);
        }
        
    }
}