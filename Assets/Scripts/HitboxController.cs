using UnityEngine;
using System.Collections;

public class HitboxController : MonoBehaviour {

	private UnitController _unitController;

	// Use this for initialization
	void Start () {
		_unitController = transform.parent.GetComponent<UnitController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void provideDamage(float dmg) {
		_unitController.TakeADamage(dmg);
				
	}
}
