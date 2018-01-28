using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointFollow : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	public int nextTargetIdx = 0;

	private Transform currentTarget;
	private Transform checkpoints;

	void Start(){
		speed = 5f;
		rotationSpeed = 0.002f;
		checkpoints = GameObject.Find("Checkpoints").transform;
		setNextTarget();
	}

	void FixedUpdate () {
		Vector3 targetPos = currentTarget.position;
		Vector3 relativePos = targetPos - transform.position;

		if( relativePos.magnitude < 2 ){
			setNextTarget();
		}

		Vector3 normalized = Vector3.Normalize(relativePos);
		gameObject.GetComponent<Rigidbody>().AddForce(speed * normalized);

		Vector3 newDir = Vector3.RotateTowards(transform.forward, normalized, 1, 0.0F);
		// Debug.DrawRay(transform.position, newDir*3, Color.red,2);
		// Debug.DrawRay(transform.position, transform.forward*3, Color.blue,2);
		// Debug.DrawRay(transform.position, transform.right*-3, Color.green,2);
		gameObject.transform.rotation = Quaternion.Lerp(
			gameObject.transform.rotation,
			Quaternion.LookRotation(newDir), Time.time * rotationSpeed );
	}

	void setNextTarget(){
		if( nextTargetIdx >= checkpoints.childCount ){
			nextTargetIdx = 0;
		}
		currentTarget = checkpoints.GetChild(nextTargetIdx).transform;
		nextTargetIdx += 1;
	}
}
