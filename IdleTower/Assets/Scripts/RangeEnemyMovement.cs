using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyMovement : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public GameObject target;

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
    }
}
