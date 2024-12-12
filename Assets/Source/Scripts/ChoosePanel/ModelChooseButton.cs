using UnityEngine;
using UnityEngine.UI;

public class ModelChooseButton : MonoBehaviour
{
    private Button _button;
    private string _modelPath;
    private ModelsShower _modelsShower;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ShowModel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ShowModel);
    }

    public void Init(string modelPath, ModelsShower modelsShower)
    {
        _modelPath = modelPath;
        _modelsShower = modelsShower;
    }

    private void ShowModel()
    {
        _modelsShower.ShowByPath(_modelPath);
    }
}
