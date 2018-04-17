using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsPosition : MonoBehaviour {
    public GameObject player;

    private void setArrowPosition()
    {
        transform.position = player.transform.position - new Vector3(3,0,0);
    }
    
}
