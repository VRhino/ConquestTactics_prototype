using UnityEngine.SceneManagement;

/// <summary>
/// Utility class for handling scene transitions.
/// </summary>
public static class SceneLoader
{
    private static string nextScene;

    /// <summary>
    /// Loads a given scene through an optional loading screen.
    /// </summary>
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScreen");
    }

    /// <summary>
    /// Returns the scene name queued for loading.
    /// </summary>
    public static string GetNextScene() => nextScene;
}
