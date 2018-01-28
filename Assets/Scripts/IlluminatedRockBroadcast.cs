using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlluminatedRockBroadcast : MonoBehaviour {


	Transform light;
	Transform hitted;
	float dot;

	public int rockWarnRadion=12;
	// Use this for initialization
	void Start () {
		light = GameObject.Find("Luz Giratoria").transform;
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
    var pos = transform.position;

    if(Physics.Raycast(light.position, light.forward, out hit, 100) &&
				hit.collider.gameObject.tag == "Rock") {
			hitted = hit.collider.gameObject.transform;
			Collider[] hitColliders = Physics.OverlapSphere(hitted.position, rockWarnRadion);
      int i = 0;
      while (i < hitColliders.Length) {
          Transform t = hitColliders[i].transform;
					Debug.DrawRay(t.position, t.forward*5, Color.red);
          i++;
      }
    }
		else {
			hitted = null;
		}
	}
	void OnDrawGizmos() {
		if( hitted != null ){
			Gizmos.DrawWireSphere(hitted.position, rockWarnRadion);
		}
  }
}
