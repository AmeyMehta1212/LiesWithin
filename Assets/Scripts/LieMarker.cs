using UnityEngine;

public class LieMarker : MonoBehaviour
{
    public bool isLie = true;
    public Material lieMaterial;
    public Material truthMaterial;

    private bool hasBeenAnswered = false;

    void Start()
    {
        UpdateAppearance();
    }

    public void Interact()
    {
        if (hasBeenAnswered) return;

        hasBeenAnswered = true;
        Object.FindAnyObjectByType<UIManager>()?.ShowInteractionPrompt(this);
    }

    public bool IsLie()
    {
        return isLie;
    }

    public void MarkAsChecked()
    {
        UpdateAppearance();
    }

    void UpdateAppearance()
    {
        var renderer = GetComponent<Renderer>();
        renderer.material = isLie ? lieMaterial : truthMaterial;
    }
}
