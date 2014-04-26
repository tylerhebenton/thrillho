using System;
using System.Collections.Generic;
using UnityEngine;

public static class Feature {

  public const string DEBUG_FEATURES = "DEBUG_FEATURES";
  public const string DEBUG_LEVEL_CONTROLS = "DEBUG_LEVEL_CONTROLS";

  private static Dictionary<string, bool> featureMap;

  static Feature() {
    featureMap = new Dictionary<string, bool>();

    bool debugFeatures = true;

    if(debugFeatures) {
      featureMap.Add(DEBUG_FEATURES, true);

      featureMap.Add(DEBUG_LEVEL_CONTROLS, true);
    }
  }

  public static bool enabled(string feature) {
    if(featureMap.ContainsKey(feature)) {
      return featureMap[feature];
    }
    return false;
  }
}


