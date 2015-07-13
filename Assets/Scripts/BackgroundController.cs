using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
	
	public Transform target;
	public Vector2 speed = new Vector2(0.5f, 0.5f);
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(target.position.x * speed.x, target.position.y * speed.y, transform.position.z);
	}
}
