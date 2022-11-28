using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private GameBuilderScript gameBuilderScript;
    private List<float> taps = new List<float> ();
    public static float tapsPerSecond;
     
    private void Update () {
        for (int i = 0; i < taps.Count; i++) {
            if (taps[i] <= Time.timeSinceLevelLoad - 1) {
                taps.RemoveAt(i);
            }
        }
        tapsPerSecond = taps.Count;
        
        if (tapsPerSecond > 5 && gameBuilderScript.tutorialEnabled) {
            gameBuilderScript.FinishTutorial();
        }
        
        if (Input.touchCount == 0) return;
        Touch touch = Input.touches[0];
        if (touch.phase == TouchPhase.Ended) {
            taps.Add(Time.timeSinceLevelLoad);
        }
    }
}
