using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	public int nextTargetIdx = 0;

	private Transform boat;
	private Transform target;
	private Transform currentTarget;
	private Transform checkpoints;

	void Start(){
		speed = 5f;
		rotationSpeed = 0.002f;
		boat = transform.Find("Model").transform;
		target = transform.Find("Target").transform;
		currentTarget = target;
		//setNextTarget();
	}

	void FixedUpdate () {
		Vector3 relativePos = currentTarget.position - boat.position;

		// if( relativePos.magnitude < 2 ){
		// 	setNextTarget();
		// }

		Vector3 normalized = Vector3.Normalize(relativePos);
		boat.GetComponent<Rigidbody>().AddForce(speed * normalized);

		Vector3 newDir = Vector3.RotateTowards(boat.forward, normalized, 1, 0.0F);
		// Debug.DrawRay(transform.position, newDir*3, Color.red,2);
		// Debug.DrawRay(transform.position, transform.forward*3, Color.blue,2);
		// Debug.DrawRay(transform.position, transform.right*-3, Color.green,2);
		boat.rotation = Quaternion.Lerp( boat.rotation, Quaternion.LookRotation(newDir), Time.time * rotationSpeed );
	}

	void setNextTarget(){
		if( nextTargetIdx >= checkpoints.childCount ){
			nextTargetIdx = 0;
		}
		currentTarget = checkpoints.GetChild(nextTargetIdx).transform;
		nextTargetIdx += 1;
	}
}
