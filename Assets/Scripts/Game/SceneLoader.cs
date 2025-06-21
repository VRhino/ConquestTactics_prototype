using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Static helper responsible for changing scenes asynchronously.
/// </summary>
public static class SceneLoader
{
    /// <summary>
    /// Indicates if a scene is currently being loaded.
    /// </summary>
    public static bool isLoading { get; private set; }

    // Internal runner to start coroutines without requiring a scene object.
    private class LoaderRunner : MonoBehaviour { }
    private static LoaderRunner runner;

    /// <summary>
    /// Ensures there is a runner object in the scene to host coroutines.
    /// </summary>
    private static void EnsureRunner()
    {
        if (runner != null)
            return;
        var obj = new GameObject("SceneLoaderRunner");
        Object.DontDestroyOnLoad(obj);
        runner = obj.AddComponent<LoaderRunner>();
    }

    /// <summary>
    /// Starts asynchronous loading of the target scene.
    /// Shows the LoadingScreen if present.
    /// </summary>
    /// <param name="sceneName">Name of the scene to load.</param>
    public static void LoadScene(string sceneName)
    {
        if (isLoading)
        {
            Debug.LogWarning("SceneLoader: attempted to load a scene while another load is in progress.");
            return;
        }
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            Debug.LogWarning($"SceneLoader: scene '{sceneName}' is already active.");
            return;
        }

        EnsureRunner();
        runner.StartCoroutine(LoadRoutine(sceneName));
    }

    /// <summary>
    /// Coroutine that performs the actual asynchronous scene loading.
    /// </summary>
    private static IEnumerator LoadRoutine(string sceneName)
    {
        isLoading = true;

        if (LoadingScreen.Instance != null)
            LoadingScreen.Instance.Show();

        Debug.Log($"Cargando escena {sceneName}...");

        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        while (!op.isDone)
        {
            // Future: report progress to LoadingScreen here
            yield return null;
        }

        if (LoadingScreen.Instance != null)
            LoadingScreen.Instance.Hide();

        isLoading = false;
    }

    /// <summary>
    /// Loads the lobby scene.
    /// </summary>
    public static void LoadLobby() => LoadScene("Lobby");

    /// <summary>
    /// Loads the main menu scene.
    /// </summary>
    public static void LoadMainMenu() => LoadScene("MainMenu");

    /// <summary>
    /// Loads a battle scene by name.
    /// </summary>
    public static void LoadBattle(string mapName) => LoadScene(mapName);
}
