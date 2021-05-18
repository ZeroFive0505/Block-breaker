using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;
    public static int Stage;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        Stage = Application.loadedLevel;
        print(Stage);
        levelManager.NextLevel("Lose");

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
