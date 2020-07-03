using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    void Awake()
    {
        Debug.Log("Music player Awake"+GetInstanceID());
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            print("Duplicate music player self-destructing!");
        }
    }


	// Update is called once per frame
	void Update () {
	
	}
}
