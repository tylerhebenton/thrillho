using UnityEngine;
using System.Collections;

public class CameraWaypoint : MonoBehaviour {

  public const float DEFAULT_SPEED = 3f;

  public float speed = DEFAULT_SPEED;

  public enum CamModes {
    Auto,
    Follow
  }

  public CamModes camMode = CamModes.Auto;
}
