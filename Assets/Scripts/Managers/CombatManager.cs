using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    UIManager uiManager;

    [SerializeField]
    public bool attack = false;

    float attackDamage;

    [SerializeField]
    int attackNum = 0; //base 0

    GameObject activePlayer;

    public int currentPlayer; //base 1


    // Use this for initialization
    void Start ()
    {
        uiManager = GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void MoveImage()
    {
        uiManager.playerImages[currentPlayer - 1].gameObject.transform.SetParent(uiManager.players[currentPlayer - 1].myCanvas.gameObject.transform);
        uiManager.playerImages[currentPlayer - 1].gameObject.transform.localPosition = new Vector2(0, 0);
        uiManager.playerImages[currentPlayer - 1].gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (currentPlayer == uiManager.playerCount)
        {
            Debug.Log("Calling 0");
            uiManager.playerImages[0].gameObject.transform.position = new Vector2(2, 0);
            uiManager.playerImages[0].gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            Debug.Log("Calling The Position");
            uiManager.playerImages[currentPlayer].gameObject.transform.position = new Vector2(2, 0);
            uiManager.playerImages[currentPlayer].gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void CombatSystem() //How the Players attack
    {
        uiManager.players[currentPlayer - 1].myCanvas.enabled = true; //Current Players Menu System
        uiManager.playerImages[currentPlayer - 1].SetActive(true); //Current Players Avatar

        MoveImage();

        activePlayer = uiManager.playerImages[currentPlayer - 1];
        attackNum = uiManager.players[currentPlayer - 1].ReturnAttack(); //Keeps track of attack numbers

        if (attack) //When Player clicks a button the attack goes through
        {
            attackDamage = uiManager.players[currentPlayer - 1].Attack(attackNum); //The attack amount
            attackDamage = 10; //Shows Combat Example working
            Debug.Log(attackDamage);
            if (currentPlayer + 1 > uiManager.playerCount) //Checks if next player is past array and then sets him to 0 in case
            {
                uiManager.players[0].TakeDamage(attackDamage);
            }

            else //Deals damage to the next player
            {
                uiManager.players[currentPlayer].TakeDamage(attackDamage);
            }

            uiManager.players[currentPlayer - 1].canAttack = false; // Stops attacking

            NextPlayer(); //Calls the next player
        }

    }

    void NextPlayer() //When a Player attacks the next player in the list becomes the active player
    {
        uiManager.players[currentPlayer - 1].myCanvas.enabled = false;
        //playerImages[currentPlayer - 1].SetActive(false);
        currentPlayer++;

        if (currentPlayer > uiManager.playerCount)
        {
            currentPlayer = 1;
        }
        uiManager.players[currentPlayer - 1].myCanvas.enabled = true;
    }
}
