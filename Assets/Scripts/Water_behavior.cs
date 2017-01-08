using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Water_behavior : MonoBehaviour
{
    public GameObject[] waters;
    public GameObject[] frozenWaters;

    //bool[] waterFrozen = new bool[2];
    Dictionary<GameObject, bool> waterStates;

    public GameObject balance;

    // Use this for initialization
    void Start()
    {
        /*for (int i = 0; i < waterFrozen.Length; i++)
        {
            waterFrozen[i] = true;
        }*/

        waterStates = new Dictionary<GameObject, bool>();
        foreach (GameObject water in waters)
        {
            waterStates.Add(water, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var water in waterStates)
        {
            if (water.Value)
            {
                Debug.Log("water" + water.Key + "is frozen");
            }
        }

        /*for (int i = 0; i < waterFrozen.Length; i++)
        {
            if (waterFrozen[i])
            {
                waters[i].GetComponent<MeshRenderer>().enabled = false;
                frozenWaters[i].GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                balance.GetComponent<BalanceBoard_behavior>().addForce(balance.GetComponent<BalanceBoard_behavior>().weights[i]);
            }
        }*/

        // Left water is frozen
        //if (!waterStates[waters[0]])
        //{
        //    // On ajoute de l'eau de l'autre côté
        //    balance.GetComponent<BalanceBoard_behavior>().addForce(balance.GetComponent<BalanceBoard_behavior>().weights[0]);
        //}

        //// Right water is frozen
        //if (!waterStates[waters[1]])
        //{
        //    // On ajoute plus d'eau de l'autre côté
        //    balance.GetComponent<BalanceBoard_behavior>().addForce(balance.GetComponent<BalanceBoard_behavior>().weights[1]);
        //}
    }

    public void toggleWater(GameObject water, bool state)
    {
        waterStates[water] = state;

        if (!waterStates[waters[1]] && waterStates[waters[0]])
        {
            // appel de fonction pour animation
        }
    }
}
