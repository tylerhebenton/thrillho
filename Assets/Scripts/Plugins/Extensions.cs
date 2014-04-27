using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class Extensions {

  public static GameObject FindChildRecursive(this GameObject self, string childName) {
    for (int i=0; i< self.transform.childCount; i++) {
      GameObject child = self.transform.GetChild (i).gameObject;
      if (child.name == childName) {
        return child;
      } else {
        GameObject recurseChild = FindChildRecursive(child, childName);
        if (recurseChild != null && recurseChild.name == childName) {
          return recurseChild;
        }
      }
    }
    return null;
  }

}
