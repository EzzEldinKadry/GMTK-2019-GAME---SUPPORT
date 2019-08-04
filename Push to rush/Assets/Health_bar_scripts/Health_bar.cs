using UnityEngine;
using UnityEngine.UI;

public class Health_bar : MonoBehaviour
{
    Image health_bar;
    float max_health = 100f;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        health_bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        health_bar.fillAmount = player.getHealth() / max_health;
    }
}
