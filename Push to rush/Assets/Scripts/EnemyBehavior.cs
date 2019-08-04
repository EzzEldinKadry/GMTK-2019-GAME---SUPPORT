using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0,-180,0);
    }

}
