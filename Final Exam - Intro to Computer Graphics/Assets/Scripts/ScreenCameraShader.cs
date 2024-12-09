using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCameraShader : MonoBehaviour
{
    [SerializeField] Material colorCorrectionMaterial;
    bool colorCorrectionActive = true;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (colorCorrectionActive)
        {
            Graphics.Blit(source, destination, colorCorrectionMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    void Update()
    {
        // Hit the number 1 key to turn off color correction
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            colorCorrectionActive = false;
        }
        // Hit the number 2 key to turn on color correction
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            colorCorrectionActive = true;
        }
    }
}
