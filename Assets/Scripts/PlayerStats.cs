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

    public void takeDamage(int damage){
        this.health -= damage;
        if(this.health <= 0){
            print("ya fked up boi");
        }
    }

    public void spendCurrency(int cost){
        this.currency -= cost;
    }

    public void receiveCurrency(int currency){
        this.currency += currency;
    }

    
}
