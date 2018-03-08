using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    Canvas DeathCanvas;

    [SerializeField]
    int attackNum = 0; //base 0

    [SerializeField]
    int playerCount; //base 1
    
    [SerializeField]
    Player[] players; //Current Player Count make 2 in Engine

    [SerializeField]
    GameObject[] playerImages;

    [SerializeField]
    Sprite[] imageOptions;

    

    int currentImage = 0;

    int playerChoosing = 0;

    [SerializeField]
    Transform imageLocation;


    GameObject activePlayer;

    public int currentPlayer; //base 1

    [SerializeField]
    bool attack = false;

    float attackDamage;

    [SerializeField]
    Text playerNumber;

    bool choosingState = true;

    // Use this for initialization
    void Start ()
    {
        playerCount = players.Length;

        for (int i = 0; i < playerCount; i++) //On Start the Players are created
        {
            players[i] = Instantiate(players[i]);
            players[i].myPlayerNumber = i + 1;
            playerImages[i] = Instantiate(playerImages[i]);
            //playerImages[i].SetActive(false);
        }

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
            attack = players[currentPlayer - 1].canAttack;
            CombatSystem();
            CheckDeath();
        }
        
	}

    void ChoosingUI()
    {

    }

    public void PickImage()
    {
        playerImages[playerChoosing].GetComponent<Sprite>() = imageOptions[currentImage];

        playerChoosing++;
    }

    public void NextButton()
    {
        imageOptions[currentImage].SetActive(false);
        currentImage++;
        if (currentImage > playerImages.Length)
        {
            currentImage = 0;
        }
        imageOptions[currentImage].SetActive(true);
        
    }

    void MoveImage()
    {
        playerImages[currentPlayer - 1].gameObject.transform.position = new Vector2(0,0);
        playerImages[currentPlayer - 1].gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (currentPlayer == playerCount)
        {
            Debug.Log("Calling 0");
            playerImages[0].gameObject.transform.position = new Vector2(2, 0);
            playerImages[0].gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            Debug.Log("Calling The Position");
            playerImages[currentPlayer].gameObject.transform.position = new Vector2(2, 0);
            playerImages[currentPlayer].gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void CombatSystem() //How the Players attack
    {
        players[currentPlayer - 1].myCanvas.enabled = true; //Current Players Menu System
        playerImages[currentPlayer - 1].SetActive(true); //Current Players Avatar

        MoveImage();

        activePlayer = playerImages[currentPlayer - 1];
        attackNum = players[currentPlayer - 1].ReturnAttack(); //Keeps track of attack numbers

        if (attack) //When Player clicks a button the attack goes through
        {
            attackDamage = players[currentPlayer - 1].Attack(attackNum); //The attack amount
            attackDamage = 10; //Shows Combat Example working
            Debug.Log(attackDamage);
            if(currentPlayer + 1 > playerCount) //Checks if next player is past array and then sets him to 0 in case
            {
                players[0].TakeDamage(attackDamage);
            }

            else //Deals damage to the next player
            {
                players[currentPlayer].TakeDamage(attackDamage);
            }

            players[currentPlayer - 1].canAttack = false; // Stops attacking

            NextPlayer(); //Calls the next player
        }

    }

    void NextPlayer() //When a Player attacks the next player in the list becomes the active player
    {
        players[currentPlayer - 1].myCanvas.enabled = false;
        //playerImages[currentPlayer - 1].SetActive(false);
        currentPlayer++;

        if (currentPlayer > playerCount)
        {
            currentPlayer = 1;
        }
        players[currentPlayer - 1].myCanvas.enabled = true;
    }

    void CheckDeath() //Check if a player is dead, if so other person wins
    {
        foreach (Player player in players)
        {
            if(player.Dead)
            {
                GameOver(player.name);
            }
        }
    }

    void GameOver(string playerName) //Calls the end screen
    {
        DeathCanvas.transform.GetComponentInChildren<Text>().text = playerName + " has died";
        DeathCanvas.enabled = true;
    }

    
}
