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

    private void OnTriggerEnter(Collider c){
        //Debug.Log(c.gameObject.tag);
        if (c.gameObject.tag == "food"){
            Debug.Log(c.gameObject.tag);
            Eat(2);
            Destroy(c.gameObject, 0);
            
        }
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
