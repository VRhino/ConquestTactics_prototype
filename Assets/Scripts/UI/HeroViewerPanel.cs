using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows the active hero model and its stats.
/// </summary>
public class HeroViewerPanel : MonoBehaviour
{
    public RawImage heroImage;
    public RenderTexture renderTexture;
    public Text statsText;

    private GameObject modelInstance;
    private Camera renderCamera;

    /// <summary>
    /// Loads the hero model and stats from the given data.
    /// </summary>
    public void LoadHero(CharacterData data)
    {
        if (data == null)
            return;

        if (heroImage != null && renderTexture != null)
            heroImage.texture = renderTexture;

        if (modelInstance != null)
            Destroy(modelInstance);
        if (renderCamera != null)
            Destroy(renderCamera.gameObject);

        if (data.modelPrefab != null)
        {
            modelInstance = Instantiate(data.modelPrefab);
            modelInstance.transform.position = Vector3.zero;
            renderCamera = new GameObject("HeroRenderCam").AddComponent<Camera>();
            renderCamera.transform.position = modelInstance.transform.position + new Vector3(0, 1, -2);
            renderCamera.transform.LookAt(modelInstance.transform);
            renderCamera.targetTexture = renderTexture;
        }

        if (statsText != null)
            statsText.text = $"HP: {data.health}\nATK: {data.attack}\nDEF: {data.defense}";
    }
}
