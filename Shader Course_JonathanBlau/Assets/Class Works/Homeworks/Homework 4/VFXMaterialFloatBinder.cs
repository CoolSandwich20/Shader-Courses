using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

[VFXBinder("Material/Float")]
public class VFXMaterialFloatBinder : VFXBinderBase
{
    public string Property;

    [Header("Material 1 (Dissolve Out)")]
    public Material TargetMaterial;
    [SerializeField] public string TargetMaterialProperty = "_DissolveThreshold";

    [Header("Material 2 (Resolve In)")]
    public Material ResolveMaterial;
    [SerializeField] public string ResolveMaterialProperty = "_DissolveThreshold";

    public override bool IsValid(VisualEffect component)
    {
        return TargetMaterial != null && ResolveMaterial != null && component.HasFloat(Property);
    }

    public override void UpdateBinding(VisualEffect component)
    {
        float dissolveValue = component.GetFloat(Property);
        TargetMaterial.SetFloat(TargetMaterialProperty, dissolveValue);
        ResolveMaterial.SetFloat(ResolveMaterialProperty, 1.0f - dissolveValue); // reverse dissolve
    }

    public override string ToString()
    {
        return $"Material: '{TargetMaterial.name}' -> {TargetMaterialProperty}, Resolve: '{ResolveMaterial.name}' -> {ResolveMaterialProperty}";
    }
}
