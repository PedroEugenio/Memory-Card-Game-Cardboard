using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour {

    public int rayLength = 50;
    private GameObject firstCard = null;
    private GameObject secondCard = null;

    public bool canFlip = true;

    private ManagerGame man;

    // Use this for initialization
    void Start () {
        man = GameObject.FindWithTag("GameController").GetComponent<ManagerGame>();
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
 
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (Input.GetMouseButtonDown(0) && hit.collider.tag=="Back" && canFlip)
            {
                hit.collider.SendMessageUpwards("Flip"); //Sends message for CardController script to execute Flip function
                //Debug.Log(hit.collider.gameObject.GetComponentInParent<CardController>().nameCard);
                addCard(hit.collider.gameObject.transform.parent.gameObject);

            }
        }    
    }

    private bool checkMatch()
    {
        if (firstCard.GetComponent<CardController>().nameCard == secondCard.GetComponent<CardController>().nameCard)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void addCard(GameObject card)
    {
        if(firstCard == null)
        {
            firstCard = card;
            if(firstCard != null)
            {
                Debug.Log("First Card Copied!");
            }
            //Debug.Log("Added first card"+firstCard.GetComponent<CardController>().nameCard);
        }
        else
        {
            secondCard = card;
            //Debug.Log("Added second card"+secondCard.GetComponent<CardController>().nameCard);
            if (firstCard != null)
            {
                Debug.Log("Second Card Copied!");
            }
            canFlip = false;
            if (checkMatch())
            {
                Debug.Log("It's a Match!!");
                man.decreaseNumberofMatches();
                Reset();
            }
            else
            {
                firstCard.GetComponent<CardController>().SendMessageUpwards("Flip");
                secondCard.GetComponent<CardController>().SendMessageUpwards("Flip");
                Reset();
            }
        }
    }
    public void Reset()
    {
        firstCard = null;
        secondCard = null;
        canFlip = true;
    }
}
