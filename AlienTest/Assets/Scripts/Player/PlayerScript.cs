using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Setup")]
    public Transform Player;
    public float PlayerHealth = 100;
    public float PlayerMaxHealth = 100;
    [Header("Game Specific Setup")]
    public float AwarenessLevel = 0;
    public float AwarenessMax = 100;
    [Header("Respawn Settings")]
    public bool CanRespawn = true;
    public Transform RespawnPoint;
    public DeathTypes lastDamage = DeathTypes.Unknown;
    public IDictionary<StatusEffects.StatusEffect, int> CurrentStatusEffects = new Dictionary<StatusEffects.StatusEffect, int>();
    //private members
    void Start()
    {

    }
    void Update()
    {
        if (PlayerHealth == 0f)
        {
            Kill(lastDamage);
        }
    }
    public void Kill(DeathTypes death = DeathTypes.Unknown)
    {
        //blah blah death screen
        CurrentStatusEffects.Clear();
        Respawn();
    }
    public void Respawn()
    {
        if (CanRespawn)
        {
            Player.position = RespawnPoint.position;
            PlayerHealth = PlayerMaxHealth;
            lastDamage = DeathTypes.Unknown;
        }
        else
        {
            //no respawn code.
        }
    }
    public void Damage(float damage)
    {
        if (PlayerHealth - damage < 0)
        {
            PlayerHealth = 0;
            UnityEngine.Debug.Log("Player has died!");
        }
        else
        {
            PlayerHealth -= damage;
            UnityEngine.Debug.Log("Dealt: " + damage.ToString() + " damage to the player.");
        }
    }
    public void Heal(float health, bool allowoverheal)
    {
        if (allowoverheal)
        {
            PlayerHealth += health;
        }
        else
        {
            if (PlayerHealth + health > 100)
            {
                PlayerHealth = 100;
            }
        }
    }
    public void SetHealth(float health)
    {
        PlayerHealth = health;
    }
    public enum DeathTypes
    {
        Suicide,
        Burning,
        Poison,
        Unknown,
        GameOver,
        Attacked,
        FallDamage,
        Electrecuted,
    }
    public void RemoveEffect(StatusEffects.StatusEffect effect)
    {
        CurrentStatusEffects.Remove(effect);
    }
    public void AddEffect(StatusEffects.StatusEffect effect, int duration)
    {
        if (CurrentStatusEffects.ContainsKey(effect))
        {
            CurrentStatusEffects[effect] += duration;
        }
        else
        {
            CurrentStatusEffects.Add(effect, duration);
        }
    }
}
