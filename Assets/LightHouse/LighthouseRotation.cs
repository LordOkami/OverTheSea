using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseRotation : MonoBehaviour {
    

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update() {
        Ray lightRay = new Ray(transform.position, transform.rotation * Vector3.forward);
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Debug.DrawRay(transform.position, transform.rotation * Vector3.forward*1000, Color.blue, 2);
        //Debug.DrawRay(cameraRay.origin,cameraRay.direction*1000,Color.yellow,2);

        // create a plane at 0,0,0 whose normal points to +Y:
        Plane hPlane = new Plane(Vector3.up, Vector3.zero);
        // Plane.Raycast stores the distance from ray.origin to the hit point in this variable:
        float nextLLightRayDistance = 0;
        float lightRayDistance = 0;
        // if the ray hits the plane...
        if (hPlane.Raycast(cameraRay, out nextLLightRayDistance)){
            // get the hit point:
            Vector3 nextLightTarget = cameraRay.GetPoint(nextLLightRayDistance);
            Vector3 currentLightTarget;
            if (hPlane.Raycast(lightRay, out lightRayDistance)){
                currentLightTarget = lightRay.GetPoint(lightRayDistance);
            }else{
                currentLightTarget = Vector3.zero;
            }
            

            Vector3 dir = (nextLightTarget - currentLightTarget);

            float speed = 0.1F;
            Vector3 partialDestination = currentLightTarget + ((Vector3.Magnitude(dir)<1)?dir: (Vector3.Normalize(dir)));

            //Debug.DrawRay(currentLightTarget, Vector3.Min(Vector3.Normalize(dir), dir), Color.red, 1);


            // Vector3 partialDestination = currentLightTarget + ((nextLightTarget - currentLightTarget) *2);
            


            transform.LookAt(partialDestination);

        }
       
		
	}
}
