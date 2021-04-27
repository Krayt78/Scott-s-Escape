﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        AsyncOperation asyncLoad;
        if (other.gameObject.tag.Equals("Player"))
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
