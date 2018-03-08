using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField]
    Text playerNumberText;

    public Slider Health_Slider;

    [SerializeField]
    public int Health;
    [SerializeField]
    public int Damage;
    [SerializeField]
    public int Armor;
    [SerializeField]
    public int Healing;
    public enum attacks { test1, test2, test3, test4 };

    public attacks currentAttack;

    public bool canAttack;

    int attackNum;

    int attack2Num; //Negative Effect

    public bool dead = false;

    int damage = 0;

    public Canvas myCanvas;

    public GameObject PositiveButtons;

    public int myPlayerNumber;

    public bool Dead
    {
        get
        {
            return dead;
        }
    }

    // Use this for initialization
    void Start()
    {
        myCanvas.enabled = false;
        GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {

        playerNumberText.text = "Player: " + myPlayerNumber.ToString();
        if(Health <= 0)
        {
            dead = true;
        }

        SetHealthUI();
    }

    private void SetHealthUI()
    {
        Health_Slider.value = Health;
    }

    public void TakeDamage(float damage)
    {
        Health -= (int)damage;
    }

    public float Attack(int attackValue)
    {

        return damage;
    }

    public int ReturnAttack()
    {
        return attackNum;
    }

    public void OnAttack1Click()
    {
        attackNum = 0;
        PositiveButtons.SetActive(false);
        //myCanvas.enabled = false;
        //canAttack = true; //Only Temp

    }

    public void OnAttack2Click()
    {
        attackNum = 1;
        PositiveButtons.SetActive(false);
        //myCanvas.enabled = false;
        //canAttack = true; //Only Temp

    }

    public void OnAttack3Click()
    {
        attackNum = 2;
        PositiveButtons.SetActive(false);
        //myCanvas.enabled = false;
        //canAttack = true; //Only Temp

    }

    public void OnAttack4Click()
    {
        attackNum = 3;
        PositiveButtons.SetActive(false);
        //myCanvas.enabled = false;
        //canAttack = true; //Only Temp
    }

    public void OnAttack2Click1()
    {
        attack2Num = 0;
        PositiveButtons.SetActive(true);
        canAttack = true;
    }

    public void OnAttack2Click2()
    {
        attack2Num = 1;
        PositiveButtons.SetActive(true);
        canAttack = true;
    }

    public void OnAttack2Click3()
    {
        attack2Num = 2;
        PositiveButtons.SetActive(true);
        canAttack = true;
    }

    public void OnAttack2Click4()
    {
        attack2Num = 3;
        PositiveButtons.SetActive(true);
        canAttack = true;
    }
}
