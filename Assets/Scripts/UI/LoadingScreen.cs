using UnityEngine;

/// <summary>
/// Simple loading screen controller shown during scene transitions.
/// The object can exist as a prefab in the initial scene.
/// </summary>
public class LoadingScreen : MonoBehaviour
{
    /// <summary>
    /// Global access to the active LoadingScreen, if any.
    /// </summary>
    public static LoadingScreen Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Displays the loading screen.
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the loading screen.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
