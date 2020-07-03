using UnityEngine;
using System.Collections;

public class LoseColider : MonoBehaviour {

    private LevelManager levelManager;

	void OnTriggerEnter2D(Collider2D trigger)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        //print("Trigger");
        levelManager.LoadLevel("Loose");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
