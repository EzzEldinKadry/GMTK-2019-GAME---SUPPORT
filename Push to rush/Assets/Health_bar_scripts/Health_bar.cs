using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_bar : MonoBehaviour
{
    Image health_bar;
    float max_health = 100f;
    public static float health;
    // Start is called before the first frame update
    void Start()
    {
        health_bar = GetComponent<Image>();
        health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        health_bar.fillAmount = health / max_health;
    }
}
