using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModelScaler : ModelDragHandler
{
    private readonly float _scalingForce = 0.002f;

    protected override void OnDrag(Vector3 deltaPosition)
    {
        float targetScale = deltaPosition.y * _scalingForce;

        ModelsShower.AddScale(targetScale);
    }
}
