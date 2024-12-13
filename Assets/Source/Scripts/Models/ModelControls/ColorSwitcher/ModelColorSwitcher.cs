using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelColorSwitcher : MonoBehaviour
{
    [SerializeField] private ModelsShower _modelsShower;
    [SerializeField] private Slider _sliderR;
    [SerializeField] private Slider _sliderG;
    [SerializeField] private Slider _sliderB;

    [SerializeField] private Transform _buttonsParent;
    private readonly List<SwitchMaterialButton> _materialButtons = new();
    private SwitchMaterialButtonFactory _switchMaterialButtonFactory;

    private ModelToView _activeModel;
    private int _activeMaterialIndex;

    private void OnEnable()
    {
        _modelsShower.ModelSet += OnModelSet;

        _sliderR.onValueChanged.AddListener(OnValueChange);
        _sliderG.onValueChanged.AddListener(OnValueChange);
        _sliderB.onValueChanged.AddListener(OnValueChange);
    }

    private void OnDisable()
    {
        _modelsShower.ModelSet -= OnModelSet;

        _sliderR.onValueChanged.RemoveListener(OnValueChange);
        _sliderG.onValueChanged.RemoveListener(OnValueChange);
        _sliderB.onValueChanged.RemoveListener(OnValueChange);
    }

    public void Init(SwitchMaterialButtonFactory switchMaterialButtonFactory)
    {
        _switchMaterialButtonFactory = switchMaterialButtonFactory;
    }

    public void SetMaterialIndex(int index)
    {
        if (index < 0)
            return;

        Color[] activeModelColors = _activeModel.MaterialsColor;
        _activeMaterialIndex = index;

        _sliderR.value = activeModelColors[_activeMaterialIndex].r;
        _sliderG.value = activeModelColors[_activeMaterialIndex].g;
        _sliderB.value = activeModelColors[_activeMaterialIndex].b;
    }

    private void OnModelSet(ModelToView model)
    {
        _activeModel = model;
        Color[] activeModelColors = model.MaterialsColor;

        SetMaterialIndex(0);
        RespawnMaterialButtons(activeModelColors);
    }

    private void RespawnMaterialButtons(Color[] colors)
    {
        foreach (SwitchMaterialButton button in _materialButtons)
        {
            Destroy(button.gameObject);
        }

        _materialButtons.Clear();

        int minMaterialsCountForSpawnButtons = 2;

        if (colors.Length < minMaterialsCountForSpawnButtons)
        {
            return;
        }

        for (int i = 0; i < colors.Length; i++)
        {
            SwitchMaterialButton button = _switchMaterialButtonFactory.Create(this, _buttonsParent, i);
            _materialButtons.Add(button);
        }
    }

    private void OnValueChange(float _)
    {
        Color color = new(_sliderR.value, _sliderG.value, _sliderB.value);
        _modelsShower.SetColor(color, _activeMaterialIndex);
    }
}