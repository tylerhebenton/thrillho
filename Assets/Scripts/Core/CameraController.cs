using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

  private Vector3 initialPosition;
  private float orthoSize;

	// Use this for initialization
	void Start () {
    initialPosition = transform.position;
    orthoSize = Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
    Camera.main.orthographicSize = orthoSize;
	}

  private int curWaypointIndex = 0;
  private Level curLevel = null;
  public void FollowWaypoints(Level level) {
    curLevel = level;
    Go.killAllTweensWithTarget(this.transform);
    this.transform.position = initialPosition;
    if(level.waypoints.Length > 0) {
      curWaypointIndex = 0;
      HaltThenGotoWaypoint();
    }
  }

  public void HaltThenGotoWaypoint() {
    Go.killAllTweensWithTarget(this.transform);
    UkenTimer.SetTimeout(3f, () => {
      curWaypointIndex -= 1;
      NextWaypoint();
    });
  }

  public void GoToWaypoint(CameraWaypoint waypoint) {
    float delta = (transform.position - waypoint.transform.position).magnitude;
    float timeToTarget = delta / waypoint.speed;
    Go.to(this.transform, timeToTarget, new GoTweenConfig().position(waypoint.transform.position).onComplete((_)=>{
      NextWaypoint();
    }));
  }

  private void NextWaypoint() {
    curWaypointIndex += 1;
    if(curWaypointIndex < curLevel.waypoints.Length) {
      GoToWaypoint(curLevel.waypoints[curWaypointIndex]);
    }
  }
}
