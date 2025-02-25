using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    private GameObject manager;

    public float health = 1.0f;
    public float maxHealth = 1.0f;

    public TMP_Text healthText;

    public int experienceReward = 1;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("Managers");
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString() + " / " + maxHealth.ToString();

        if(health <= 0)
        {
            manager.GetComponent<ExperienceManager>().experience += experienceReward;
            Destroy(gameObject);
        }
    }
}
