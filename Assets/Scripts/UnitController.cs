using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public abstract class UnitController : MonoBehaviour {
	public float health = 100;
	public float speed = 0.2f;
	public float smoothTime = 0.1f;
	public float moveBackFactor = 0.4f;
	public float moveSideFactor = 0.8f;

	protected Vector2 _move = new Vector2(0, 0);
	protected Vector2 _face = new Vector2(-1, 0);
	protected Vector2 _velocity;
	protected bool _facingRight = false;
	protected float _direction = 1.57f;
	
	public virtual void TakeADamage(float dmg) {
		health -= dmg;
	}
	
	public virtual void TakeAEffect() {
	}
	
	public virtual void Death() {
		DestroyObject(this.gameObject);
	}

	public float getDirection() {
		return _direction;
	}
	
	protected virtual void _UpdateDirection() {
		if (Vector2.zero != _face) {
			_direction = Mathf.Acos(_face.normalized.y);
			if (_face.x < 0) {
				_direction = Mathf.PI * 2 - _direction;
			}

		}
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
	}
}
