using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyBehavior : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public GameObject target;

    public GameObject bullet;

    public Transform bulletPosition;

    private float timer;

    public float shootSpeed = 2.0f;
    public float range = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > 3.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
        }
        else
        { 
            timer += Time.deltaTime;

            if (timer > shootSpeed)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }
}
