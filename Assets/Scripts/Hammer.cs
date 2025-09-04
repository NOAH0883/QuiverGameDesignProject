using UnityEngine;

public class Hammer : MonoBehaviour
{

    [SerializeField] Animator ani;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;


        if (Input.GetMouseButtonDown(0))
        {
            HammerAttack();
        }
    }


    private void HammerAttack()
    {
        ani.enabled = true;
        ani.SetTrigger("isHammerAttack");
    }
}
