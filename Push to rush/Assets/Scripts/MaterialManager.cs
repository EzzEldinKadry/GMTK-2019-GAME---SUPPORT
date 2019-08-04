using System.Collections;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public GameObject effect;
    public float increasePercent = 1.3f;
    GameObject temp;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1" || other.tag == "Player2")
        {
            temp = Instantiate(effect, transform);
            StartCoroutine(Coroutine(other));
        }
    }
    IEnumerator Coroutine(Collider2D player)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        player.gameObject.GetComponent<Player>().InceaseHealth();
        yield return new WaitForSeconds(1.3f);
        Destroy(temp);
        Destroy(gameObject);
    }
}
