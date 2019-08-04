using System.Collections;
using UnityEngine;

public class Boosts : MonoBehaviour
{
    public GameObject effect;
    public float speed = 4;

    GameObject temp;
    Vector3 target;
    bool toTarget = false;

    void Update()
    {
        if (toTarget)
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
   void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Projectile")
            return;
        gameObject.tag = "Projectile";
        StartCoroutine(Coroutine(other));
    }
    IEnumerator Coroutine(Collider2D player)
    {
        target = player.tag == "Player1" ?
            GameObject.FindGameObjectWithTag("Player2").transform.position : GameObject.FindGameObjectWithTag("Player1").transform.position;
        toTarget = true;

        yield return new WaitUntil(() => Vector3.Distance(transform.position, target) <= 0f);
        GetComponent<CircleCollider2D>().isTrigger = false;
        Instantiate(effect, transform);
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);

    }
}
