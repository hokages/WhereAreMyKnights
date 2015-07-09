using UnityEngine;
using System.Collections;

public abstract class UnitController : MonoBehaviour {
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
		GetComponent<Rigidbody2D>().velocity = move;
		if (move.x > 0 && !facingRight) {
			Flip();
		} else if (move.x < 0 && facingRight) {
			Flip();
		}
	}
}
