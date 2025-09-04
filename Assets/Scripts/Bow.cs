using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Bow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject ArrowPrefab;
    [SerializeField] GameObject ArrowSpawnPoint;
    [SerializeField] PlayerController playerController;


    [Header("Variables")]
    public float arrowSpeed;
    private float pullback;
    
    [SerializeField] private float pullbackMax;

    

    

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;



        if (Input.GetMouseButtonDown(0) && playerController.Arrows == 1 && !playerController.isRolling)
        {
            pullback = 0;
            arrowSpeed = 0;
        }

        if (Input.GetMouseButton(0) && playerController.Arrows == 1 && !playerController.isRolling)
        {
            pullback += Time.deltaTime;
            
        }

        if (Input.GetMouseButtonUp(0) && playerController.Arrows == 1 && !playerController.isRolling)
        {
            arrowSpeed = pullback;
            ShootArrow();
            playerController.Arrows = 0;

        }

        if (pullback >= pullbackMax)
        {
            pullback = pullbackMax;
        }

        
    }

    void ShootArrow()
    {
        Instantiate(ArrowPrefab, ArrowSpawnPoint.transform.position, transform.rotation);
    }

    
}
