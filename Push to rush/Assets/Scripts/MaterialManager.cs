using System.Collections;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public GameObject effect;
    GameObject temp;
    void OnTriggerEnter2D(Collider2D other)
    {
        temp = Instantiate(effect, transform);
        StartCoroutine(Coroutine(other));
    }
    IEnumerator Coroutine(Collider2D player)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        player.gameObject.GetComponent<BotManager>().health *= 1.3f;
        yield return new WaitForSeconds(1.3f);
        Destroy(temp);
        Destroy(gameObject);
    }
}
