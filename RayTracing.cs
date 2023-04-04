using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways, ImageEffectAllowedInSceneView]
public class RayTracing : MonoBehaviour
{
    [SerializeField] bool useShaderInSceneView;
    [SerializeField] Shader rayTracingShader;
    Material rayTracingMaterial;

    private void OnRenderImage(RenderTexture src, RenderTexture target)
    {
        Shader.SetGlobalMatrix("_CameraToWorld", GetComponent<Camera>().cameraToWorldMatrix);

        if (Camera.current.name != "SceneCamera" || useShaderInSceneView)
        {
            // Set up shader material
            rayTracingMaterial = new Material(rayTracingShader);
            UpdateCameraParams(Camera.current);
            // Run shader and draw to screen
            Graphics.Blit(null, target, rayTracingMaterial);
        } else
        {
            Graphics.Blit(src, target); // Draw unaltered render to screen
        }
    }

    void UpdateCameraParams(Camera cam)
    {
        float planeHeight = cam.nearClipPlane * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad) * 2;
        float planeWidth = planeHeight * cam.aspect;
        // send data to shader
        rayTracingMaterial.SetVector("ViewParams", new Vector3(planeWidth, planeHeight, cam.nearClipPlane));
        rayTracingMaterial.SetMatrix("CamLocalToWorldMatrix", cam.transform.localToWorldMatrix);
    }
}
