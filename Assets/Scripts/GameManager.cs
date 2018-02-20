using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    [SerializeField]
    int attackNum = 0; //base 0

    [SerializeField]
    int playerCount; //base 1
    [SerializeField]
    Players[] players; //Current Player Count make 2 in Engine


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
            players[i] = Instantiate(players[1]);
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
        currentPlayer++;

        if (currentPlayer > playerCount)
        {
            currentPlayer = 1;
        }
        players[currentPlayer - 1].myCanvas.enabled = true;
    }

    void CheckDeath()
    {
        foreach (Players player in players)
        {
            if(player.Dead)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        //call GameOver Canvas
    }

    
}
