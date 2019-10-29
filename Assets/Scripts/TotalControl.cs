using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int NOC = 4;
    public GameObject card1, card2, card3, card4;
    public KeyCode showcard1 = KeyCode.R;
    public KeyCode showcard2 = KeyCode.E;
    public KeyCode showcard3 = KeyCode.W;
    public KeyCode showcard4 = KeyCode.Q;
    public KeyCode PressStart = KeyCode.S;
    public int selected;
    public int energyBar = 10;
    public GameManager manager;

    void Start()
    {
        selected = 0;
        card1 = GameObject.Find("card1");
        card2 = GameObject.Find("card2");
        card3 = GameObject.Find("card3");
        card4 = GameObject.Find("card4");
    }

    public void playCard()
    {
        if (selected == 1)
        {
            selected = 0;
            cardBack(card1);
            //do energy stuff here and spawn minion//
            manager.spawnMinion(1, 1);
        }
        else if (selected == 2)
        {
            selected = 0;
            cardBack(card2);
            manager.spawnMinion(1, 2);
        }
        else if (selected == 3)
        {
            selected = 0;
            cardBack(card3);
            //do energy stuff here and spawn minion//
            manager.spawnBuilding(1, 3);
        }
        else if (selected == 4)
        {
            selected = 0;
            cardBack(card4);
            //do energy stuff here and spawn minion//
            manager.spawnBuilding(1, 4);
        }
        else
        {
            //do nothing, no card is played//
        }
    }

    public static void cardRaiseUp(GameObject card)
    {
        card.transform.Translate(0, 1f, 0);
        card.transform.Rotate(new Vector3(90f, 0, 0), Space.Self);
    }

    public static void cardBack(GameObject card)
    {
        card.transform.Rotate(new Vector3(-90f, 0, 0), Space.Self);
        card.transform.Translate(0, -1f, 0);
    }

    public void cardAlter()
    {
        if (selected == 0)
        {
            return;
        }
        if (selected == 1)
        {
            cardBack(card1);
        }
        else if (selected == 2)
        {
            cardBack(card2);
        }
        else if (selected == 3)
        {
            cardBack(card3);
        }
        else if (selected == 4)
        {
            cardBack(card4);
        }
        selected = 0;
    }

    // Update is called once per frame
    void Update()
    {/*
        if (cameraSwitch.decisionPhase == true)
        {
            if (Input.GetKeyDown(showcard4) && selected != 4)
            {
                cardAlter();
                selected = 4;
                cardRaiseUp(card4);
            }
            else if (Input.GetKeyDown(showcard4) && selected == 4)
            {
                selected = 0;
                cardBack(card4);
            }
            else if (Input.GetKeyDown(showcard1) && selected != 1)
            {
                cardAlter();
                selected = 1;
                cardRaiseUp(card1);

            }
            else if (Input.GetKeyDown(showcard1) && selected == 1)
            {
                selected = 0;
                cardBack(card1);
            }
            else if (Input.GetKeyDown(showcard2) && selected != 2)
            {
                cardAlter();
                selected = 2;
                cardRaiseUp(card2);
            }
            else if (Input.GetKeyDown(showcard2) && selected == 2)
            {
                selected = 0;
                cardBack(card2);
            }
            else if (Input.GetKeyDown(showcard3) && selected != 3)
            {
                cardAlter();
                selected = 3;
                cardRaiseUp(card3);
            }
            else if (Input.GetKeyDown(showcard3) && selected == 3)
            {
                selected = 0;
                cardBack(card3);
            }
            else if (Input.GetKeyDown(PressStart))
            {
                playCard();
            }
        }
        else if (cameraSwitch.decisionPhase == false)
        {
            //do nothing//
        }*/
    }
}
