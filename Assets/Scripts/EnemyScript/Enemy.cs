using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem.Processors;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Enemy : MonoBehaviour
{

    [Header("References")]
    [SerializeField] Transform Player;
    [SerializeField] PlayerController PlayerController;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float Health;
    [SerializeField] Bow bow;
    [SerializeField] GameObject meleeWeapon, attackRange, enemySight;

    [Header("Enemy sight")]
    public bool canSee = false;
    [SerializeField] float meleeEnemySpeed;

    [Header("Enemy Attack")]
    [SerializeField] float attackMaxTime;
    [SerializeField] float enemyMeleeAttacKDamage;
    public bool meleeEnemyAttack = false;
    private Animator weaponAni;
    private float attackTimer;
    


    private void Awake()
    {
        weaponAni = meleeWeapon.GetComponent<Animator>();
    }


    private void Update()
    {
        if (Health <= 0)
        {

            Invoke("EnemyDeath", 0.1f);
        }

       
        if (attackTimer >= attackMaxTime)
        {
            attackTimer = attackMaxTime;
        }
        else
        {
            attackTimer += Time.deltaTime;
        }


        if (meleeEnemyAttack && attackTimer >= attackMaxTime)
        {
            Attack();
        }


        if (canSee)
        {
            MoveToPlayer();
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            Debug.Log(bow.arrowSpeed);
            Health -= bow.arrowSpeed;
        }
    }

    private void EnemyDeath()
    {
        Destroy(meleeWeapon);
        Destroy(attackRange);
        Destroy(enemySight);
        gameObject.transform.DetachChildren();
        Destroy(gameObject);


    }

    private void Attack()
    {
        weaponAni.SetTrigger("isMeleeAttack");
        attackTimer = 0;

        PlayerController.playerHealth -= enemyMeleeAttacKDamage;
    }



    private void MoveToPlayer()
    {

        Vector2 playerPosition = Player.position;
        Vector2 facePlayer = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
        transform.up = facePlayer;

        
        if(!meleeEnemyAttack)
        {
            Vector3 playerDirection = (Player.position - transform.position).normalized;
            transform.position += playerDirection * meleeEnemySpeed * Time.deltaTime;
        }


    }

}
