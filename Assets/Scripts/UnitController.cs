using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public abstract class UnitController : MonoBehaviour {
	public float health = 100;
	public float speed = 0.2f;
	public float smoothTime = 0.1f;

	protected Vector2 _move = new Vector2(0, 0);
	protected Vector2 _velocity;
	protected bool _facingRight = false;
	
	public virtual void TakeADamage(float dmg) {
		health -= dmg;
	}
	
	public virtual void TakeAEffect() {
	}
	
	public virtual void Death() {
		DestroyObject(this.gameObject);
	}
	
	protected virtual void _Flip() {
		_facingRight = !_facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
		
	protected virtual void _Move() {
		float targetX;
		float targetY;
		targetX = Mathf.SmoothDamp (
			transform.position.x,
			transform.position.x + _move.x * speed,
			ref _velocity.x,
			smoothTime
			);
		targetY = Mathf.SmoothDamp (
			transform.position.y,
			transform.position.y + _move.y * speed,
			ref _velocity.y,
			smoothTime
		);
		transform.position = new Vector3(targetX, targetY, transform.position.z);
		if (_move.x > 0 && !_facingRight) {
			_Flip();
		} else if (_move.x < 0 && _facingRight) {
			_Flip();
		}
	}
}
