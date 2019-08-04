using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float health = 100f;
    public float decreaseHealthFactor = 2f;
    public float increaseHealthFactor = 1.3f;
    public GameObject panel;
    
    bool die = false;
    Animator animator;
    Text winner;
    void Start()
    {
        animator = GetComponent<Animator>();
        winner = panel.GetComponentInChildren<Text>();
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, health - (Time.deltaTime * decreaseHealthFactor));
        if(health <= 40f)
            decreaseHealthFactor = Mathf.Clamp(decreaseHealthFactor, 2, (decreaseHealthFactor - Time.deltaTime));
        if (health == 0 && !die)
        {
            die = true;
            StartCoroutine(GameOver());
        }

    }
    public void InceaseHealth()
    {
        health *= increaseHealthFactor;
    }
    public float getHealth()
    {
        return health;
    }
    IEnumerator GameOver()
    {
        animator.SetTrigger("die");
        yield return new WaitForSeconds(0.3f);
        animator.ResetTrigger("die");
        panel.SetActive(true);
        winner.text = "Game over";
        Destroy(gameObject, 0.5f);
    }
}
