using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public int experience = 0;

    public TMP_Text experienceText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (experience <= 9)
        {
            experienceText.text = "EXP: 0000" + experience.ToString(); ;
        }
        else if (experience < 99)
        {
            experienceText.text = "EXP: 000" + experience.ToString(); ;
        }
        else if (experience < 999)
        {
            experienceText.text = "EXP: 00" + experience.ToString(); ;
        }
        else if (experience < 9999)
        {
            experienceText.text = "EXP: 0" + experience.ToString(); ;
        }
        else
        {
            experienceText.text = "EXP: " + experience.ToString(); ;
        }
    }
}
