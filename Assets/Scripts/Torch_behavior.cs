using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Torch_behavior : MonoBehaviour
{
    public GameObject[] torches;
    //bool[] torchLightUp = new bool[5];
    Dictionary<GameObject, bool> torchStates;

    public GameObject balance;
    public GameObject roof;
	public GameObject water1, water2;

    // Use this for initialization
    void Start()
    {
        //for (int i = 0; i < 4; i++)
        //{
        //    torchLightUp[i] = false;
        //}

        torchStates = new Dictionary<GameObject, bool>();
        foreach (GameObject torch in torches)
        {
            torchStates.Add(torch, false);
        }

        roof.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var torch in torchStates)
        {
            if (torch.Value)
            {
                Debug.Log("Torch" + torch.Key + "is lit");
            }
        }
    }

    public void toggleTorch(GameObject torch, bool state)
    {
        torchStates[torch] = state;

        if (VerifyTorches())
        {
            Debug.Log("Bonne combinaison. Actionner balance");

           // balance.GetComponent<Rigidbody>().isKinematic = false;
            //balance.GetComponent<Rigidbody>().useGravity = true;

            /*roof.GetComponent<Water_behavior>().waters[0].GetComponent<MeshRenderer>().enabled = true;
            roof.GetComponent<Water_behavior>().waters[1].GetComponent<MeshRenderer>().enabled = true;
            roof.GetComponent<Water_behavior>().waters[0].GetComponent<CapsuleCollider>().enabled = true;
            roof.GetComponent<Water_behavior>().waters[1].GetComponent<CapsuleCollider>().enabled = true;*/

            roof.SetActive(true);
			water1.SetActive (true);
			water2.SetActive (true);

			balance.GetComponent<Animator> ().SetTrigger ("initBalance");
            //balance.GetComponent<BalanceBoard_behavior>().StartCycle();
        }
    }

    private bool VerifyTorches()
    {
        // La bonne combinaison est d'allumer la 1ere, 2e et 5e torche
        if (torchStates[torches[0]] && torchStates[torches[1]] && !torchStates[torches[2]] && !torchStates[torches[3]] && torchStates[torches[4]])
        {
            return true;
        }

        return false;
    }
}
