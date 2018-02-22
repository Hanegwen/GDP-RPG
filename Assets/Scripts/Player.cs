using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
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

    bool dead = false;

    int damage = 0;

    public Canvas myCanvas;

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
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {

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
        canAttack = true;
    }

    public void OnAttack2Click()
    {
        attackNum = 1;
        canAttack = true;
    }

    public void OnAttack3Click()
    {
        attackNum = 2;
        canAttack = true;
    }

    public void OnAttack4Click()
    {
        attackNum = 3;
        canAttack = true;
    }
}
