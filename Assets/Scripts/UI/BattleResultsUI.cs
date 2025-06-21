using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays the final battle summary once the fight ends.
/// </summary>
public class BattleResultsUI : MonoBehaviour
{
    [Header("UI References")]
    public CanvasGroup panelGroup;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI squadNameText;
    public TextMeshProUGUI troopCountText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI enemiesText;
    public Button continueButton;

    [Header("Settings")]
    public string lobbyScene = "Lobby";
    public float delayBeforeShowing = 2f;
    public bool animate = true;

    private void Awake()
    {
        if (continueButton != null)
            continueButton.onClick.AddListener(OnContinue);

        if (panelGroup != null)
        {
            panelGroup.alpha = 0f;
            panelGroup.interactable = false;
            panelGroup.blocksRaycasts = false;
            panelGroup.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Populates the UI and makes it visible.
    /// </summary>
    public void ShowResults(BattleResultData data)
    {
        StartCoroutine(ShowRoutine(data));
    }

    private IEnumerator ShowRoutine(BattleResultData data)
    {
        if (delayBeforeShowing > 0f)
            yield return new WaitForSeconds(delayBeforeShowing);

        UpdateTexts(data);

        if (panelGroup != null)
        {
            panelGroup.gameObject.SetActive(true);
            if (animate)
                yield return StartCoroutine(FadeIn());
            else
            {
                panelGroup.alpha = 1f;
                panelGroup.interactable = true;
                panelGroup.blocksRaycasts = true;
            }
        }
    }

    private void UpdateTexts(BattleResultData data)
    {
        bool victory = data.result == BattleManager.BattleState.Victory;
        if (titleText != null)
        {
            titleText.text = victory ? "¡Victoria!" : "Derrota";
            titleText.color = victory ? Color.green : Color.red;
        }

        if (squadNameText != null)
            squadNameText.text = data.squadName;

        if (troopCountText != null)
            troopCountText.text = $"{data.unitsRemaining}/{data.unitsInitial}";

        if (timeText != null)
            timeText.text = FormatTime(data.battleDuration);

        if (enemiesText != null)
        {
            if (data.enemiesDefeated > 0)
            {
                enemiesText.gameObject.SetActive(true);
                enemiesText.text = data.enemiesDefeated.ToString();
            }
            else
            {
                enemiesText.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            if (panelGroup != null)
                panelGroup.alpha = Mathf.Lerp(0f, 1f, t);
            yield return null;
        }
        if (panelGroup != null)
        {
            panelGroup.alpha = 1f;
            panelGroup.interactable = true;
            panelGroup.blocksRaycasts = true;
        }
    }

    private static string FormatTime(float seconds)
    {
        int mins = Mathf.FloorToInt(seconds / 60f);
        int secs = Mathf.FloorToInt(seconds % 60f);
        return $"{mins:00}:{secs:00}";
    }

    private void OnContinue()
    {
        DisablePlayerInput();
        SceneLoader.LoadScene(lobbyScene);
        if (panelGroup != null)
            panelGroup.gameObject.SetActive(false);
    }

    private void DisablePlayerInput()
    {
        var input = FindObjectOfType<HeroInputController>();
        if (input != null)
            input.enabled = false;
        var movement = FindObjectOfType<PlayerMovement>();
        if (movement != null)
            movement.enabled = false;
    }
}
