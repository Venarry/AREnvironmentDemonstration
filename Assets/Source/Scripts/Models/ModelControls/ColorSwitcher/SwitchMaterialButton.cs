using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SwitchMaterialButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _indexLabel;

    private int _index;
    private Button _button;
    private ModelColorSwitcher _modelColorSwitcher;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SetMaterial);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SetMaterial);
    }

    public void Init(int index, ModelColorSwitcher modelColorSwitcher)
    {
        _index = index;
        _modelColorSwitcher = modelColorSwitcher;
        _indexLabel.text = index.ToString();
    }

    private void SetMaterial()
    {
        _modelColorSwitcher.SetMaterialIndex(_index);
    }
}
