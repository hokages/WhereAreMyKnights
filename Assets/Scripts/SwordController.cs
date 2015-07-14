using UnityEngine;
using System.Collections;

public class SwordController : WeaponController {
	
	protected override void CauseADamage(Transform target) {
		target.GetComponent<EnemyController>().TakeADamage(damage);
	}
}
