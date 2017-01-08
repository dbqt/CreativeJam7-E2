using UnityEngine;
using System.Collections;

public class BalanceBoard_behavior : MonoBehaviour
{
    public GameObject[] weights = new GameObject[2];
    public int forceStrengthLeft;
    public int forceStrengthRight; //Strength in Newton of the water going into the buckets.
    float balanceCheckDelay = 2; //Delay in checking balance; prevents solving the puzzle by having the angle briefly skirt around the expected values.
    
    public void StartCycle()
    {
        Invoke("balanceCheck", balanceCheckDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addForce(GameObject forceTarget)
    {
        if (weights[0] == forceTarget)
        {
            Vector3 downwardsForceL = new Vector3(0, forceStrengthLeft, 0);
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(downwardsForceL, forceTarget.transform.position);
        }
        else
        {
            Vector3 downwardsForceR = new Vector3(0, forceStrengthRight, 0);
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(downwardsForceR, forceTarget.transform.position);
        }
    }

    void balanceCheck()
    {
        float errorMarginLow = -0.25f; //Adjust as needed.
        float errorMarginHigh = 0.25f;
        if (errorMarginLow < gameObject.transform.eulerAngles.z && errorMarginHigh > gameObject.transform.eulerAngles.z)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            Debug.Log("Puzzle done"); //Insert trigger after puzzle solved.
        }
    }
}
