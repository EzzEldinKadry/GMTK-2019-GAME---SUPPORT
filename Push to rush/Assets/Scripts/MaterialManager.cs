using System.Collections;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public GameObject effect;
    public float increasePercent = 1.3f;
    GameObject temp;
    void OnTriggerEnter2D(Collider2D other)
    {
        temp = Instantiate(effect, transform);
        StartCoroutine(Coroutine(other));
    }
    IEnumerator Coroutine(Collider2D player)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        player.gameObject.GetComponent<BotManager>().health *= increasePercent;
        yield return new WaitForSeconds(1.3f);
        Destroy(temp);
        Destroy(gameObject);
    }
}
