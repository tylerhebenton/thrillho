using System;
using System.Collections.Generic;

public static class Feature {

  public const string DEBUG_LEVEL_CONTROLS = "DEBUG_LEVEL_CONTROLS";

  private Dictionary<string, bool> featureMap;

  static Feature() {
    featureMap = new Dictionary<string, bool>();

    featureMap.Add(DEBUG_LEVEL_CONTROLS, true);
  }

  public static bool enabled(string feature) {
    if(featureMap.ContainsKey(feature)) {
      return featureMap[feature];
    }
    return false;
  }
}


