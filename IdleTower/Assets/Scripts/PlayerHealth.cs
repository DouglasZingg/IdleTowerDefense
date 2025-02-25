using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100.0f;
    public float maxHealth = 100.0f;

    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString() + " / " + maxHealth.ToString();

        if (health <= 0)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
