using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollision : MonoBehaviour
{
  public SnakeCharacterController snakeCharacterController;
  BoxCollider frontCollider;
  public GameObject peepPrefab;
  GameController gameController;
  // Start is called before the first frame update
  void Start()
  {
    gameController = GetComponentInParent<GameController>();
    frontCollider = GetComponent<BoxCollider>();
  }

  // Update is called once per frame
  void Update()
  {
  }
  void OnCollisionEnter(Collision collisionInfo)
  {
    if (collisionInfo.transform.tag == "Peep")
    {
      snakeCharacterController.bodyPartsToHave = "more";
      Destroy(collisionInfo.transform.gameObject);
      float positionX = 0;
      float positionZ = 0;
      bool findingNotIntersectingCoords = true;
      while (findingNotIntersectingCoords)
      {
        positionX = Random.Range(0, 35) + 0.5f;
        positionZ = Random.Range(8, 27) + 0.5f;
        if (!snakeCharacterController.bodyParts.Exists(x => ((x.position.x == positionX) && (x.position.z == positionZ))))
        {
          findingNotIntersectingCoords = false;
        }
      }
      GameObject newPeep = Instantiate(peepPrefab, new Vector3(positionX, -1.166667f, positionZ), Quaternion.Euler(0, Random.Range(0, 3) * 90, 0));
      newPeep.transform.parent = gameController.gameObject.transform;
    }
  }
}
