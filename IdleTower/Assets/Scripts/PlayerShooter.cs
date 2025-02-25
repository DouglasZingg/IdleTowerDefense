using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bullet;
    public GameObject enemy;

    public Transform bulletPosition;

    private float timer;

    public float shootSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            Debug.Log(distance);

            if (distance < 10f)
            {
                timer += Time.deltaTime;

                if (timer > shootSpeed)
                {
                    timer = 0;
                    Shoot();
                }
            }
        }
        else
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }
}
