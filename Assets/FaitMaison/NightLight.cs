using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightLight : MonoBehaviour
{
  private GameController gameController;
  public float intensity;
  public bool isFire = false;
  private Light nightLight;
  private Vector3 originalPosition = new Vector3();
  // Start is called before the first frame update
  void Start()
  {
    originalPosition = transform.position;
    nightLight = GetComponent<Light>();
    gameController = GetComponentInParent<GameController>();
  }

  // Update is called once per frame
  void Update()
  {
    float finalIntensity = gameController.nightRatio * intensity;
    if (isFire)
    {
      finalIntensity *= Random.Range(0.85f, 1.15f);
      transform.position = originalPosition + new Vector3(Random.Range(-0.025f, 0.025f), Random.Range(-0.025f, 0.025f), Random.Range(-0.025f, 0.025f));
    }
    nightLight.intensity = finalIntensity;
  }
}
