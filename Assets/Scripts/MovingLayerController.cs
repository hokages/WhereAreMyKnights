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
	private Vector2 sign = new Vector2(1, 1);
	
	public void Start() {
		
		if (size.x == 0) {
			size.x = background.GetComponent<SpriteRenderer>().bounds.size.x;
		}
		if (size.y == 0) {
			size.y = background.GetComponent<SpriteRenderer>().bounds.size.y;
		}
		
		MovingLayerPart mainSprite = new MovingLayerPart();
		mainSprite.SetSprite(background);
		mainSprite.SetSize(size);
		parts.Add(mainSprite);

		sign.x = speed.x < 0 ? 1 : -1;
		sign.y = speed.y < 0 ? 1 : -1;
		
		if (speed.y != 0) {
			SetClone(0, size.y, "vertical");
		}
		
		if (speed.x != 0) {
			SetClone(size.x, 0, "horisontal");
		}
		
		if (speed.x != 0 && speed.y != 0) {
			SetClone(size.x, size.y, "diagonal");
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
	
	private void SetClone(float sizeX = 0, float sizeY = 0, string name = "") {
		MovingLayerPart verticalSprite = new MovingLayerPart();
		Transform verticalSpriteTransform = Transform.Instantiate(background) as Transform;
		verticalSpriteTransform.transform.parent = background.transform.parent;
		verticalSpriteTransform.transform.name = background.transform.name + " " + name + " clone";
		verticalSprite.SetSprite(verticalSpriteTransform);
		verticalSprite.SetDelta(new Vector2(sizeX * sign.x, sizeY * sign.y));
		verticalSprite.SetSize(size);
		parts.Add(verticalSprite);
	}
	
}


[System.Serializable]
public class MovingLayerPart {
	private Transform transform;
	private Vector2 size = new Vector2(0, 0);
	private Vector2 delta = new Vector2(0, 0);
	private Vector3 startPositin;
	
	public void SetSprite(Transform newTransform) {
		transform = newTransform;
	}
	public void SetDelta(Vector2 newDelta) {
		delta = newDelta;
	}
	public void SetSize(Vector2 newSize) {
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

		if (newPos.x - startPositin.x > size.x) {
			newPos.x -= size.x;
		} else if (newPos.x - startPositin.x < -size.x) {
			newPos.x += size.x;
		}

		if (newPos.y - startPositin.y > size.y) {
			newPos.y -= size.y;
		} else if (newPos.y - startPositin.y < -size.y) {
			newPos.y += size.y;
		}

		transform.position = newPos;
	}
}
