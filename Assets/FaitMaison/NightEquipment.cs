using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightEquipment : MonoBehaviour
{
  private GameController gameController;
  public float scale = 1;
  public float speed = 1;
  private Vector3 originalPosition = new Vector3();
  // Start is called before the first frame update
  void Start()
  {
    originalPosition = transform.position;
    gameController = GetComponentInParent<GameController>();
  }

  // Update is called once per frame
  void Update()
  {
    float ratio = gameController.nightRatio * speed;

    float finalScale = Mathf.Clamp01(ratio) * scale;

    transform.localScale = new Vector3(1, finalScale, 1);
    float finalPosition = 2 - finalScale * 2;
    transform.position = new Vector3(transform.position.x, originalPosition.y + finalPosition, transform.position.y);
  }
}
