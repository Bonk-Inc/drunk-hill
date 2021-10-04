using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private int initialHealth;

    public int CurrentHealth { get; private set; }
    public int MaxHealth => maxHealth;

    public bool IsDead => CurrentHealth <= 0;

    public event Action<HealthChangeArgs> OnHealthChange;

    private void Awake() {
        CurrentHealth = initialHealth;
    }

    public void SetHealth(int health){
        int prevHealth = CurrentHealth;
        CurrentHealth = health;
        CallEvent(prevHealth, CurrentHealth);
    }

    public void Heal(int amount){
        SetHealth(CurrentHealth + amount);
    }
    
    public void Damage(int amount){
        SetHealth(CurrentHealth - amount);
    }

    public void Kill(){
        SetHealth(0);
    }

    private void CallEvent(int previousHealth, int newHealth){
        HealthChangeArgs eventArgs = new HealthChangeArgs() {
            newHealth = newHealth,
            previousHealth = previousHealth
        };
        OnHealthChange?.Invoke(eventArgs);
    }

    public class HealthChangeArgs
    {
        public bool IsDead => newHealth <= 0;

        public int newHealth;
        public int previousHealth;
    }

}
