using UnityEngine;
using System.Collections;

public abstract class WeaponController : MonoBehaviour {
	public string hitboxTag;
	public float damage = 10;
	
	public virtual void OnTriggerEnter2D(Collider2D hitBox) {

		if (hitBox.tag == hitboxTag) {
			HitboxController hitboxController = hitBox.GetComponent<HitboxController>();
			_CauseADamage(hitboxController);
		}
	}

	protected virtual void _CauseADamage(HitboxController hitboxController){
		hitboxController.provideDamage(damage);
	}

	protected virtual void _AddEffect(Transform target){}
}
