using System.Collections;
using UnityEngine;
using Pathfinding;
public class BotManager : MonoBehaviour
{
    AIDestinationSetter destination;
    Transform target;
    AIPath aIPath;
    Rigidbody2D rb;
    Animator animator;
    
    float initialY, floatingTime = 0;
    bool isGrounded = false;

    public float fallMultiplier = 2.5f;
    public float health = 100, jumpTime = 2;
    public Transform Enemy;
    void Start()
    {
        destination = GetComponent<AIDestinationSetter>();
        aIPath = GetComponent<AIPath>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        initialY = transform.position.y;
        InvokeRepeating("Search", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (aIPath.desiredVelocity.x >= 0.01f)
        {
            transform.rotation = Quaternion.identity;
        }
        else if (aIPath.desiredVelocity.x <= -0.01f)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        if (isGrounded)
        {
            floatingTime += Time.deltaTime;
        }
        if(!isGrounded && floatingTime > jumpTime)
        {
            print("enzel");
            StartCoroutine(ResumeDestination());
        }
        if (Vector3.Distance(transform.position, Enemy.transform.position) <= 8f)
        {
            StartCoroutine(Attack());
        }
        //print(Vector3.Distance(transform.position, Enemy.transform.position));
        animator.SetFloat("speed", Mathf.Abs(aIPath.desiredVelocity.x));
        health = Mathf.Clamp(health, 0, health - Time.deltaTime);       
    }

    void Search()
    {
        GameObject[] Pickup;
        if (floatingTime >= jumpTime)
            return;

        if (health < 80f || destination.target == null)
        {
            Pickup = GameObject.FindGameObjectsWithTag("Material");
            if (Pickup.Length == 0)
                return;

            target = FindNearestMaterial(Pickup);
        }
        else
        {
            Pickup = GameObject.FindGameObjectsWithTag("Boosts");
            if (Pickup.Length == 0)
                return;

            target = FindNearestMaterial(Pickup);
        }
        destination.target = target;
    }
    Transform FindNearestMaterial(GameObject[] Material)
    {
        float minDistance = Vector3.Distance(transform.position, Material[0].transform.position);
        int minIndex = 0;
        for(int i = 1;i < Material.Length;++i)
        {
            float temp = Vector3.Distance(transform.position, Material[i].transform.position);
            if (temp < minDistance)
            {
                minDistance = temp;
                minIndex = i;
            }

        }
        return Material[minIndex].transform;
    }
    IEnumerator ResumeDestination()
    {
        GetComponent<AIPath>().canMove = false;
        yield return new WaitUntil(() => isGrounded);
        GetComponent<AIPath>().canMove = true;
        floatingTime = 0;
    }

    IEnumerator Attack()
    { 
        animator.SetTrigger("attack");
        yield return new WaitForSeconds(0.07f);
        print("attack");
        animator.ResetTrigger("attack");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            floatingTime = 0;
            isGrounded = true;
            print("reset");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
            print("set");
        }
    }
}
