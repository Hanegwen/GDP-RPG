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


    GameObject activePlayer;

    public int currentPlayer; //base 1

    [SerializeField]
    bool attack = false;

    float attackDamage;

	// Use this for initialization
	void Start ()
    {
        playerCount = players.Length;

        for (int i = 0; i < playerCount; i++)
        {
            players[i] = Instantiate(players[i]);
            playerImages[i] = Instantiate(playerImages[i]);
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        attack = players[currentPlayer - 1].canAttack;

        CombatSystem();
        CheckDeath();
        
	}

    void CombatSystem()
    {
        players[currentPlayer - 1].myCanvas.enabled = true;
        playerImages[currentPlayer - 1].SetActive(true);
        activePlayer = playerImages[currentPlayer - 1];
        attackNum = players[currentPlayer - 1].ReturnAttack();

        if (attack)
        {
            attackDamage = players[currentPlayer - 1].Attack(attackNum);
            if(currentPlayer + 1 > playerCount)
            {
                players[0].TakeDamage(attackDamage);
            }

            else
            {
                players[currentPlayer].TakeDamage(attackDamage);
            }

            players[currentPlayer - 1].canAttack = false;

            NextPlayer();
        }

    }

    void NextPlayer()
    {
        players[currentPlayer - 1].myCanvas.enabled = false;
        playerImages[currentPlayer - 1].SetActive(false);
        currentPlayer++;

        if (currentPlayer > playerCount)
        {
            currentPlayer = 1;
        }
        players[currentPlayer - 1].myCanvas.enabled = true;
    }

    void CheckDeath()
    {
        foreach (Player player in players)
        {
            if(player.Dead)
            {
                GameOver(player.name);
            }
        }
    }

    void GameOver(string playerName)
    {
        DeathCanvas.transform.GetComponentInChildren<Text>().text = playerName + " has died";
        DeathCanvas.enabled = true;
    }

    
}
