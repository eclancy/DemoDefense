using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private playerHealth;
    private playerCurrency;


    void Start()
    {
        this.playerHealth = 100;
        this.playerCurrency = 50;
    }

    int getHealth(){
        return this.playerHealth;
    }

    int getCurrency(){
        return this.playerCurrency;
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
