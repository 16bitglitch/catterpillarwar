﻿using UnityEngine;
using System.Collections;

public class dudeControl : MonoBehaviour {


	public GameObject steeringObject;
	public GameObject movingObject;
	public GameObject anchorObject;

	public GameObject[] segments = new GameObject[12];
	public Vector3 movementVector;
	public int movementSpeed =100;
	public int movementSpeedTrim =100;
	public int segmentCount=0;
	public int segmantMin=5;
	public int segmantMax=9;
	public int movementForwardBack=0;
	public int movementDelay=0;
	public int movementDelayMax=10;
	public int turnSpeed=10;

	public bool isAutoDude;

	void Start () {
	
		if (isAutoDude) {
			movementForwardBack= 1;
			movementForwardBack = -1;
			movingObject.GetComponent<Rigidbody> ().AddRelativeForce (-movementSpeedTrim, -100, 0);
			anchorObject.GetComponent<Rigidbody> ().AddRelativeForce (0, -100, 0);
		}

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Player1Jump")) {
			Debug.Log ("ControllerJump!");
			for (int segs=12; segs>0; segs--) {
				segments [segs].GetComponent<Rigidbody> ().velocity = segments [segmentCount].GetComponent<Rigidbody> ().velocity + new Vector3 (0, 4, 0);
				
			}
			
		}
		
		if (isAutoDude) {
			movementForwardBack = 1;
		} else {

			movementVector.x = Input.GetAxis ("Player1X") * turnSpeed;
			movementVector.y = Input.GetAxis ("Player1Y") * movementSpeed;


		

			//float tiltX = Input.GetAxis (Controllerx) * 2000;
			//float tiltY = Input.GetAxis (Controllery) * 4000;




//		if (Input.GetButtonDown (ControllerBump)) {
//			Debug.Log("ControllerBump!");
//			//segments[1].GetComponent<Rigidbody>().velocity=segments[segmentCount].GetComponent<Rigidbody>().velocity + new Vector3(0,-5,0);
//			//segments[1].GetComponent<Rigidbody>().AddRelativeForce(100000,0,0);
//			segments[12].GetComponent<Rigidbody>().AddRelativeForce(100000,100000,0);
//		}
//
//		if (Input.GetButton (ControllerForwards)) {
//			Debug.Log("Forwards!");
//			movementForwardBack = 1;
//			//movingObject.GetComponent<Rigidbody>().AddRelativeForce(movementSpeedTrim,-100,0);
//			anchorObject.GetComponent<Rigidbody>().AddRelativeForce(0,-100,0);
//			//steeringObject.GetComponent<Rigidbody>().AddRelativeForce(0,100,0);
//		}
//
//
//
//
//		if (Input.GetButton (ControllerBackwards)) {
//			Debug.Log("backwards!");
//			movementForwardBack = -1;
//			movingObject.GetComponent<Rigidbody>().AddRelativeForce(-movementSpeedTrim,-100,0);
//			anchorObject.GetComponent<Rigidbody>().AddRelativeForce(0,-100,0);
//		}

		
			if (Input.GetButtonUp ("Player1X")) {
				Debug.Log ("Stop!");
				movementForwardBack = 0;
			}
//		
//		if (Input.GetButtonUp (ControllerBackwards)) {
//			Debug.Log("Stop!");
//			movementForwardBack = 0;
//		}

			if (movementVector.y < 0) {
				movementForwardBack = 1;
				//movingObject.GetComponent<Rigidbody>().AddRelativeForce(movementSpeedTrim,-100,0);
				anchorObject.GetComponent<Rigidbody> ().AddRelativeForce (0, -100, 0);
				//steeringObject.GetComponent<Rigidbody>().AddRelativeForce(0,100,0);
			}

			if (movementVector.y > 0) {
				movementForwardBack = -1;
				movingObject.GetComponent<Rigidbody> ().AddRelativeForce (-movementSpeedTrim, -100, 0);
				anchorObject.GetComponent<Rigidbody> ().AddRelativeForce (0, -100, 0);
				//steeringObject.GetComponent<Rigidbody>().AddRelativeForce(0,100,0);
			}

			if (movementVector.y == 0) {
				segmentCount = segmantMax;
				movementForwardBack = 0;
			}

			if (movementVector.x > 0) {
				steeringObject.GetComponent<Rigidbody> ().AddRelativeForce (0, 0, -movementVector.x);
				anchorObject.GetComponent<Rigidbody> ().AddRelativeForce (0, -100, 0);
			}
		
			if (movementVector.x < 0) {
				steeringObject.GetComponent<Rigidbody> ().AddRelativeForce (0, 0, -movementVector.x);
				anchorObject.GetComponent<Rigidbody> ().AddRelativeForce (0, -100, 0);
			}
		}
	}

	void FixedUpdate(){

		if (movementForwardBack > 0) {
			movementDelay++;
			if(movementDelay>movementDelayMax){

				segments[segmentCount].GetComponent<Rigidbody>().AddRelativeForce(movementSpeedTrim,Mathf.Abs(6000),0);
				segmentCount--;
				if(segmentCount<segmantMin)segmentCount=segmantMax;
				movementDelay=0;
			}
		}

		if (movementForwardBack < 0) {
			movementDelay++;
			if(movementDelay>movementDelayMax){
			
				segments[segmentCount].GetComponent<Rigidbody>().AddRelativeForce(movementSpeedTrim,Mathf.Abs(6000),0);
				segmentCount++;
				if(segmentCount>segmantMax)segmentCount=segmantMin;
				movementDelay=0;
			}

		}
			
	}

	



}
