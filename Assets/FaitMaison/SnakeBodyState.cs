using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyState : MonoBehaviour
{
  public string rotating = "no";
  public string previousRotating;
  private Transform bodyStraight;
  private Transform bodyTurningRight;
  private Transform bodyTurningLeft;

  // Start is called before the first frame update
  void Start()
  {
    bodyStraight = transform.Find("Forward");
    bodyTurningRight = transform.Find("Droat");
    bodyTurningLeft = transform.Find("Goche");
  }

  public void updateModel()
  {
    if (rotating != previousRotating)
    {
      switch (rotating)
      {
        case "no":
          bodyStraight.gameObject.SetActive(true);
          bodyTurningRight.gameObject.SetActive(false);
          bodyTurningLeft.gameObject.SetActive(false);
          break;
        case "right":
          bodyStraight.gameObject.SetActive(false);
          bodyTurningRight.gameObject.SetActive(true);
          bodyTurningLeft.gameObject.SetActive(false);
          break;
        case "left":
          bodyStraight.gameObject.SetActive(false);
          bodyTurningRight.gameObject.SetActive(false);
          bodyTurningLeft.gameObject.SetActive(true);
          break;
        default:
          break;
      }
      previousRotating = rotating;
    }
  }
}
