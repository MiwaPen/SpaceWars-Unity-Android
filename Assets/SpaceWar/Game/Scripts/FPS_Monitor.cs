using UnityEngine;
using TMPro;

public class FPS_Monitor : MonoBehaviour
{
    [SerializeField] private TMP_Text fpsLabel;
    void Update()
    {
        fpsLabel.text = "FPS: " +1/Time.unscaledDeltaTime; 
    }
}
