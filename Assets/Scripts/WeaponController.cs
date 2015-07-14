using UnityEngine;
using System.Collections;

public abstract class WeaponController : MonoBehaviour {
	public string hitboxTag;
	public float damage = 10;
	
	public virtual void OnTriggerEnter2D(Collider2D hitBox) {
		if (hitBox.tag == hitboxTag) {
			Transform target = hitBox.GetComponent<Transform>().parent;
			CauseADamage(target);
			addEffect(target);
		}
	}

	protected virtual void CauseADamage(Transform target){}

	protected virtual void addEffect(Transform target){}
}
