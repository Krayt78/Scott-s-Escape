﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouthController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        FoodController food = other.gameObject.GetComponent<FoodController>();
        if (food)
        {
            food.Use(gameObject);
        }
    }
}
