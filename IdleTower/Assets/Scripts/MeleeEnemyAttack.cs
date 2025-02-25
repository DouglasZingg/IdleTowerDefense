using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeleeEnemyAttack : MonoBehaviour
{
    public GameObject player;

    public float damage;

    private float timer;

    public float attackSpeed = 4.0f;

    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > attackSpeed && isAttacking == true)
        {
            timer = 0;
            player.GetComponent<PlayerHealth>().health -= damage;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerIcon"))
        {
            isAttacking = true;
        }
    }
}
