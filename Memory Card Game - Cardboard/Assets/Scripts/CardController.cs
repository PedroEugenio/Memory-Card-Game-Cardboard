using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {

    public bool turnedUp = false;
    Animator anim;

    //[SerializeField] //Enable the change of this variable in the inspector of unity
    public string nameCard;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        turnedUp = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string NameCard
    {
        get
        {
            return nameCard;
        }
        set
        {
            nameCard = value;
        }
    }

    public void Flip()
    {
        if (!turnedUp)
        {
            anim.Play("FlipCard");
            turnedUp = true;
        }
    }

    public void FlipOver()
    {
        if (turnedUp)
        {
            anim.Play("FlipCardOver");
            turnedUp = false;
        }
    }
}
