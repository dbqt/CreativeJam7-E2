using UnityEngine;
using System.Collections;

public class Raft_behavior : MonoBehaviour
{
    public GameObject raft;
    public GameObject weight;
    public GameObject Corner1, Corner2, Corner3, Corner4;
    public int limitY;
    public float spawnDelay;

    // Use this for initialization
    void Start()
    {
        spawnWeight();
    }

    // Update is called once per frame
    void Update()
    {
        if (Corner1.transform.position.y < limitY && Corner2.transform.position.y < limitY && Corner3.transform.position.y < limitY && Corner4.transform.position.y < limitY)
        {
            Time.timeScale = 0;
            Debug.Log("You have dishonored your ancestors");
        }
    }

    void spawnWeight()
    {
        Vector3 position = new Vector3(Random.Range(Corner3.transform.position.x, Corner1.transform.position.x), 500, Random.Range(Corner1.transform.position.z, Corner3.transform.position.z));
        Instantiate(weight, position, Quaternion.identity);
        Invoke("spawnWeight", spawnDelay);
        Debug.Log(position);
    }
}
