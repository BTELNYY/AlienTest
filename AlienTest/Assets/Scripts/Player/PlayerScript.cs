using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Setup")]
    public int PlayerHealth = 100;
    public int PlayerMaxHealth = 100;
    [Header("Game Specific Setup")]
    public float AwarenessLevel = 0;
    public float AwarenessMax = 100;
    [Header("Respawn Settings")]
    public bool CanRespawn = true;
    public Transform RespawnPoint;
    public int RespawnDelay;
    public DeathTypes lastDamage;
    public IDictionary<StatusEffects.StatusEffect, int> CurrentStatusEffects = new Dictionary<StatusEffects.StatusEffect, int>();
    //private members
    System.Timers.Timer timer;
    void SetTimer(int tick)
    {
        timer = new System.Timers.Timer(tick);
        timer.AutoReset = true;
        timer.Enabled = true;
    }
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
    void Kill(DeathTypes death = DeathTypes.Unknown)
    {

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
}
