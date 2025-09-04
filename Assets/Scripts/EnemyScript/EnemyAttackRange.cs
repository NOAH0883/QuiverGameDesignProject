using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{

    public Enemy enemy;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            enemy.meleeEnemyAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.meleeEnemyAttack = false;
        }
    }
}
