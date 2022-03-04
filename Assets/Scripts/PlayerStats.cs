using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int health;
    public int currency;

    void Start()
    {
        this.health = 100;
        this.currency = 50;
    }

    void takeDamage(int damage){
        this.health -= damage;
    }

    void spendCurrency(int cost){
        this.currency -= cost;
    }

    void receiveCurrency(int currency){
        this.currency += currency;
    }

    
}
