using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GamewannaBe : MonoBehaviour
{ Rigidbody2D rb; 
   [SerializeField] GameObject Collectable1; 
    [SerializeField] GameObject Collectable2; 

    [SerializeField] GameObject Collectable3; 
    public float speed; 
    public Color normalColor = Color.white; 
    public Color fireColor = Color.red; 
    public SpriteRenderer spriteRenderer; 
    public string horizontalInputName = "Horizontal"; 
        public string verticalInputName = "Vertical"; 
    public string fireInputName = "Fire1"; 
    private float horizontalInput; 
    private float verticalInput; 
    int collectablesCount; 
    float score; 
    
    float force = 0;

    bool jumpButtonPressed = false;

    public ParticleSystem particles; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();  
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        particles = gameObject.GetComponent<ParticleSystem>(); 
        transform.position = transform.position + new Vector3(0,1,0);
        transform.Translate(new Vector3(0,1,0), Space.Self);
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetButtonDown("Fire1"))
        {
            spriteRenderer.color = fireColor;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            spriteRenderer.color = normalColor;
        }

          if (Input.GetButtonDown("Jump")) // Input.GetKeyUp(KeyCode.Space)
        {
            jumpButtonPressed = true;
        }

        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        
        Debug.Log(xInput);

        rb.AddTorque(xInput * 5f);

        if(yInput > 0)
        {
        rb.AddForce(yInput * transform.up);
        particles.Play();
        }
        else
        {
         particles.Stop();   
        }
       // gameObject.transform.Translate(
           // new Vector3(xInput * Time.deltaTime * speed, yInput * Time.deltaTime * speed, 0f));
        

    // Vector2 movement = new Vector2(horizontalInput, verticalInput);
      //  movement.Normalize();
       // GetComponent<Rigidbody2D>().velocity = movement * speed;
/*
        if (!particles.isEmitting && Input.GetButtonDown("Fire1"))
        {
            particles.Play();
        }
        else if(particles.isEmitting && Input.GetButtonDown("Fire1"))
        {

        particles.Stop();
        }
     */
     }
    void FixedUpdate()
    {
        if (jumpButtonPressed) 
        { // discrete
            rb.AddForce(new Vector2(0, 100));
            jumpButtonPressed = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
       Debug.Log(collision.gameObject.tag); 
       // Destroy(collision.gemeObject);  

    }     
       
}
