using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ModelDragHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    [SerializeField] protected ModelsShower ModelsShower;

    private Vector3 _lastDragPoint = Vector3.zero;
    private bool _isDragging = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        _lastDragPoint = eventData.position;
        _isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isDragging = false;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (_isDragging == false)
            return;

        Vector3 currentPosition = eventData.position;
        Vector3 deltaPosition = currentPosition - _lastDragPoint;

        OnDrag(deltaPosition);
        _lastDragPoint = currentPosition;
    }

    protected abstract void OnDrag(Vector3 deltaPosition);
}
