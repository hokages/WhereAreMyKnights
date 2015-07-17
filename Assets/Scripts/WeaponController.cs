using UnityEngine;
using System.Collections;

public abstract class WeaponController : MonoBehaviour {
	public string hitboxTag;
	public float damage = 10;
	
	public virtual void OnTriggerEnter2D(Collider2D hitBox) {

		if (hitBox.tag == hitboxTag) {
			HitboxController hitboxController = hitBox.GetComponent<HitboxController>();
			CauseADamage(hitboxController);
		}
	}

	protected virtual void CauseADamage(HitboxController hitboxController){
		hitboxController.provideDamage(damage);
	}

	protected virtual void AddEffect(Transform target){}
}
