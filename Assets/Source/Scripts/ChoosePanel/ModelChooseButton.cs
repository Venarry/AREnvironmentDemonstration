using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModelChooseButton : MonoBehaviour 
{
    [SerializeField] private TMP_Text _nameLabel;

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

    public void Init(string modelPath, ModelsShower modelsShower, string name)
    {
        _modelPath = modelPath;
        _modelsShower = modelsShower;
        _nameLabel.text = name;
    }

    private void ShowModel()
    {
        _modelsShower.ShowByPath(_modelPath);
    }
}
