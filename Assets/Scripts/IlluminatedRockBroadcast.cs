using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlluminatedRockBroadcast : MonoBehaviour {


	Transform light;
	GameObject hitted;
	float dot;

	public int rockWarnRadius=10;
	// Use this for initialization
	void Start () {
		light = GameObject.Find("Luz Giratoria").transform;

	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;

    if(Physics.Raycast(light.position, light.forward, out hit, 100)
				&& (hit.collider.gameObject.tag == "Rock" || hit.collider.gameObject.tag == "Boat")) {
			hitted = hit.collider.gameObject;
			Debug.DrawLine(light.position, hit.collider.transform.position, Color.blue);
			Collider[] boats = Physics.OverlapSphere(hitted.transform.position, rockWarnRadius);

      int i = 0;
      while (i < boats.Length) {
				GameObject boat = boats[i].gameObject;
					if(boat.tag=="Boat"){
						Debug.DrawRay(boats[i].transform.position, boats[i].transform.forward*4, Color.green);
	          boat.transform.parent.parent.GetComponent<Boat>().AddRock(hitted);
					}
          i++;
      }
    }
		else {
			hitted = null;
		}
	}
	void OnDrawGizmos() {
		if( hitted != null ){
			Gizmos.DrawWireSphere(hitted.transform.position, rockWarnRadius);
		}
  }
}
