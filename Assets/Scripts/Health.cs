using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public float metabolism = 30f;
    private bool mouthOpen = false;

    void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        InvokeRepeating("Hunger", metabolism, metabolism);
        mouthOpen = false;
    }

    private void OnTriggerEnter(Collider c){
        if (c.gameObject.tag == "food" && mouthOpen == true){
                Eat(2);
                Destroy(c.gameObject, 0);
        }
    }

    void Update() {
        if (Input.GetKey("space")){
            mouthOpen = true;
        } else {
            mouthOpen = false;
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
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
