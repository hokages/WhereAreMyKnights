﻿using UnityEngine;
using System.Collections;

public class PlayerController : UnitController {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print(Input.GetAxis("Horizontal"));
		print(Input.GetAxis("Vertical"));
	}
}
