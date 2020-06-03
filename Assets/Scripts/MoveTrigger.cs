using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    public bool TouchingWall;
    public bool TouchingDeath;
    public bool TouchingCoin;
    public bool TouchingEnemy;
    public bool TouchingPortal;

    public GameObject ColObj;


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            TouchingWall = true;
        } else
        {
            TouchingWall = false;
        }

        if (other.tag == "Death")
        {
            TouchingDeath = true;
        }
        else
        {
            TouchingDeath = false;
        }

        if (other.tag == "Coin")
        {
            TouchingCoin = true;
        }
        else
        {
            TouchingCoin = false;
        }

        if (other.tag == "Enemy")
        {
            TouchingEnemy = true;
        }
        else
        {
            TouchingEnemy = false;
        }

        if (other.tag == "Portal")
        {
            TouchingPortal = true;
        }
        else
        {
            TouchingPortal = false;
        }

        ColObj = other.gameObject;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        TouchingWall = false;
        TouchingDeath = false;
        TouchingCoin = false;
        TouchingEnemy = false;
        TouchingPortal = false;

    }
}

