using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
  public float nightRatio = 0;
  private float minimum = 0.0f;
  private float maximum = 1.0f;
  private float duration = 5.0f;
  private float startTime = -1f;
  public Light mainLight;
  public GameObject peepPrefab;
  GameController gameController;

  void Start () {
    gameController = GetComponentInParent<GameController> ();
    GameObject newPeep = Instantiate (peepPrefab, new Vector3 (Random.Range (0, 35) + 0.5f, -1.166667f, Random.Range (8, 27) + 0.5f), Quaternion.Euler (0, Random.Range (0, 3) * 90, 0));
    newPeep.transform.parent = gameController.gameObject.transform;
  }

  // Update is called once per frame
  void Update () {
    mainLight.intensity = 1 - nightRatio;

    if (startTime != -1 && minimum != -1 && maximum != -1) {
      float t = (Time.time - startTime) / duration;
      nightRatio = Mathf.SmoothStep (minimum, maximum, t);
      if (Time.time > startTime + duration) {
        startTime = -1;
      }
    }
  }

  public void dayToNight () {
    startTime = Time.time;
    minimum = 0;
    maximum = 1;
  }

  public void nightToDay () {
    startTime = Time.time;
    minimum = 1;
    maximum = 0;
  }
}