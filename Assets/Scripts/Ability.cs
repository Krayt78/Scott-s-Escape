﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public PlayerDNALevel PlayerDNALevel { get; private set; }
    public PlayerInput PlayerInput { get; private set; }


    public virtual void Awake()
    {
        PlayerDNALevel = GetComponent<PlayerDNALevel>();
        PlayerInput = GetComponent<PlayerInput>();
       
    }

    public virtual void Start()
    {
        LevelChanged(0);
        PlayerDNALevel.OnCurrentLevelChanged += LevelChanged;
    }

    public abstract void LevelChanged(int level);
    public abstract void UseAbility();
}
