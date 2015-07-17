using UnityEngine;
using System.Collections;

public class HitboxController : MonoBehaviour {

	private string _unit = "player";
	private UnitController _controller;

	// Use this for initialization
	void Start () {
		_controller = transform.parent.GetComponent<UnitController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void provideDamage(float dmg) {
		_controller.TakeADamage(dmg);
				
	}
}
