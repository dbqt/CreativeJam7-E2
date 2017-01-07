using UnityEngine;
using System.Collections;

public class Candle_behavior : MonoBehaviour {
    public GameObject[] candles;
    bool[] candleLightUp = new bool[5];

    // Use this for initialization
    void Start() {
        for (int i = 0; i < 4; i++)
        {
            candleLightUp[i] = false;
        }
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < 5; i++)
        {
          if (candleLightUp[i] == true)
            {
                Debug.Log("Candle" + i + "is lit");
                //couleur vert pour cube
            }
          //couleur rouge pour cube
        }
    }


public void toggleCandle(int candleNumber) {
        candleLightUp[candleNumber] = !candleLightUp[candleNumber];
    }
}
