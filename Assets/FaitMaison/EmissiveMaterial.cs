using System.Collections.Generic;
using UnityEngine;

public class EmissiveMaterial : MonoBehaviour {
  List<Material> materials = new List<Material> ();
  List<Vector3> colorsHSV = new List<Vector3> ();
  GameController gameController;

  void Start () {
    gameController = GetComponentInParent<GameController> ();
    GetComponent<Renderer> ().GetMaterials (materials);
    foreach (Material material in materials) {
      float h, s, v;
      Color.RGBToHSV (material.GetColor ("_EmissionColor"), out h, out s, out v);
      colorsHSV.Add (new Vector3 (h, s, v));
    }
  }

  void Update () {
    for (int i = 0; i < materials.Count; i++) {
      materials[i].SetColor ("_EmissionColor", Color.HSVToRGB (colorsHSV[i].x, colorsHSV[i].y, gameController.nightRatio));
    }
  }
}