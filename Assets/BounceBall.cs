using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour
{
	public Rigidbody2D rb;


	// Use this for initialization
	void Start ()
	{

		rb = this.GetComponent<Rigidbody2D> ();
		rb.position = new Vector2 (Random.Range (0.3f, 16f), Random.Range (0.5f, 11.5f));
		rb.velocity = new Vector2 (2f, 10f);
		
	}
	

}
