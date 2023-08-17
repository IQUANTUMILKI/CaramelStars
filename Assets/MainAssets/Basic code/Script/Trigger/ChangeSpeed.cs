using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour {
	
	public MainLine line;
	public float speed;
	
	void OnTriggerEnter (Collider other){
		if (other.tag == "line")
		{
			line.Speed = speed;
		}
	}
}
