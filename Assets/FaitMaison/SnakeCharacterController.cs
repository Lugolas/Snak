using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class SnakeCharacterController : MonoBehaviour
{
  [Header("References")]
  [Tooltip("Reference to the main camera used for the snake")]
  public Camera playerCamera;

  [Tooltip("Reference to the body prefab to add in the middle of the snake")]
  public GameObject bodyPrefab;


  [Header("Movement")]
  public float speed = 1;

  public List<Transform> bodyParts = new List<Transform>();
  public string turning = "";
  public string bodyPartsToHave = "";
  private int direction = 0;
  private Transform head;
  private Transform tail;
  private Renderer[] renderers;

  void Start()
  {
    head = transform.Find("Head");
    if (head != null)
    {
      bodyParts.Add(head);
    }

    tail = transform.Find("Ke");
    if (tail != null)
    {
      bodyParts.Add(tail);
    }
  }

  void Update()
  {
    // HandleInput();
    if (bodyPartsToHave != "")
    {
      HandleBodyNumber();
    }
    if (turning != "")
    {
      HandleMovement();
    }
  }

  void HandleInput()
  {
    {
      if (Input.GetKeyDown("up"))
      {
        turning = "forward";
      }
      else
      if (Input.GetKeyDown("right"))
      {
        turning = "right";
      }
      else
      if (Input.GetKeyDown("left"))
      {
        turning = "left";
      }
      else turning = null;

      if (Input.GetKeyDown("[+]"))
      {
        bodyPartsToHave = "more";
      }
      else
      if (Input.GetKeyDown("[-]"))
      {
        bodyPartsToHave = "less";
      }
      else bodyPartsToHave = null;
    }
  }

  void HandleBodyNumber()
  {
    switch (bodyPartsToHave)
    {
      case "more":
        Transform bodyPartLast = bodyParts[bodyParts.Count - 1];
        GameObject newBodyPart = Instantiate(bodyPrefab, bodyPartLast.position, bodyPartLast.rotation);
        newBodyPart.transform.parent = gameObject.transform;
        bodyParts.Insert(bodyParts.Count - 1, newBodyPart.transform);
        break;
      case "less":
        break;
      default:
        break;
    }
  }
  void HandleMovement()
  {
    for (int i = bodyParts.Count - 1; i >= 0; i--)
    {
      Transform bodyPartCurrent = bodyParts[i];
      Vector3 newPosition;
      float newRotation;
      if (i == 0)
      {
        SnakeBodyState bodyPartBehindState = bodyParts[i + 1].GetComponent<SnakeBodyState>();
        newPosition = bodyPartCurrent.position;
        switch (turning)
        {
          case "forward":
            newRotation = 0.0f;
            switch (direction % 4)
            {
              case 0:
                newPosition.x += speed;
                break;
              case 1:
                newPosition.z -= speed;
                break;
              case 2:
                newPosition.x -= speed;
                break;
              case 3:
                newPosition.z += speed;
                break;
              default:
                break;
            }
            if (bodyPartBehindState)
              bodyPartBehindState.rotating = "no";
            break;
          case "right":
            newRotation = 90.0f;
            switch (direction % 4)
            {
              case 0:
                newPosition.z -= speed;
                break;
              case 1:
                newPosition.x -= speed;
                break;
              case 2:
                newPosition.z += speed;
                break;
              case 3:
                newPosition.x += speed;
                break;
              default:
                break;
            }
            direction++;
            if (bodyPartBehindState)
              bodyPartBehindState.rotating = "right";
            break;
          case "left":
            newRotation = -90.0f;
            switch (direction % 4)
            {
              case 0:
                newPosition.z += speed;
                break;
              case 1:
                newPosition.x += speed;
                break;
              case 2:
                newPosition.z -= speed;
                break;
              case 3:
                newPosition.x -= speed;
                break;
              default:
                return;
            }
            if (direction == 0)
              direction = 3;
            else
              direction--;

            if (bodyPartBehindState)
              bodyPartBehindState.rotating = "left";
            break;
          default:
            return;
        }
        bodyPartCurrent.Rotate(0, newRotation, 0);

        Transform bodyPartSecond = bodyParts[1];
        SnakeBodyState bodyPartSecondState = bodyPartSecond.GetComponent<SnakeBodyState>();
        if (bodyPartSecondState)
        {
          bodyPartSecondState.updateModel();
        }

        // Turn the tail after everything, well maybe it's a bit late but here it's sure that the one in front of the last already moved.
        Transform bodyPartInFrontOfTheLast = bodyParts[bodyParts.Count - 2];
        Transform bodyPartLast = bodyParts[bodyParts.Count - 1];
        bodyPartLast.rotation = bodyPartInFrontOfTheLast.rotation;
      }
      else
      {
        Transform bodyPartAhead = bodyParts[i - 1];
        bodyPartCurrent.rotation = bodyPartAhead.rotation;
        SnakeBodyState bodyPartCurrentState = bodyPartCurrent.GetComponent<SnakeBodyState>();
        SnakeBodyState bodyPartAheadState = bodyPartAhead.GetComponent<SnakeBodyState>();
        if (bodyPartCurrentState && bodyPartAheadState)
        {
          bodyPartCurrentState.rotating = bodyPartAheadState.rotating;
          bodyPartCurrentState.updateModel();
        }
        newPosition = bodyPartAhead.position;
      }
      bodyPartCurrent.position = newPosition;
    }
  }
}