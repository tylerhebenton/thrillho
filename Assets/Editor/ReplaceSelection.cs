using UnityEngine;
using UnityEditor;
using System.Collections;

#pragma warning disable 0618
public class ReplaceSelection : ScriptableWizard
{
  static GameObject replacement = null;
  static bool keep = false;

  public GameObject ReplacementObject = null;
  public bool KeepOriginals = false;

  [MenuItem("Tools/Mass Replace")]
  static void CreateWizard()
  {
    ScriptableWizard.DisplayWizard(
      "Replace Selection", typeof(ReplaceSelection), "Do the Magic");
  }

  public ReplaceSelection()
  {
    ReplacementObject = replacement;
    KeepOriginals = keep;
  }

  void OnWizardUpdate()
  {
    replacement = ReplacementObject;
    keep = KeepOriginals;
  }

  void OnWizardCreate()
  {
    if (replacement == null)
      return;
#pragma warning disable 0618
    Undo.RegisterSceneUndo("Replace Selection");
#pragma warning restore 0618
    Transform[] transforms = Selection.GetTransforms(
      SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable);

    foreach (Transform t in transforms)
    {
      GameObject g;
      #pragma warning disable 0618
      PrefabType pref = EditorUtility.GetPrefabType(replacement);
      #pragma warning restore 0618

      if (pref == PrefabType.Prefab || pref == PrefabType.ModelPrefab)
      {
        #pragma warning disable 0618
        g = (GameObject)EditorUtility.InstantiatePrefab(replacement);
        #pragma warning restore 0618
      }
      else
      {
        g = (GameObject)Editor.Instantiate(replacement);
      }

      Transform gTransform = g.transform;
      gTransform.parent = t.parent;
      g.name = replacement.name;
      gTransform.localPosition = t.localPosition;
      gTransform.localScale = t.localScale;
      gTransform.localRotation = t.localRotation;
    }

    if (!keep)
    {
      foreach (GameObject g in Selection.gameObjects)
      {
        GameObject.DestroyImmediate(g);
      }
    }
  }
}