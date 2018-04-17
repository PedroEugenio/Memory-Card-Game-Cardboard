using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour {
    private int stepX=1;
    public Vector3 arrowsPos;
    public GameObject arrows;

    public void incrementPositionX()
    {
        this.transform.position = new Vector3(transform.position.x + stepX, transform.position.y, transform.position.z);
        arrowsPos = this.transform.position - new Vector3(3, 0, 0);
        arrows.transform.position = arrowsPos;
        arrows.GetComponent<ArrowsPosition>().SendMessageUpwards("setArrowPosition");
    }
    public void decrementPositionX()
    {
        this.transform.position = new Vector3(transform.position.x - stepX, transform.position.y, transform.position.z);
        arrowsPos = this.transform.position - new Vector3(3, 0, 0);
        arrows.transform.position = arrowsPos;
        arrows.GetComponent<ArrowsPosition>().SendMessageUpwards("setArrowPosition");

    }
}
