using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

	private LevelManager levelManager;
	public Sprite[] hitSprites;
	public AudioClip crack;
	private int timesHit;
	public static int breakableCount = 0;
	private bool isBreakable;
	public GameObject smoke;

	// Use this for initialization
	void Start ()
	{
		isBreakable = true;
		//isBreakable = (this.tag == "Breakable");

		//Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}


		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (isBreakable) {
			HandleHits ();
		}

	}

	void HandleHits ()
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			//Debug.Log (breakableCount);
			levelManager.BrickDestroyed ();
			GameObject smokePuff = Instantiate (smoke, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
			//GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
			smokePuff.GetComponent<ParticleSystem> ().startColor = gameObject.GetComponent<SpriteRenderer> ().color;

			AudioSource.PlayClipAtPoint (crack, transform.position);

			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}


	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("ERROR ::::::::: Brick Sprite Missing");
		}
	}

	//TODO Remove this method once we can actually win
	void SimulateWin ()
	{
		levelManager.LoadNextLevel ();
	}

}
