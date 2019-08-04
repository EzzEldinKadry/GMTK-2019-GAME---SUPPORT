using System.Collections;
using UnityEngine;

public class Boosts : MonoBehaviour
{
    public GameObject effect, projectile;
    GameObject temp;
   void OnTriggerEnter2D(Collider2D other)
    {
        temp = Instantiate(effect, transform);
        StartCoroutine(Coroutine());
    }
    IEnumerator Coroutine()
    {
        Destroy(GetComponentInChildren(typeof(GameObject)));    //destroy particle system
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(temp);
        Instantiate(projectile, transform);
        //yield return WaitUntil(()=>)
        Destroy(gameObject);
    }
}
