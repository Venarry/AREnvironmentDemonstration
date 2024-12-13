using System;
using System.Collections.Generic;
using UnityEngine;

public class ModelsShower : MonoBehaviour
{
    private readonly Dictionary<string, ModelToView> _spawnedModels = new();
    private readonly float _minScale = 0.2f;

    private ModelToView _activeModel;
    private ModelsFactory _modelsFactory;

    private Vector3 _position = Vector3.zero;
    private Quaternion _rotation = Quaternion.identity;

    public event Action<ModelToView> ModelSet;

    public void Init(ModelsFactory modelsFactory)
    {
        _modelsFactory = modelsFactory;
    }

    public void ShowByPath(string path)
    {
        if (_spawnedModels.ContainsKey(path) == false)
        {
            ModelToView createdModel = _modelsFactory.CreateByPath(path, _position, _rotation);
            _spawnedModels.Add(path, createdModel);
        }

        ModelToView currentModel = _spawnedModels[path];

        if (currentModel == _activeModel)
            return;

        SetActiveModel(currentModel);
        _activeModel.transform.localScale = Vector3.one;

        ModelSet?.Invoke(currentModel);
    }

    public void SetPosition(Vector3 position)
    {
        if (_activeModel == null)
            return;

        _activeModel.transform.position = position;
        _position = position;
    }

    public void Rotate(float deltaRotation)
    {
        if (_activeModel == null)
            return;

        _activeModel.transform.Rotate(deltaRotation * Vector3.up);
    }

    public void AddScale(float value)
    {
        if (_activeModel == null)
            return;

        _activeModel.transform.localScale += new Vector3(value, value, value);

        if (_activeModel.transform.localScale.x < _minScale)
        {
            _activeModel.transform.localScale = new Vector3(_minScale, _minScale, _minScale);
        }
    }

    public void SetColor(Color color, int index)
    {
        if (_activeModel == null)
            return;

        _activeModel.SetColor(color, index);
    }

    private void SetActiveModel(ModelToView modelToView)
    {
        if (_activeModel != null)
        {
            _activeModel.gameObject.SetActive(false);
        }

        modelToView.gameObject.SetActive(true);
        _activeModel = modelToView;
    }
}
