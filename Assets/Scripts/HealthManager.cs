using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 3;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts)
        { 
            img.sprite = emptyHearts;
        }

        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHearts;
        }


    }
}
