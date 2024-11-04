using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    public BuildUIDataSO objectData;

    private void Awake()
    {
        MakeMenuBackground();
        MakeMenuIcon();
    }


    private void MakeMenuBackground()
    {
        GameObject _ringMenuContainer = new GameObject("MenuBackGround");
        _ringMenuContainer.transform.SetParent(gameObject.transform, false);

        for (int _i = 0; _i < objectData.selectableObjects.Count; _i++)
        {
            GameObject _ringMenuObject = new GameObject(objectData.selectableObjects[_i].name);
            _ringMenuObject.transform.SetParent(_ringMenuContainer.transform, false);

            RectTransform _ringMenuRect = _ringMenuObject.AddComponent<RectTransform>();
            _ringMenuRect.sizeDelta = new Vector2(700, 700);
            _ringMenuRect.localEulerAngles = new Vector3(0, 0, -(360f / objectData.selectableObjects.Count) * _i);

            Image _ringMenuImage = _ringMenuObject.AddComponent<Image>();
            _ringMenuImage.sprite = objectData.menuSprite;
            _ringMenuImage.color = new Color(0f, 0f, 0f, 0.8f);
            _ringMenuImage.type = Image.Type.Filled;
            _ringMenuImage.fillMethod = Image.FillMethod.Radial360;
            _ringMenuImage.fillOrigin = 2;
            _ringMenuImage.fillAmount = ((360f / objectData.selectableObjects.Count) - 1f) / 360f;

        }
    }

    private void MakeMenuIcon()
    {
        for (int _i = 0; _i < objectData.selectableObjects.Count; _i++)
        {
            float _radians = ((90 - 180f / objectData.selectableObjects.Count) - (360f / objectData.selectableObjects.Count) * _i) * Mathf.Deg2Rad;
            float _x = 280f * Mathf.Cos(_radians);
            float _y = 280f * Mathf.Sin(_radians);

            GameObject _menuIconObject = new GameObject(objectData.selectableObjects[_i].name + "Icon");
            _menuIconObject.transform.SetParent(gameObject.transform, false);

            RectTransform _menuIconRect = _menuIconObject.AddComponent<RectTransform>();
            _menuIconRect.localPosition = new Vector3(_x, _y, 0f);
            // _menuIconRect.localEulerAngles = new Vector3(0, 0, (360f / menuData.selectableMenus.Count) * _i);

            Image _menuIconImage = _menuIconObject.AddComponent<Image>();
            _menuIconImage.sprite = objectData.selectableObjects[_i].icon;

            Button _menuIconButton = _menuIconObject.AddComponent<Button>();
            int _currentIndex = _i;
            //_menuIconButton.onClick.AddListener(() => objectData.selectableObjects[_currentIndex]);
        }
    }
}
