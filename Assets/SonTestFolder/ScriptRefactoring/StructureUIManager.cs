using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StructureUIManager : MonoBehaviour
{
    public StructureUIDataSO menuData;

    private void Awake()
    {
        MakeMenuBackground();
        MakeMenuIcon();
    }

    private void MakeMenuBackground()
    {
        GameObject _ringMenuContainer = new GameObject("MenuBackGround");
        _ringMenuContainer.transform.SetParent(gameObject.transform, false);

        for (int _i = 0; _i < menuData.selectableMenus.Count; _i++)
        {
            GameObject _ringMenuObject = new GameObject(menuData.selectableMenus[_i].name);
            _ringMenuObject.transform.SetParent(_ringMenuContainer.transform, false);

            RectTransform _ringMenuRect = _ringMenuObject.AddComponent<RectTransform>();
            _ringMenuRect.sizeDelta = new Vector2(700, 700);
            _ringMenuRect.localEulerAngles = new Vector3(0, 0, -(360f / menuData.selectableMenus.Count) * _i);

            Image _ringMenuImage = _ringMenuObject.AddComponent<Image>();
            _ringMenuImage.sprite = menuData.menuSprite;
            _ringMenuImage.color = new Color(0f, 0f, 0f, 0.8f);
            _ringMenuImage.type = Image.Type.Filled;
            _ringMenuImage.fillMethod = Image.FillMethod.Radial360;
            _ringMenuImage.fillOrigin = 2;
            _ringMenuImage.fillAmount = ((360f / menuData.selectableMenus.Count) - 1f) / 360f;
        }
    }

    private void MakeMenuIcon()
    {
        for (int _i = 0; _i < menuData.selectableMenus.Count; _i++)
        {
            float _radians = ((90 - 180f / menuData.selectableMenus.Count) - (360f / menuData.selectableMenus.Count) * _i) * Mathf.Deg2Rad;
            float _x = 280f * Mathf.Cos(_radians);
            float _y = 280f * Mathf.Sin(_radians);

            GameObject _menuIconObject = new GameObject(menuData.selectableMenus[_i].name + "Icon");
            _menuIconObject.transform.SetParent(gameObject.transform, false);

            RectTransform _menuIconRect = _menuIconObject.AddComponent<RectTransform>();
            _menuIconRect.localPosition = new Vector3(_x, _y, 0f);

            Image _menuIconImage = _menuIconObject.AddComponent<Image>();
            _menuIconImage.sprite = menuData.selectableMenus[_i].icon;

            Button _menuIconButton = _menuIconObject.AddComponent<Button>();
            int _currentIndex = _i;
            MenuType _currentMenuType = menuData.selectableMenus[_currentIndex].menuType;
            _menuIconButton.onClick.AddListener(() => SetButtonEventMethod(_currentMenuType));
        }
    }

    private void SetButtonEventMethod(MenuType menuType)
    {
        switch (menuType)
        {
            case MenuType.Build:
                OnBuildStructure();
                break;
            case MenuType.Move:
                OnMoveStructure();
                break;
            case MenuType.Remove:
                OnRemoveStructure();
                break;
            default:
                Debug.LogWarning("Unknown menu type: " + menuType);
                break;
        }
    }

    private void OnBuildStructure()
    {
        SonUIManager.Instance.StructureUIManager.SetActive(false);
        SonUIManager.Instance.BuildingUI.SetActive(true);
        //UIManager.Instance.StructureUIManager.SetActive(false);
        //UIManager.Instance.BuildingUI.SetActive(true);
    }

    private void OnMoveStructure()
    {
        SonUIManager.Instance.StructureUIManager.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        menuData.RaiseMoveEvent();
    }

    private void OnRemoveStructure()
    {
        SonUIManager.Instance.StructureUIManager.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        menuData.RaiseDestroyEvent();
    }
}
