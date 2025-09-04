using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Collider2D collider2D;
    [SerializeField] GameObject bow;
    [SerializeField] GameObject hammer;
    

    [Header("Variables")]
    [SerializeField] private float speed;
    [SerializeField] private float rollTime;
    [SerializeField] private float rollTimeMax;
    private float rollCoolDown;
    public int Arrows = 1;
    public bool isRolling = false;
    public float playerHealth;

   private bool isUsingBow = true;  




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hammer.SetActive(false);
    }

    // Update is called once per framew
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, Vertical);

        transform.Translate(movement * speed * Time.deltaTime);

    }

    private void Update()
    {
        WeaponSwitch();

       if(playerHealth <= 0)
        {
            Debug.Log("You died");
        }
        
        if (Input.GetButtonDown("Jump") && rollCoolDown >= 2)
        {
            Roll();
        }

        if (isRolling)
        {
            rollTime += Time.deltaTime;
        }

        if (rollTime >= rollTimeMax)
        {
            isRolling = false;
            speed = 3;
            rollTime = 0;
            collider2D.excludeLayers = LayerMask.GetMask("Nothing");
            rollCoolDown = 0;
        }

        if (!isRolling && rollCoolDown <= 2)
        {
            rollCoolDown += Time.deltaTime;
        }
    }



    void Roll()
    {
        if (!isRolling)
        {
            isRolling = true;
            speed = 5;
            collider2D.excludeLayers = LayerMask.GetMask("IgnoreDodge");
        }
             
    }


    private void WeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bow.SetActive(true);
            hammer.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bow.SetActive(false);
            hammer.SetActive(true);
        }
    }

   

}
