﻿using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour {
    public Vector3 axis = Vector3.up;
    public float speed = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(axis, speed * Time.deltaTime);
	}
}
