using System.Collections.Generic;
using UnityEngine;

public class EmissiveMaterials : MonoBehaviour
{
  // List<Renderer> renderers = new List<Renderer>();
  Renderer[] renderers;
  List<Material> materials = new List<Material>();
  List<Vector3> colorsHSV = new List<Vector3>();
  GameController gameController;

  void Start()
  {
    gameController = GetComponentInParent<GameController>();
    renderers = GetComponentsInChildren<Renderer>(true);
    foreach (Renderer renderer in renderers)
    {
      List<Material> currentMaterials = new List<Material>();
      renderer.GetMaterials(currentMaterials);
      foreach (Material material in currentMaterials)
      {
        float h, s, v;
        Color.RGBToHSV(material.GetColor("_EmissionColor"), out h, out s, out v);
        colorsHSV.Add(new Vector3(h, s, v));
        materials.Add(material);
      }
    }
  }

  void Update()
  {
    for (int i = 0; i < materials.Count; i++)
    {
      materials[i].SetColor("_EmissionColor", Color.HSVToRGB(colorsHSV[i].x, colorsHSV[i].y, gameController.nightRatio));
    }
  }
}