using System.Collections;
using UnityEngine;

public class Boosts : MonoBehaviour
{
    public GameObject effect;
    GameObject temp;
   void OnTriggerEnter2D(Collider other)
    {
        temp = Instantiate(effect, transform);
        StartCoroutine(Coroutine(other));
    }
    IEnumerator Coroutine(Collider player)
    {
        Destroy(GetComponentInChildren(typeof(GameObject)));    //destroy particle system
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(temp);
        Destroy(gameObject);
    }
}
