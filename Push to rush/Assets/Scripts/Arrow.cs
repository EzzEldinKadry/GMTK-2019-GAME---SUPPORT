using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    bool isTrigger = false;
    void Update()
    {
        if(isTrigger)
        {
            gameObject.GetComponentInChildren<PolygonCollider2D>().isTrigger = false;
            Destroy(this.gameObject,0.05f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Player1" || other.tag == "Player2")
        {
            Vector2 pushDirection = new Vector2
            (transform.position.x/Mathf.Abs(transform.position.x),transform.position.y/Mathf.Abs(transform.position.y));
            print(pushDirection);
            isTrigger = true;
        }
    }
}
