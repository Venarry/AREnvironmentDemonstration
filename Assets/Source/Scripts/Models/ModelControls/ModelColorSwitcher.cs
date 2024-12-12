using UnityEngine;
using UnityEngine.UI;

public class ModelColorSwitcher : MonoBehaviour
{
    [SerializeField] private ModelsShower _modelsShower;
    [SerializeField] private Slider _sliderR;
    [SerializeField] private Slider _sliderG;
    [SerializeField] private Slider _sliderB;

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

    private void OnModelSet(ModelToView model)
    {
        Color modelColor = model.MaterialColor;

        _sliderR.value = modelColor.r;
        _sliderG.value = modelColor.g;
        _sliderB.value = modelColor.b;
    }

    private void OnValueChange(float _)
    {
        Color color = new(_sliderR.value, _sliderG.value, _sliderB.value);
        _modelsShower.SetColor(color);
    }
}
