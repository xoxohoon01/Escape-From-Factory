using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    private UnityEngine.Material originalMaterial;
    private UnityEngine.Material warningMaterial;

    public bool Istrigger { get; private set; }

    private void Start()
    {
        int interactableLayer = LayerMask.NameToLayer("Interactable");

        warningMaterial = new UnityEngine.Material(Shader.Find("Standard"));
        warningMaterial.color = new Color(1, 0, 0, 0.5f);
        warningMaterial.SetFloat("_Mode", 2);
        warningMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        warningMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        warningMaterial.SetInt("_ZWrite", 0);
        warningMaterial.DisableKeyword("_ALPHATEST_ON");
        warningMaterial.EnableKeyword("_ALPHABLEND_ON");
        warningMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        warningMaterial.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            Renderer renderer = other.GetComponent<Renderer>();
            if (renderer != null)
            {
                originalMaterial = renderer.material;
                renderer.material = warningMaterial;
                Istrigger = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            Renderer renderer = other.GetComponent<Renderer>();
            if (renderer != null && originalMaterial != null)
            {
                renderer.material = originalMaterial;
                Istrigger = false;
            }
        }
    }
}
