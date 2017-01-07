using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Torch_behavior : MonoBehaviour
{
    public GameObject[] torches;
    bool[] torchLightUp = new bool[5];
    Dictionary<GameObject, bool> torchStates;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            torchLightUp[i] = false;
        }

        torchStates = new Dictionary<GameObject, bool>();
        foreach (GameObject torch in torches)
        {
            torchStates.Add(torch, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var torch in torchStates)
        {
            if (torch.Value)
            {
                Debug.Log("Torch" + torch.Key + "is lit");
                //couleur vert pour cube
            }
            //couleur rouge pour cube
        }

        if (VerifyTorches())
        {
            Debug.Log("Bonne combinaison. Actionner balance");
        }
    }

    public void toggleTorch(GameObject torch)
    {
        torchStates[torch] = !torchStates[torch];
    }

    private bool VerifyTorches()
    {
        // La bonne combinaison est d'allumer la 1ere, 2e et 5e torche
        if (torchStates[torches[0]] && torchStates[torches[1]] && torchStates[torches[4]])
        {
            return true;
        }

        return false;
    }
}
