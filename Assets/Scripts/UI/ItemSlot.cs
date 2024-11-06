using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public InteractableObjectSO _data;
    public InteractableObjectSO data
    {
        get { return _data; }
        set
        {
            _data = value;
            image.sprite = _data.icon;
        }
    }
    public Image image;
    public TMP_Text stackText;
}
