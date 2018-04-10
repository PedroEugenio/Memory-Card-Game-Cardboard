using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCanvas : MonoBehaviour {

    public Text winText;
    // Use this for initialization
    void Start () {
        SetCountText();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetCountText()
    {
        float finishTime = ManagerGame.endTime;
        if (finishTime > 60)
            finishTime /= 60;
        winText.text = "YOU WIN IN: "+ finishTime.ToString()+"s!";
    }
}
