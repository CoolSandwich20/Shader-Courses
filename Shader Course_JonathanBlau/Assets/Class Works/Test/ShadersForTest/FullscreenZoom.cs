using UnityEngine;

[ExecuteInEditMode]
public class FullscreenZoom : MonoBehaviour
{
    public Material zoomMaterial;
    [Range(0, 1)] public float zoomAmount = 0f;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (zoomMaterial != null)
        {
            zoomMaterial.SetFloat("_ZoomAmount", zoomAmount);
            Graphics.Blit(src, dest, zoomMaterial);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}
