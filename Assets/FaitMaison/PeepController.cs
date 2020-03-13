using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepController : MonoBehaviour
{
  // private bool isRunning = false;
  private bool isWalking = false;
  private Animator anim;
  private UnityEngine.AI.NavMeshAgent navAgent;
  private List<Transform> snakeBodyParts = new List<Transform>();

  // Start is called before the first frame update
  void Start()
  {
    anim = GetComponent<Animator>();
    navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    snakeBodyParts = GetComponentInParent<GameController>().GetComponentInChildren<SnakeCharacterController>().bodyParts;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButton("Fire"))
    {
      isWalking = true;
      anim.SetBool("IsWalking", isWalking);
      // navAgent.destination = snakeBodyParts[1].position;
      // navAgent.isStopped = false;
    }

  }
}
