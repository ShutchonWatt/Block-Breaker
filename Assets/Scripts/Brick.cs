using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;

    //private int maxHits;
    public static int breakableCount=0;
    public GameObject smoke;

    private int timesHit;
    private bool isBreakable; 
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        // Keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
            //print(breakableCount);
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        //print(timeHit);
        //SimulateWin();
        int maxHits = hitSprites.Length + 1;
        if (timesHit == maxHits)
        {
            breakableCount--;
            //Debug.Log(breakableCount);
            levelManager.BrickDestoyed();
            PuffSmoke();
            Destroy(gameObject);
            //Destroy(this);
            //Debug.Log(breakableCount);
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit -1;
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing");
        }
    }

    // TODO Remove this method once we can actually win!
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }

}
