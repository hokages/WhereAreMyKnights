using UnityEngine;
using System.Collections;

public abstract class UnitController : MonoBehaviour {
	public int health = 100;
	public float speed = 0.2f;
	public float smoothTime = 0.1f;

	protected Vector2 move = new Vector2(0, 0);
	protected bool facingRight = false;
	protected Vector2 velocity;
	
	protected virtual void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
		
	protected virtual void Move() {
		float targetX;
		float targetY;
		targetX = Mathf.SmoothDamp (
			transform.position.x,
			transform.position.x + move.x * speed,
			ref velocity.x,
			smoothTime
			);
		targetY = Mathf.SmoothDamp (
			transform.position.y,
			transform.position.y + move.y * speed,
			ref velocity.y,
			smoothTime
		);
		transform.position = new Vector3(targetX, targetY, transform.position.z);
		if (move.x > 0 && !facingRight) {
			Flip();
		} else if (move.x < 0 && facingRight) {
			Flip();
		}
	}
}
