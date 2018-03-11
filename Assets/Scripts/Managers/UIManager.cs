using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject[] playerImages = new GameObject[2];
    [SerializeField]
    public int playerCount; //base 1

    [SerializeField]
    public Player[] players; //Current Player Count make 2 in Engine

    bool choosingState = true;

    [SerializeField]
    GameObject[] imageOptions;

    int currentImage = 0;

    int playerChoosing = 0;

    [SerializeField]
    Transform imageLocation;

    [SerializeField]
    Canvas DeathCanvas;

    [SerializeField]
    Canvas playerSelectCanvas;

    [SerializeField]
    Text playerNumber;

    CombatManager combatManager;

    // Use this for initialization
    void Start ()
    {
        combatManager = GetComponent<CombatManager>();
        playerCount = players.Length;

        foreach (GameObject o in imageOptions)
        {
            //Instantiate(o, imageLocation.transform.position,Quaternion.identity, null);
            //Instantiate(o, imageLocation);
            o.GetComponent<SpriteRenderer>().enabled = false;
            o.transform.SetAsFirstSibling();
        }

        imageOptions[0].GetComponent<SpriteRenderer>().enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (choosingState)
        {
            ChoosingUI();
        }

        if (!choosingState)
        {
            combatManager.attack = players[combatManager.currentPlayer - 1].canAttack;
            combatManager.CombatSystem();
            CheckDeath();
        }

        

    }

    void ChoosingUI()
    {
        playerNumber.text = "Player" + (playerChoosing + 1);
    }

    public void PickImage()
    {
        playerImages[playerChoosing] = imageOptions[currentImage];

        playerChoosing++;

        if (playerChoosing > 1)
        {
            for (int i = 0; i < playerCount; i++) //On Start the Players are created
            {
                players[i] = Instantiate(players[i]);
                players[i].myPlayerNumber = i + 1;
                playerImages[i] = Instantiate(playerImages[i]);
                playerImages[i].GetComponent<SpriteRenderer>().enabled = true;
                //playerImages[i].SetActive(false);

            }
            playerSelectCanvas.enabled = false;
            choosingState = false;


            foreach (GameObject o in imageOptions)
            {
                //Instantiate(o, imageLocation.transform.position,Quaternion.identity, null);
                //Instantiate(o, imageLocation);
                o.GetComponent<SpriteRenderer>().enabled = false;
                o.transform.SetAsFirstSibling();
            }
        }

    }

    public void NextButton()
    {
        

        imageOptions[currentImage].GetComponent<SpriteRenderer>().enabled = false;
        currentImage++;
        if (currentImage >= imageOptions.Length)
        {
            currentImage = 0;
        }
        imageOptions[currentImage].GetComponent<SpriteRenderer>().enabled = true;


    }

    void GameOver(string playerName) //Calls the end screen
    {
        DeathCanvas.transform.GetComponentInChildren<Text>().text = playerName + " has died";
        DeathCanvas.enabled = true;
    }

    void CheckDeath() //Check if a player is dead, if so other person wins
    {
        foreach (Player player in players)
        {
            if (player.Dead)
            {
                GameOver(player.name);
            }
        }
    }
}
