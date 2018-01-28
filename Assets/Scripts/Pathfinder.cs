using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinder : MonoBehaviour {


	protected Vector3 objectPosition;
	protected Vector3 targetPosition;
	protected GameObject[] obstacles;


	// Use this for initialization
	void Start () {
		objectPosition = transform.position;
		targetPosition = GameObject.Find("Cylinder").transform.position;
	}

	// Update is called once per frame
	void Update () {

		obstacles = GameObject.FindGameObjectsWithTag("obstacle");
		List<Vector3> waypoints = getWaypoints(objectPosition, targetPosition, obstacles);
		drawWaypoints(waypoints);

//		getNextWaypoint (objectPosition, targetPosition, obstacles);
	}

	Vector3 getNextWaypoint(Vector3 start, Vector3 end, GameObject[] obstacles) {
		List<Vector3> waypoints = getWaypoints(objectPosition, targetPosition, obstacles);
		return waypoints[0]
	}

	void drawWaypoints(List<Vector3> waypoints) {
		Color[] color = new Color[]{Color.red, Color.blue, Color.green, Color.yellow };
		for(int i=0; i < waypoints.Count - 1; i++) {
			Debug.DrawLine(waypoints[i], waypoints[i+1], color[i]);
		}
	}

	Vector3 getWaypointOnCircle(Vector3[] waypoints, Vector2 center, float radius) {
		float safetyDistance = 1;

		Vector2 point1 = toVector2(waypoints[0]);
		Vector2 point2 = toVector2(waypoints[1]);
		Vector2 direction = point2 - point1;
		Debug.DrawLine (toVector3(point2), toVector3(point1), Color.cyan);
		Debug.DrawLine (toVector3(point1), toVector3(center), Color.green);
		Debug.DrawLine (toVector3(point2), toVector3(center), Color.green);
		Vector2 middleDirection = point1 + (direction / 2);
		Debug.DrawLine (toVector3(center), toVector3(middleDirection), Color.magenta);


		Vector2 normalDirection = (middleDirection - center);
		normalDirection.Normalize ();
		normalDirection = normalDirection * (radius + safetyDistance);
		Debug.DrawLine (toVector3(normalDirection) + toVector3(center), toVector3(center), Color.yellow);

		Vector2 newWaypoint = toVector2(toVector3(normalDirection) + toVector3(center));

		Debug.DrawLine (toVector3(newWaypoint), toVector3(center), Color.magenta);
		return toVector3 (newWaypoint);
	}

	List<Vector3> getWaypoints(Vector3 startPosition, Vector3 endPosition, GameObject[] obstacles) {
		Debug.DrawLine (startPosition, endPosition, Color.white);

		List<Vector3> waypoints = new List<Vector3>();
		waypoints.Add (startPosition);

		for (int i = 0; i < obstacles.Length; i++) {
			Vector2 center = new Vector2 (obstacles [i].transform.position.x, obstacles [i].transform.position.z);
			float radius = obstacles [i].GetComponent<SphereCollider> ().radius;
			Vector3[] circleHits = BetweenLineAndCircle (
				center,
				radius,
				toVector2(objectPosition),
				toVector2(targetPosition));

			if (circleHits.Length == 2) {
				waypoints.Add (getWaypointOnCircle (circleHits, center, radius * obstacles[i].transform.localScale.x));
				break;
			}

//			foreach(Vector3 hit in circleHits) {
//				waypoints.Add(hit);
//			}

		}
		waypoints.Add(endPosition);

		return waypoints;
	}

	Vector3 getNearCollisions(Vector3 path, GameObject obstacle) {
		Vector3 center = obstacle.transform.position;
		SphereCollider collider = obstacle.GetComponent<SphereCollider>();
		float radius = collider.radius;
		return path;
	}


	Vector2 toVector2(Vector3 vector) {
		return new Vector2 (vector.x, vector.z);
	}

	Vector3 toVector3(Vector2 vector) {
		return new Vector3 (vector.x, 0, vector.y);
	}


	Vector3[] BetweenLineAndCircle(
		Vector2 circleCenter, float circleRadius,
		Vector2 point1, Vector2 point2)
	{

		float t;
		Vector2 intersection1, intersection2;

		float dx = point2.x - point1.x;
		float dy = point2.y - point1.y;

		float a = dx * dx + dy * dy;
		float b = 2 * (dx * (point1.x - circleCenter.x) + dy * (point1.y - circleCenter.y));
		float c = (point1.x - circleCenter.x) * (point1.x - circleCenter.x) + (point1.y - circleCenter.y) * (point1.y - circleCenter.y) - circleRadius * circleRadius;

		float determinate = b * b - 4 * a * c;

		if ((a <= 0.0000001) || (determinate < -0.0000001))
		{
			// No real solutions.
			intersection1 = Vector2.zero;
			intersection2 = Vector2.zero;
			return new Vector3[] {};
		}
		if (determinate < 0.0000001 && determinate > -0.0000001)
		{
			// One solution.
			t = -b / (2 * a);
			intersection1 = new Vector2(point1.x + t * dx, point1.y + t * dy);
			intersection2 = Vector2.zero;
			return new Vector3[] {toVector3(intersection1)};
		}

		// Two solutions.
		t = (float)((-b + Mathf.Sqrt(determinate)) / (2 * a));
		intersection1 = new Vector2(point1.x + t * dx, point1.y + t * dy);
		t = (float)((-b - Mathf.Sqrt(determinate)) / (2 * a));
		intersection2 = new Vector2(point1.x + t * dx, point1.y + t * dy);

		if ((intersection2 - point1).magnitude > (intersection1 - point1).magnitude) {
			return new Vector3[] { toVector3(intersection1), toVector3(intersection2) };
		} else {
			return new Vector3[] { toVector3(intersection2), toVector3(intersection1) };
		}
	}
}
