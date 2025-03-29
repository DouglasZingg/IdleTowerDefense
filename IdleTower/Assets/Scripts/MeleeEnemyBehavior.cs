using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemyBehavior : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public GameObject target;

    public float damage;

    private float timer;

    public float attackSpeed = 4.0f;

    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance >= .63f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
        }
        else
        {
            timer += Time.deltaTime;

            if (timer > attackSpeed)
            {
                timer = 0;
                target.GetComponent<PlayerHealth>().health -= damage;
            }
        }
    }
}
