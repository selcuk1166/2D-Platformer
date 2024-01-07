using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance;
    public int currentHealth , maxHealth;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DealDamage()
    {
        currentHealth -= 1;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);

            PlayerController.instance.KnockBack();
        }
        UIController.instance.UpdateHealthDisplay();
    }
}
