using Pathfinding;
using UnityEngine;

public class BotGFX : MonoBehaviour
{
    AIPath aIPath;
    Vector3 localScale;
    void Start()
    {
        aIPath = GetComponent<AIPath>();
    }
    void Update()
    {
        if(aIPath.desiredVelocity.x >= 0.01f)
        {
            transform.rotation = Quaternion.identity;
        }
        else if(aIPath.desiredVelocity.x <= -0.01f)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }
}
