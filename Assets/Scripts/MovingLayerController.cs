using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class MovingLayerController : MonoBehaviour {

	public MovingLayer[] layers;
	
	// Use this for initialization
	void Start () {
		foreach(MovingLayer layer in layers) {
			layer.Start();
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach(MovingLayer layer in layers) {
			layer.Update();
		}
	}
}


[System.Serializable]
public class MovingLayer {
	
	public Transform background;
	//	public List<Transform> backgroundsMirrors;
	[Tooltip("If set 0 will be used sprite width/height")]
	public Vector2 size = new Vector2(0, 0);
	public Vector2 speed = new Vector2(0, 0);

	private Vector3 movingSpeed3;
	private List<MovingLayerPart> parts = new List<MovingLayerPart>();
	
	public void Start() {

		if (size.x == 0) {
			size.x = background.GetComponent<SpriteRenderer>().bounds.size.x;
		}
		if (size.y == 0) {
			size.y = background.GetComponent<SpriteRenderer>().bounds.size.y;
		}
		
		MovingLayerPart mainSprite = new MovingLayerPart();
		mainSprite.setSprite(background);
		mainSprite.setSize(size);
		parts.Add(mainSprite);

		if (speed.y != 0) {
			MovingLayerPart verticalSprite = new MovingLayerPart();
			Transform verticalSpriteTransform = Transform.Instantiate(background) as Transform;
			verticalSpriteTransform.transform.parent = background.transform.parent;
			verticalSpriteTransform.transform.name = background.transform.name + " vertical clone";
			verticalSprite.setSprite(verticalSpriteTransform);
			int sign = speed.y < 0 ? 1 : -1;
			verticalSprite.setDelta(new Vector2(0, size.y * sign));
			verticalSprite.setSize(size);
			parts.Add(verticalSprite);
		}
		
		if (speed.x != 0) {
			MovingLayerPart horisontalSprite = new MovingLayerPart();
			Transform horisontalSpriteTransform = Transform.Instantiate(background) as Transform;
			horisontalSpriteTransform.transform.parent = background.transform.parent;
			horisontalSpriteTransform.transform.name = background.transform.name + " horisontal clone";
			horisontalSprite.setSprite(horisontalSpriteTransform);
			int sign = speed.x < 0 ? 1 : -1;
			horisontalSprite.setDelta(new Vector2(size.x * sign, 0));
			horisontalSprite.setSize(size);
			parts.Add(horisontalSprite);
		}
		
		if (speed.x != 0 && speed.y != 0) {
			MovingLayerPart diagonalSprite = new MovingLayerPart();
			Transform diagonalSpriteTransform = Transform.Instantiate(background) as Transform;
			diagonalSpriteTransform.transform.parent = background.transform.parent;
			diagonalSpriteTransform.transform.name = background.transform.name + " diagonal clone";
			diagonalSprite.setSprite(diagonalSpriteTransform);
			int signX = speed.x < 0 ? 1 : -1;
			int signY = speed.y < 0 ? 1 : -1;
			diagonalSprite.setDelta(new Vector2(size.x * signX, size.y * signY));
			diagonalSprite.setSize(size);
			parts.Add(diagonalSprite);
		}

		foreach (MovingLayerPart part in parts) {
			part.Start();
		}
	}
	
	public void Update() {
		foreach (MovingLayerPart part in parts) {
			part.Update(speed);
		}
	}
	
}


[System.Serializable]
public class MovingLayerPart {
	private Transform transform;
	private Vector2 size = new Vector2(0, 0);
	private Vector2 delta = new Vector2(0, 0);
	private Vector2 moveDelta = new Vector2(0, 0);
	private Vector3 startPositin;

	public void setSprite(Transform newTransform) {
		transform = newTransform;
	}
	public void setDelta(Vector2 newDelta) {
		delta = newDelta;
	}
	public void setSize(Vector2 newSize) {
		size = newSize;
	}

	public void Start() {
		transform.position = new Vector3(
			transform.position.x + delta.x,
			transform.position.y + delta.y,
			transform.position.z
		);
		startPositin = transform.position;
	}
	public void Update(Vector2 speed) {
		Vector3 newPos = new Vector3(
			transform.position.x + speed.x,
			transform.position.y + speed.y,
			transform.position.z
		);
		if (newPos.x - startPositin.x >= size.x) {
			newPos.x -= size.x;
		}
		if (newPos.y - startPositin.y >= size.y) {
			newPos.y -= size.y;
		}
		transform.position = newPos;
	}
}
