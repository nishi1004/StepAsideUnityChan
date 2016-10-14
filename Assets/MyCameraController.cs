﻿using UnityEngine;
using System.Collections;

public class MyCameraController : MonoBehaviour {

    private GameObject unityChan;
    private float difference;
	// Use this for initialization
	void Start () {
        this.unityChan = GameObject.Find("unitychan");
        this.difference = unityChan.transform.position.z - this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(0, this.transform.position.y, unityChan.transform.position.z - difference);
	}
}
