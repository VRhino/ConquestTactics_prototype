using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Handles the local matchmaking flow. Shows a searching panel,
/// validates the player's selection and loads a battle scene after a
/// short simulated delay.
/// </summary>
public class Matchmaker : MonoBehaviour
{
    [Header("UI References")]
    public Button searchButton;
    public GameObject searchingPanel;
    public TMP_Text searchingText;
    public Button cancelButton;

    [Header("Settings")]
    [Tooltip("Battle scene to load once a match is found")]
    public string battleSceneName = "BattleMap01";
    [Tooltip("Allow matchmaking to start with the M key in development builds")]
    public bool allowDevShortcut = true;

    private Coroutine currentRoutine;
    private bool isSearching;
    private float dotsTimer;

    private void Awake()
    {
        if (searchButton != null)
            searchButton.onClick.AddListener(StartMatchmaking);
        if (cancelButton != null)
            cancelButton.onClick.AddListener(CancelMatchmaking);
        if (searchingPanel != null)
            searchingPanel.SetActive(false);
    }

    private void Update()
    {
        if (allowDevShortcut && !isSearching && Input.GetKeyDown(KeyCode.M))
            StartMatchmaking();

        AnimateSearchingText();
    }

    /// <summary>
    /// Begins the matchmaking process after validating the player loadout.
    /// </summary>
    public void StartMatchmaking()
    {
        if (isSearching)
            return;

        if (!ValidateLoadout())
        {
            Debug.LogWarning("Debes seleccionar un héroe y escuadra antes de buscar partida.");
            return;
        }

        if (searchButton != null)
            searchButton.interactable = false;
        if (searchingPanel != null)
            searchingPanel.SetActive(true);
        isSearching = true;
        currentRoutine = StartCoroutine(FindMatchRoutine());
    }

    /// <summary>
    /// Coroutine that waits a short random duration and then loads the battle scene.
    /// </summary>
    private IEnumerator FindMatchRoutine()
    {
        float wait = Random.Range(3f, 5f);
        yield return new WaitForSeconds(wait);

        Debug.Log("Match encontrado, cargando mapa...");
        StoreSceneData();
        SceneLoader.LoadBattle(battleSceneName);
    }

    /// <summary>
    /// Stops the matchmaking process if it is running.
    /// </summary>
    public void CancelMatchmaking()
    {
        if (!isSearching)
            return;

        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        ResetUI();
    }

    private void ResetUI()
    {
        isSearching = false;
        if (searchButton != null)
            searchButton.interactable = true;
        if (searchingPanel != null)
            searchingPanel.SetActive(false);
    }

    /// <summary>
    /// Validates that the player has a hero and squad selected.
    /// </summary>
    public bool ValidateLoadout()
    {
        var hero = PlayerProfileManager.Instance.GetActiveHero();
        var squad = PlayerProfileManager.Instance.GetActiveSquad();
        return hero != null && squad != null;
    }

    private void StoreSceneData()
    {
        var carrier = SceneDataCarrier.Instance;
        if (carrier == null)
            return;

        carrier.activeHero = PlayerProfileManager.Instance.GetActiveHero();
        carrier.selectedSquad = PlayerProfileManager.Instance.GetActiveSquad();
        carrier.cameFromMatchmaking = true;
    }

    private void AnimateSearchingText()
    {
        if (!isSearching || searchingText == null)
            return;

        dotsTimer += Time.deltaTime * 3f;
        int dotCount = 1 + (int)dotsTimer % 3;
        searchingText.text = "Buscando partida" + new string('.', dotCount);
    }
}
