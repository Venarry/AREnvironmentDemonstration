using UnityEngine;

public class ModelsChoosePanel : MonoBehaviour 
{
    [SerializeField] private Transform _parent;
    private ModelChooseButtonFactory _modelChooseButtonFactory;

    public void Init(ModelChooseButtonFactory modelChooseButtonFactory)
    {
        _modelChooseButtonFactory = modelChooseButtonFactory;
    }

    public void CreateButtons()
    {
        string[] paths = ResourcesPath.GetAllModelsPath();

        foreach (string path in paths)
        {
            _modelChooseButtonFactory.Create(_parent, path);
        }
    }
}
