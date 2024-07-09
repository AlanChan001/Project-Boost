using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheatLevelText : MonoBehaviour
{
    [SerializeField] GameObject rocket;
    private int activeSceneNumber;

    private void Start()
    {
        rocket = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        showText();
    }

    void showText()
    {
        activeSceneNumber = SceneManager.GetActiveScene().buildIndex + 1;
        GetComponent<TextMeshProUGUI>().text = "Level:" + activeSceneNumber
                                           + "\nCheat Mode:" + rocket.GetComponent<CollisionHandler>().cheatMode;
        
    }


    
}
