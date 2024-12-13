using UnityEngine;

public class AnimationButtonFactory
{
    private readonly AnimationButton _prefab = Resources.Load<AnimationButton>(ResourcesPath.AnimationButton);

    public AnimationButton Create(Transform parent, string animationName, ModelAnimatorPanelView modelAnimator)
    {
        AnimationButton animationButton = UnityEngine.Object.Instantiate(_prefab, parent);
        animationButton.Init(animationName, modelAnimator);

        return animationButton;
    }
}
