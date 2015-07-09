using UnityEngine;
using System.Collections;

public abstract class UnitController : MonoBehaviour {
	public int health = 100;
	public float maxSpeed = 2f;

	protected Vector2 move = new Vector2(0, 0);
	protected bool facingRight = true;
	protected bool grounded = false;
	
	protected virtual void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
		
	protected virtual void Move() {
//		GetComponent<Rigidbody2D>().velocity = new Vector2(move.x * maxSpeed, move.y * maxSpeed);
		transform.position = new Vector3(transform.position.x + move.x/20, transform.position.y + move.y/20, transform.position.z);
		if (move.x > 0 && !facingRight) {
			Flip();
		} else if (move.x < 0 && facingRight) {
			Flip();
		}
	}
}
