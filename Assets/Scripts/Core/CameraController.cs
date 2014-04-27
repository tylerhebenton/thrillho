using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

  private Vector3 initialPosition;
  private float orthoSize;

  private float maxX = 0f;

	// Use this for initialization
	void Start () {
    initialPosition = transform.position;
    orthoSize = Camera.main.orthographicSize;
    maxX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
    //Camera.main.orthographicSize = orthoSize;


	}

  public void FollowCharacterPosition(Vector3 heroPosition) {
    if(curWaypoint != null && curWaypoint.camMode == CameraWaypoint.CamModes.Follow && heroPosition.x > maxX) {
      maxX = heroPosition.x;
      //TODO follow along the line towards the next waypoint, not just snapped on Y using maxX
      this.transform.position = new Vector3(maxX, this.transform.position.y, this.transform.position.z);
    }
  }

  private int curWaypointIndex = 0;
  private Level curLevel = null;
  private CameraWaypoint curWaypoint = null;
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
    curWaypoint = waypoint;
    if(waypoint.camMode == CameraWaypoint.CamModes.Auto) {
      float delta = (transform.position - waypoint.transform.position).magnitude;
      float timeToTarget = delta / waypoint.speed;
      Go.to(this.transform, timeToTarget, new GoTweenConfig().position(waypoint.transform.position).onComplete((_) => {
        NextWaypoint();
      }));
    }
  }

  private void NextWaypoint() {
    curWaypointIndex += 1;
    if(curWaypointIndex < curLevel.waypoints.Length) {
      GoToWaypoint(curLevel.waypoints[curWaypointIndex]);
    }
  }
}
