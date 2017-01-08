using UnityEngine;
using System.Collections;

public class Geyser : MonoBehaviour {
    public GameObject[] platforms;
    public float minHeight = 0f, maxHeight = 10f, increment = 0.01f;
    float platform1Counter = 1, platform1CurrCounter = 0, platform2Counter = 1, platform2CurrCounter = 0, platform3Counter = 1, platform3CurrCounter = 0;
    bool augmentPlatform1 = false, augmentPlatform2 = false, augmentPlatform3 = false, platform1CanMove, platform2CanMove, platform3CanMove;

	// Use this for initialization
	void Start () {
        generateNewCounter(1);
        generateNewCounter(2);
        generateNewCounter(3);
        platform1CanMove = true;
        platform2CanMove = true;
        platform3CanMove = true;
    }
	
	// Update is called once per frame
	void Update () {

        // PLATFORM 1
        if (platform1CanMove)
        {
            if (augmentPlatform1)
            {
                augmentHeight(1);
                platform1CurrCounter += increment;
            }
            else
            {
                reduceHeight(1);
                platform1CurrCounter += increment;
            }
        }

        // PLATFORM 2
        if (platform2CanMove)
        {
            if (augmentPlatform2) {
                augmentHeight(2);
                platform2CurrCounter += increment;
            } else {
                reduceHeight(2);
                platform2CurrCounter += increment;
            }
        }

        // PLATFORM 3
        if (platform3CanMove)
        {
            if (augmentPlatform3)
            {
                augmentHeight(3);
                platform3CurrCounter += increment;
            }
            else
            {
                reduceHeight(3);
                platform3CurrCounter += increment;
            }
        }
        /*Debug.Log("PLATFORM1 CURR: " + platform1CurrCounter);
        Debug.Log("PLATFORM1: " + platform1Counter);
        Debug.Log("PLATFORM2 CURR: " + platform2CurrCounter);
        Debug.Log("PLATFORM2: " + platform2Counter);
        Debug.Log("PLATFORM3 CURR: " + platform3CurrCounter);
        Debug.Log("PLATFORM3: " + platform3Counter);*/
        verifyCounters();
    }

    void verifyCounters()
    {
        if(platform1Counter <= platform1CurrCounter || platforms[0].transform.position.y >= maxHeight || platforms[0].transform.position.y <= minHeight) { generateNewCounter(1);}
        if (platform2Counter <= platform2CurrCounter || platforms[1].transform.position.y >= maxHeight || platforms[1].transform.position.y <= minHeight) { generateNewCounter(2);}
        if (platform3Counter <= platform3CurrCounter || platforms[2].transform.position.y >= maxHeight || platforms[2].transform.position.y <= minHeight) { generateNewCounter(3);}
    }

    void generateNewCounter(int nb)
    {
        switch (nb)
        {
            case 1:
                platform1Counter = Random.Range( 0.5f , (maxHeight - minHeight) /2);
                platform1CurrCounter = 0;
                int temp = Random.Range(0, 2);
                augmentPlatform1 = ( temp == 0);
                break;
            case 2:
                platform2Counter = Random.Range(0.5f, (maxHeight - minHeight)/2);
                platform2CurrCounter = 0;
                augmentPlatform2 = (Random.Range(0, 2) == 0);
                break;
            case 3:
                platform3Counter = Random.Range(0.5f, (maxHeight - minHeight)/2);
                platform3CurrCounter = 0;
                augmentPlatform3 = (Random.Range(0, 2) == 0);
                break;
        }
    }

    void augmentHeight(int platformNumber)
    {
        platformNumber--;
        //Debug.Log("Augmenting height of " + platformNumber + " with currentHeight " + platforms[platformNumber].transform.position.y);
        if (platforms[platformNumber].transform.position.y >= maxHeight) return;
        Vector3 tempVector = platforms[platformNumber].transform.position;
        float temp = tempVector.y +increment;
        tempVector.y = temp;
        platforms[platformNumber].transform.position = tempVector;
    }

    void reduceHeight(int platformNumber)
    {
        platformNumber--;
        //Debug.Log("Reducing height of " + platformNumber + " with currentHeight " + platforms[platformNumber].transform.position.y);
        if (platforms[platformNumber].transform.position.y <= minHeight) return;
        Vector3 tempVector = platforms[platformNumber].transform.position;
        float temp = tempVector.y - increment;
        tempVector.y = temp;
        platforms[platformNumber].transform.position = tempVector;

    }

    public void toggleCanMove(int platformNb)
    {
        switch (platformNb)
        {
            case 1:
                platform1CanMove = !platform1CanMove;
                break;
            case 2:
                platform2CanMove = !platform2CanMove;
                break;
            case 3:
                platform3CanMove = !platform3CanMove;
                break;
        }
    }
}
