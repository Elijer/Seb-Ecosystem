using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth = 8;
    public int currentHealth;
    public HealthBar healthBar;
    public int metabolism = 30;

    void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        InvokeRepeating("Hunger", metabolism, metabolism);
    }

    void Update() {
        //Eat(2);
    }

    void Eat(int calories){
        currentHealth += calories;
        healthBar.SetHealth(currentHealth);
    }

    void Hunger(){
        currentHealth -= 1;
        healthBar.SetHealth(currentHealth);
    }

}
