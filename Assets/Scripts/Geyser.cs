using UnityEngine;
using System.Collections;

public class Geyser : MonoBehaviour {
    public GameObject platform;
    public float increment = 0.2f, difference = 10f;
    float minHeight, maxHeight;
    float platform1Counter = 1, platform1CurrCounter = 0;
    bool augmentPlatform1 = false, platform1CanMove;

	// Use this for initialization
	void Start () {
        generateNewCounter();
        minHeight = platform.transform.position.y - difference;
        maxHeight = platform.transform.position.y + difference;
        platform1CanMove = true;
    }
	
	// Update is called once per frame
	void Update () {

        // PLATFORM 1
        if (platform1CanMove)
        {
            if (augmentPlatform1)
            {
                augmentHeight();
                platform1CurrCounter += increment;
            }
            else
            {
                reduceHeight();
                platform1CurrCounter += increment;
            }
        }
        /*Debug.Log("PLATFORM1 CURR: " + platform1CurrCounter);
        Debug.Log("PLATFORM1: " + platform1Counter);
        Debug.Log("PLATFORM2 CURR: " + platform2CurrCounter);
        Debug.Log("PLATFORM2: " + platform2Counter);
        Debug.Log("PLATFORM3 CURR: " + platform3CurrCounter);
        Debug.Log("PLATFORM3: " + platform3Counter);*/
        verifyCounter();
    }

    void verifyCounter()
    {
        if(platform1Counter <= platform1CurrCounter || platform.transform.position.y >= maxHeight || platform.transform.position.y <= minHeight) { generateNewCounter();}
    }

    void generateNewCounter()
    {
        platform1Counter = Random.Range( 0.5f , (maxHeight - minHeight) /2);
        platform1CurrCounter = 0;
        int temp = Random.Range(0, 2);
        augmentPlatform1 = ( temp == 0);
    }

    void augmentHeight()
    {
        //Debug.Log("Augmenting height of " + platformNumber + " with currentHeight " + platforms[platformNumber].transform.position.y);
        if (platform.transform.position.y >= maxHeight) return;
        Vector3 tempVector = platform.transform.position;
        float temp = tempVector.y +increment;
        tempVector.y = temp;
        platform.transform.position = tempVector;
    }

    void reduceHeight()
    {
        //Debug.Log("Reducing height of " + platformNumber + " with currentHeight " + platforms[platformNumber].transform.position.y);
        if (platform.transform.position.y <= minHeight) return;
        Vector3 tempVector = platform.transform.position;
        float temp = tempVector.y - increment;
        tempVector.y = temp;
        platform.transform.position = tempVector;

    }

    public void toggleCanMove()
    {
            platform1CanMove = !platform1CanMove;
    }
}
