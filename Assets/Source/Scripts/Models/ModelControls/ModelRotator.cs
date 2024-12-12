using UnityEngine;

public class ModelRotator : ModelDragHandler
{
    private readonly float _rotateForce = 0.1f;

    protected override void OnDrag(Vector3 deltaPosition)
    {
        float rotateValue = deltaPosition.x *= _rotateForce;

        ModelsShower.Rotate(rotateValue);
    }
}
