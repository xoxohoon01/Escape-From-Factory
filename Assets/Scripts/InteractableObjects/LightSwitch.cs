using UnityEngine;

public class LightSwitch : Object, IInteractable
{
    public Light targetLight;
    private bool isOn;

    private void Awake()
    {
        if (targetLight == null)
        {
            targetLight = GetComponentInChildren<Light>();
        }
    }

    void Start()
    {
        if(targetLight != null)
        {
            isOn = targetLight.enabled;
        }
    }
    public bool IsObtainable()
    {
        return false;
    }
    public void Interact()
    {
        ToggleLight();
    }

    void ToggleLight()
    {
        if(targetLight != null)
        {
            isOn = !isOn;
            targetLight.enabled = isOn;
        }
    }
}