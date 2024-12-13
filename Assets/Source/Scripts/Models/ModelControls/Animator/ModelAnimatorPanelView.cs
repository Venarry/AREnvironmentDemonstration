using System.Collections.Generic;
using UnityEngine;

public class ModelAnimatorPanelView : MonoBehaviour
{
    [SerializeField] private ModelsShower _modelsShower;
    [SerializeField] private Transform _buttonsParent;

    private readonly List<AnimationButton> _animationButtons = new();
    private AnimationButtonFactory _animationButtonFactory;
    private ModelToView _activeModel;

    private void OnEnable()
    {
        _modelsShower.ModelSet += OnModelSet;
    }

    private void OnDisable()
    {
        _modelsShower.ModelSet -= OnModelSet;
    }

    public void Init(AnimationButtonFactory animationButtonFactory)
    {
        _animationButtonFactory = animationButtonFactory;
    }

    private void OnModelSet(ModelToView model)
    {
        _activeModel = model;

        foreach (AnimationButton button in _animationButtons)
        {
            Destroy(button.gameObject);
        }

        _animationButtons.Clear();

        if(model.HasAnimations == false)
        {
            return;
        }

        foreach (string animationName in model.AnimationsName)
        {
            AnimationButton button = _animationButtonFactory.Create(_buttonsParent, animationName, this);
            _animationButtons.Add(button);
        }
    }

    public void ChangeAnimation(string name, float transitionDuration = 0.1f, bool canRepeat = false)
    {
        _activeModel.ChangeAnimation(name, transitionDuration, canRepeat);
    }
}