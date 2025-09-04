using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public Enemy enemy;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.canSee = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.canSee = false;
        }
    }
}
