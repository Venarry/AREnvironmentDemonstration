using System.Collections.Generic;
using UnityEngine;

public class ModelsFactory
{
    private readonly Dictionary<string, ModelToView> _modelsPrefab = new();

    public ModelsFactory()
    {
        string[] paths = ResourcesPath.GetAllModelsPath();

        foreach (string item in paths)
        {
            ModelToView prefab = Resources.Load<ModelToView>(item);
            _modelsPrefab.Add(item, prefab);
        }
    }

    public ModelToView CreateByPath(string path, Vector3 position, Quaternion rotation)
    {
        ModelToView prefab = _modelsPrefab[path];
        ModelToView model = Object.Instantiate(prefab, position, rotation);

        return model;
    }
}
