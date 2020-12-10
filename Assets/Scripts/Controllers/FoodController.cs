﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : Interactable
{
    [SerializeField] private float foodValue = 1;
    public float FoodValue { get { return foodValue; } }
    [SerializeField] float repopTime = 100f;

    public override void Use(GameObject user)
    {
        if(user.CompareTag("Player"))
        {
            user.GetComponentInChildren<PlayerMouthController>().playerEntityController.EatDNA(foodValue);
            DestroyFood();
        }
    }

    public void DestroyFood()
    {
        Debug.Log("Eat");
        //Destroy(gameObject);
        gameObject.SetActive(false);
        Invoke("ReactiveFood", repopTime);
    }

    private void ReactiveFood()
    {
        gameObject.SetActive(true);
    }

}
