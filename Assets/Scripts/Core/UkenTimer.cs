using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// UkenTimer is used to easily invoke Coroutines.
/// It's especially helpful when you need to start a Coroutine in a class that isn't a MonoBehaviour as it will use a singleton to run them.
/// </summary>
public class UkenTimer : MonoBehaviour {
  
  #region singleton
  private static UkenTimer instance;
  public static UkenTimer Instance {
    get {
      if(UkenTimer.instance == null) {
        GameObject ukenTimer = new GameObject("UkenTimer");
        ukenTimer.AddComponent<UkenTimer>();
        UkenTimer.instance = ukenTimer.GetComponent<UkenTimer>();
        DontDestroyOnLoad(ukenTimer);
      }
      return instance;
    }
  }
  #endregion singleton  
  
  public static void SetTimeout(float waitTime, Action callback) {
    UkenTimer.Instance.StartCoroutine(UkenTimer.SetTimeoutCoroutine(waitTime, callback));
  }
  
  private static IEnumerator SetTimeoutCoroutine(float waitTime, Action callback) {
    yield return new WaitForSeconds(waitTime);
    callback();
  }
  
}

