using UnityEngine;

public class ModelChooseButtonFactory
{
    private readonly ModelChooseButton _prefab = Resources.Load<ModelChooseButton>(ResourcesPath.ModelChooseButton);
    private readonly ModelsShower _modelsShower;

    public ModelChooseButtonFactory(ModelsShower modelsShower)
    {
        _modelsShower = modelsShower;
    }

    public ModelChooseButton Create(Transform parent, string modelPath)
    {
        ModelChooseButton button = Object.Instantiate(_prefab, parent);
        button.Init(modelPath, _modelsShower);

        return button;
    }
}
