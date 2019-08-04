using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public float[] Constraints = new float[2];
    public float respawnTime = 3f;
    public GameObject pickup;
    void Start()
    {
        InvokeRepeating("Spawn", 0, respawnTime);
    }
    void Spawn()
    {
        int spawn = Random.Range(1, 2);
        print(spawn);
        float rand_x = Random.Range(Constraints[0], Constraints[1]);
        if (spawn == 1)
            Instantiate(pickup, new Vector3(rand_x, transform.position.y, transform.position.z), transform.rotation);
    }
}
