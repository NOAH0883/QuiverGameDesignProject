using System.Runtime.CompilerServices;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    [Header("References")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Bow bow;
    [SerializeField] PlayerController playerController;

    [Header("Variables")]
    public float speed;
    public float arrowDamage = 0;

    private float arrowStopTime;
    private float timer;
    

    


    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
            
        speed = bow.arrowSpeed * 12;
        arrowStopTime = bow.arrowSpeed * 2;
        
    }


   

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = transform.up * speed;
        timer += Time.deltaTime;

        if (timer >= arrowStopTime)
        {
            speed = 0;
            
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if(collision.CompareTag("Player") && speed == 0)
        {
            Destroy(gameObject);
            playerController.Arrows = 1;
            
        }

        if (collision.CompareTag("Wall"))
        {
            speed = 0;
        }
        
        if (collision.CompareTag("Enemy") && speed > 0)
        {
            arrowDamage = bow.arrowSpeed;
            speed = 0;
            transform.SetParent(collision.transform, true);
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && speed == 0)
        {
            Destroy(gameObject);
            playerController.Arrows = 1;
        }
    }
}
