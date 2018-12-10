using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 挂到camera上
/// 未测试，不知道有没有效果（好像没有），
/// 用于调整屏幕分辨率
/// </summary>
public class CameraSetting : MonoBehaviour {
    //float devHeight = 9.6f;
    float devWidth = 6.4f;

    // Use this for initialization
    void Start()
    {
        float screenHeight = Screen.height;
        Debug.Log("screenHeight = " + screenHeight);
        float orthographicSize = this.GetComponent<Camera>().orthographicSize;
        float aspectRatio = Screen.width * 1.0f / Screen.height;
        float cameraWidth = orthographicSize * 2 * aspectRatio;
        Debug.Log("cameraWidth = " + cameraWidth);
        if (cameraWidth < devWidth)
        {
            orthographicSize = devWidth / (2 * aspectRatio);
            Debug.Log("new orthographicSize = " + orthographicSize);
            this.GetComponent<Camera>().orthographicSize = orthographicSize;
        }

    }
}