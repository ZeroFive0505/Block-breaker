using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public Sprite[] hitSprites;
    public AudioClip Crack;
    public AudioClip Unbreakble;
    public AudioClip Coin;
    public static int brickCount = 0;
    private LevelManager levelManager;
    public GameObject smoke;
    private int timesHit;
    private int maxHits;
    bool isBreakable;

    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
            brickCount++;
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isBreakable)
        {
            HandleHits();
        }
        else
        {
            AudioSource.PlayClipAtPoint(Unbreakble, transform.position);
        }
    }

    void HandleHits()
    {
        timesHit++;
        maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            AudioSource.PlayClipAtPoint(Crack, transform.position, 7f);
            brickCount--;
            Debug.Log(brickCount);
            levelManager.BrickDestroyed();
            puffSmokre();
            Destroy(gameObject);
        }
        else
        {
            AudioSource.PlayClipAtPoint(Coin, transform.position, 7f);
            LoadSprites();
        }

    }

    void puffSmokre()
    {
        GameObject smokepuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        smokepuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;

    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Sprite is missing!");
        }
    }
}
