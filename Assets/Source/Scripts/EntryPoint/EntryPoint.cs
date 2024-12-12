using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private ModelsShower _modelsShower;
    [SerializeField] private ModelsChoosePanel _modelsChoosePanel;

    private void Awake()
    {
        ModelsFactory modelsFactory = new();

        _modelsShower.Init(modelsFactory);

        ModelChooseButtonFactory modelChooseButtonFactory = new(_modelsShower);
        _modelsChoosePanel.Init(modelChooseButtonFactory);
        _modelsChoosePanel.CreateButtons();
    }
}
