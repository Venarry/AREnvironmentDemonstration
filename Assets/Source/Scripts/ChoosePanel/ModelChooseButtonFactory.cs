using UnityEngine;

public class ModelChooseButtonFactory
{
    private readonly ModelChooseButton _prefab = Resources.Load<ModelChooseButton>(ResourcesPath.ModelChooseButton);
    private readonly ModelsShower _modelsShower;
    private readonly ModelsNameDataSource _modelsNameDataSource;

    public ModelChooseButtonFactory(
        ModelsShower modelsShower,
        ModelsNameDataSource modelsNameDataSource)
    {
        _modelsShower = modelsShower;
        _modelsNameDataSource = modelsNameDataSource;
    }

    public ModelChooseButton Create(Transform parent, string modelPath)
    {
        ModelChooseButton button = Object.Instantiate(_prefab, parent);
        string modelName = _modelsNameDataSource.GetName(modelPath);
        button.Init(modelPath, _modelsShower, modelName);

        return button;
    }
}
