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

    // Called when the player interacts (e.g. presses "E")
    public void Interact()
    {
        if (hasBeenAnswered) return;

        UIManager.Instance?.ShowInteractionPrompt(this);
    }

    // Called by UIManager after answer is processed
    public bool IsLie()
    {
        return isLie;
    }

    // Called only if answer is correct
    public void MarkAsChecked()
    {
        hasBeenAnswered = true;
        UpdateAppearance();
        gameObject.SetActive(false); // Optional: hide object after it's handled
    }

    void UpdateAppearance()
    {
        var renderer = GetComponent<Renderer>();
        if (renderer != null)
            renderer.material = isLie ? lieMaterial : truthMaterial;
    }
}
