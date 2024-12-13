using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private ModelsShower _modelsShower;
    [SerializeField] private ModelsChoosePanel _modelsChoosePanel;
    [SerializeField] private ModelColorSwitcher _modelColorSwitcher;
    [SerializeField] private ModelAnimatorPanelView _modelAnimator;

    private void Awake()
    {
        ModelsNameDataSource modelsNameDataSource = new();
        ModelsFactory modelsFactory = new();
        SwitchMaterialButtonFactory switchMaterialButtonFactory = new();
        AnimationButtonFactory animationButtonFactory = new();

        _modelsShower.Init(modelsFactory);

        ModelChooseButtonFactory modelChooseButtonFactory = new(_modelsShower, modelsNameDataSource);
        _modelsChoosePanel.Init(modelChooseButtonFactory);
        _modelColorSwitcher.Init(switchMaterialButtonFactory);
        _modelAnimator.Init(animationButtonFactory);

        _modelsChoosePanel.CreateButtons();
    }
}
