using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonUIManager : MonoBehaviour
{
    private static SonUIManager instance;

    [Header("Prefab")]
    // ¿Œ∫•≈‰∏Æ ΩΩ∑‘ «¡∏Æ∆’
    public GameObject StructureUIManager;
    public GameObject BuildingUI;

    public static SonUIManager Instance
    {
        get
        {
            if (instance != null)
                return instance;
            else
            {
                GameObject newUIManager = Instantiate(new GameObject());
                newUIManager.AddComponent<UIManager>();
                return instance = newUIManager.GetComponent<SonUIManager>();
            }
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        BuildingUI.SetActive(false);
    }
}
