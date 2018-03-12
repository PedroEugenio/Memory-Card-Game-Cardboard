using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ManagerGame : MonoBehaviour {

    public GameObject[] prefabs;
    private static int rangeMax;
    public int gridX = 4;
    public int gridY = 4;
    public int gridSpace = 2;

    private int numberOfMatches;

    public Transform origin;

    private int[] order;

    private GameObject firstCard = null;
    private GameObject secondCard = null;

    public bool canFlip = true;

    // Use this for initialization
    void Start () {
        generateGrid();
        numberOfMatches = prefabs.Length;
	}
	
	// Update is called once per frame
	void Update () {
        if(GvrPointerInputModule.CurrentRaycastResult.gameObject.tag == "Back" && GvrPointerInputModule.Pointer.TriggerDown && canFlip)
        {
            addCard(GvrPointerInputModule.CurrentRaycastResult.gameObject.transform.parent.gameObject); //Gets the parent of the hitted gameobject (back)
            Debug.Log(GvrPointerInputModule.CurrentRaycastResult.gameObject.name);
        }
        
	}

    private void generateOrderArray()
    {
        int numObjects = prefabs.Length;
        rangeMax = numObjects;
        order = new int[2*numObjects];
        for(int i=0; i< numObjects; i++)
        {
            order[i] = i;
        }
        for (int i = numObjects; i < 2*numObjects; i++)
        {
            order[i] = i-numObjects;
        }
    }

    //Fisher-Yates Shuffle algorithm
    static void Shuffle(int [] array, int n)
    {
        for (int i = 0; i < n; i++)
        { 
            int r = Random.Range(0,rangeMax);
            int t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }

    private void generateGrid()
    {
        generateOrderArray();
        Shuffle(order, 2*rangeMax);
        Vector3 pos = origin.position;
        int counter = 0;
        //Debug.Log("Length="+prefabs.Length);
        for(int i=1; i<=gridX; i++)
        {
            for(int j=1; j <= gridY; j++)
            {
                pos = new Vector3(pos.x, pos.y, pos.z + 1 + gridSpace);
                //Debug.Log("prefab["+order[counter]+"]");
                //Debug.Log("Counter=" + counter);
                var clone = Instantiate(prefabs[order[counter]],pos,Quaternion.Euler(90,0,90));
                clone.name = prefabs[order[counter]].GetComponent<CardController>().nameCard;
                //clone.name = "Card" + i + j;
                counter++;
            }
            pos.z=origin.position.z;
            pos.y += gridSpace + 1 ;
            //manter a posição do z ou x, verificar
        }
    }

    public void decreaseNumberofMatches()
    {
        numberOfMatches--;

        if (numberOfMatches == 0)
        {
            Debug.Log("You WIN!!");
            SceneManager.LoadScene("Menu");
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

    public void addCard(GameObject card)
    {
        if (firstCard == null)
        {
            firstCard = card;
            if (firstCard != null)
            {
                firstCard.GetComponent<CardController>().Flip();
                Debug.Log("First Card Copied!");
            }
            //Debug.Log("Added first card"+firstCard.GetComponent<CardController>().nameCard);
        }
        else
        {
            secondCard = card;
            //Debug.Log("Added second card"+secondCard.GetComponent<CardController>().nameCard);
            if (secondCard != null)
            {
                secondCard.GetComponent<CardController>().Flip();
                Debug.Log("Second Card Copied!");
            }
            canFlip = false;
            if (checkMatch())
            {
                Debug.Log("It's a Match!!");
                decreaseNumberofMatches();
                Reset();
            }
            else
            {
                firstCard.GetComponent<CardController>().FlipOver();
                secondCard.GetComponent<CardController>().FlipOver(); ;
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
