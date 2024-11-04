using UnityEngine;
using UnityEngine.UI;

public class StructureUIButtonHandler : MonoBehaviour
{
    public BuildingManager_Son buildingManager;

    private void Awake()
    {
        buildingManager = GetComponentInParent<BuildingManager_Son>();
    }

    private void Start()
    {
        MakeStructureUIButton();
    }

    private void MakeStructureUIButton()
    {
        MakeEmptyObject();
        MakeStructureButton();
    }

    private void MakeEmptyObject()
    {
        GameObject empty = new GameObject("Empty");
        RectTransform rectTransform = empty.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(0, 0);
        empty.transform.SetParent(gameObject.transform, false);
    }

    private void MakeStructureButton()
    {
        for (int _index = 0; _index < buildingManager.objects.Length; _index++)
        {
            GameObject _buttonObject = new GameObject(buildingManager.objects[_index].name);
            _buttonObject.transform.SetParent(gameObject.transform, false);

            RectTransform _buttonRect = _buttonObject.AddComponent<RectTransform>();
            _buttonRect.sizeDelta = new Vector2(80, 80);

            Button _button = _buttonObject.AddComponent<Button>();
            int _currentIndex = _index;
            _button.onClick.AddListener(() => buildingManager.SelectObject(_currentIndex));


            GameObject _backgroundImageObject = new GameObject("BackgroundImage");
            _backgroundImageObject.transform.SetParent(_buttonObject.transform, false);

            RectTransform _backgroundImageRect = _backgroundImageObject.AddComponent<RectTransform>();
            _backgroundImageRect.sizeDelta = new Vector2(80, 80);
            _backgroundImageRect.anchoredPosition = Vector2.zero;

            Image _bgImage = _backgroundImageObject.AddComponent<Image>();
            _bgImage.color = Color.black;


            GameObject _structureIconObject = new GameObject("StructureIcon");
            _structureIconObject.transform.SetParent(_buttonObject.transform, false);

            RectTransform _structureIconRect = _structureIconObject.AddComponent<RectTransform>();
            _structureIconRect.sizeDelta = new Vector2(80, 80);
            _structureIconRect.anchoredPosition = Vector2.zero;

            Image _iconImage = _structureIconObject.AddComponent<Image>();
            _iconImage.sprite = buildingManager.objects[_index].icon;
        }
    }
}
