using UnityEngine;

public class InputHandler : MonoBehaviour
{
  public GameController gameController;
  public SnakeCharacterController snakeCharacterController;
  void Update()
  {
    if (Input.GetKeyDown("n"))
    {
      gameController.dayToNight();
    }
    else
    {
      if (Input.GetKeyDown("d"))
      {
        gameController.nightToDay();
      }
    }

    if (Input.GetKeyDown("up"))
    {
      snakeCharacterController.turning = "forward";
    }
    else
    {
      if (Input.GetKeyDown("right"))
      {
        snakeCharacterController.turning = "right";
      }
      else
      {
        if (Input.GetKeyDown("left"))
        {
          snakeCharacterController.turning = "left";
        }
        else
        {
          snakeCharacterController.turning = "";
        }
      }
    }

    if (Input.GetKeyDown("[+]"))
    {
      snakeCharacterController.bodyPartsToHave = "more";
    }
    else
    {
      if (Input.GetKeyDown("[-]"))
      {
        snakeCharacterController.bodyPartsToHave = "less";
      }
      else
      {
        snakeCharacterController.bodyPartsToHave = "";
      }
    }
  }
}