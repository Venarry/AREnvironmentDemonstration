using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AnimationButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _animationNameLabel;

    private Button _button;
    private string _animationName;
    private ModelAnimatorPanelView _modelAnimator;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeAnimation);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeAnimation);
    }

    public void Init(string animationName, ModelAnimatorPanelView modelAnimator)
    {
        _animationName = animationName;
        _modelAnimator = modelAnimator;
        _animationNameLabel.text = animationName;
    }

    private void ChangeAnimation()
    {
        _modelAnimator.ChangeAnimation(_animationName);
    }
}
