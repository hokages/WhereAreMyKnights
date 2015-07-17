using UnityEngine;
using System.Collections;

public class HitboxController : MonoBehaviour {

	private string _unit = "player";
	private EnemyController _enemyController;
	private PlayerController _playerController;

	// Use this for initialization
	void Start () {
		_enemyController = transform.parent.GetComponent<EnemyController>();
		_playerController = transform.parent.GetComponent<PlayerController>();
		if (_enemyController != null) {
			_unit = "enemy";
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void provideDamage(float dmg) {
		switch (_unit) {
			case "player":
				_playerController.TakeADamage(dmg);
				break;
			case "enemy":
				_enemyController.TakeADamage(dmg);
				break;
		}
				
	}
}
