using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ModelMover : MonoBehaviour, IPointerMoveHandler
{
    [SerializeField] private ModelsShower _modelsShower;
    [SerializeField] private ARRaycastManager _raycastManager;

    private readonly List<ARRaycastHit> _hits = new();

    public void OnPointerMove(PointerEventData eventData)
    {
        MoveModel();
    }

    private void MoveModel()
    {
        int targetTounchIndex = 0;

        if (Input.touchCount > targetTounchIndex)
        {
            Touch touch = Input.GetTouch(targetTounchIndex);

            if (_raycastManager.Raycast(touch.position, _hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = _hits[0].pose;

                _modelsShower.SetPosition(hitPose.position);
            }
        }
    }
}
