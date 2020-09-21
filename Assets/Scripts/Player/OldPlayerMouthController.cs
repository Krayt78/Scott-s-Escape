﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerMouthController : MonoBehaviour
{

    public VrPlayerEntityController vrPlayerEntityController;

    private void OnTriggerEnter(Collider other)
    {
        FoodController food = other.gameObject.GetComponent<FoodController>();
        if (food)
        {
            food.Use(gameObject);
        }
    }
}
