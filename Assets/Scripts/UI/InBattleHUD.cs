using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Main in-battle HUD providing squad status and quick commands.
/// </summary>
public class InBattleHUD : MonoBehaviour
{
    [Header("UI References")]
    public CanvasGroup panelGroup;
    public TextMeshProUGUI squadNameText;
    public TextMeshProUGUI troopCountText;
    public TextMeshProUGUI formationText;
    public TextMeshProUGUI timerText;
    public Button followButton;
    public Button holdButton;
    public Button attackButton;
    public Button changeFormationButton;

    [Header("Visual Feedback")]
    public Color activeColor = Color.green;
    public Color inactiveColor = Color.white;
    public Color timeWarningColor = Color.red;

    public event System.Action OnChangeFormationRequest;

    private SquadCommandSystem commandSystem;
    private SquadManager squadManager;
    private SquadCommandSystem.SquadCommand activeCommand;
    private int totalTroops;
    private float updateTimer;

    private void Awake()
    {
        if (followButton != null)
            followButton.onClick.AddListener(() => OnCommandButtonClicked(SquadCommandSystem.SquadCommand.Follow));
        if (holdButton != null)
            holdButton.onClick.AddListener(() => OnCommandButtonClicked(SquadCommandSystem.SquadCommand.HoldPosition));
        if (attackButton != null)
            attackButton.onClick.AddListener(() => OnCommandButtonClicked(SquadCommandSystem.SquadCommand.AttackTarget));
        if (changeFormationButton != null)
            changeFormationButton.onClick.AddListener(RequestFormationChange);
    }

    private void OnEnable()
    {
        BattleManager.Instance.OnBattleEnd += HandleBattleEnd;
        if (BattleTimer.Instance != null)
        {
            BattleTimer.Instance.OnTimerTick += UpdateTimerText;
            BattleTimer.Instance.OnTimeWarning += DisplayTimeWarning;
            if (timerText != null)
                timerText.text = BattleTimer.GetFormattedElapsedTime();
        }
        updateTimer = 1f;
        UpdateHUD();
    }

    private void OnDisable()
    {
        if (BattleManager.Instance != null)
            BattleManager.Instance.OnBattleEnd -= HandleBattleEnd;
        if (BattleTimer.Instance != null)
        {
            BattleTimer.Instance.OnTimerTick -= UpdateTimerText;
            BattleTimer.Instance.OnTimeWarning -= DisplayTimeWarning;
        }
    }

    private void Update()
    {
        if (BattleManager.Instance == null)
            return;

        bool active = BattleManager.Instance.CurrentState == BattleManager.BattleState.Ongoing;
        if (panelGroup != null)
        {
            panelGroup.alpha = active ? 1f : 0f;
            panelGroup.interactable = active;
            panelGroup.blocksRaycasts = active;
        }
        if (!active)
            return;

        updateTimer += Time.deltaTime;
        if (updateTimer >= 1f)
        {
            updateTimer = 0f;
            UpdateHUD();
        }
    }

    /// <summary>
    /// Updates all visible info based on the current squad.
    /// </summary>
    public void UpdateHUD()
    {
        if (squadManager == null)
            squadManager = SquadManager.Instance;
        if (commandSystem == null)
            commandSystem = FindObjectOfType<SquadCommandSystem>();

        if (squadManager == null || squadManager.activeSquad == null)
        {
            if (squadNameText != null)
                squadNameText.text = "Sin escuadra desplegada";
            if (troopCountText != null)
                troopCountText.text = "0/0";
            if (formationText != null)
                formationText.text = "-";
            return;
        }

        var loadout = squadManager.activeSquad.Loadout;
        if (loadout != null && squadNameText != null)
            squadNameText.text = loadout.name;

        totalTroops = squadManager.GetInitialUnitCount();
        int alive = squadManager.GetCurrentUnitCount();
        if (troopCountText != null)
            troopCountText.text = $"{alive}/{totalTroops}";

        var formation = squadManager.activeSquad.Formation;
        if (formationText != null)
        {
            string fName = formation != null && formation.currentFormation != null ? formation.currentFormation.formationName : "-";
            formationText.text = fName;
        }

        UpdateCommandVisuals();
    }

    /// <summary>
    /// Sends the selected command to the SquadCommandSystem.
    /// </summary>
    public void OnCommandButtonClicked(SquadCommandSystem.SquadCommand command)
    {
        if (commandSystem == null)
            commandSystem = FindObjectOfType<SquadCommandSystem>();
        commandSystem?.IssueCommand(command);
        activeCommand = command;
        UpdateCommandVisuals();
    }

    /// <summary>
    /// Populates initial squad data if needed.
    /// </summary>
    public void SetSquadData(SquadLoadout loadout)
    {
        if (loadout == null)
            return;
        totalTroops = 0;
        foreach (var t in loadout.troops)
            if (t != null)
                totalTroops += t.unitCount;
        if (squadNameText != null)
            squadNameText.text = loadout.name;
        UpdateHUD();
    }

    private void UpdateCommandVisuals()
    {
        if (followButton != null)
            SetButtonColor(followButton, activeCommand == SquadCommandSystem.SquadCommand.Follow);
        if (holdButton != null)
            SetButtonColor(holdButton, activeCommand == SquadCommandSystem.SquadCommand.HoldPosition);
        if (attackButton != null)
            SetButtonColor(attackButton, activeCommand == SquadCommandSystem.SquadCommand.AttackTarget);
    }

    private void SetButtonColor(Button button, bool active)
    {
        var img = button.GetComponent<Image>();
        if (img != null)
            img.color = active ? activeColor : inactiveColor;
    }

    private void RequestFormationChange()
    {
        OnChangeFormationRequest?.Invoke();
    }

    private void UpdateTimerText(float time)
    {
        if (timerText != null)
            timerText.text = BattleTimer.GetFormattedElapsedTime();
    }

    private void DisplayTimeWarning(float remaining)
    {
        if (timerText != null)
            timerText.color = timeWarningColor;
    }

    private void HandleBattleEnd(BattleManager.BattleState state)
    {
        if (panelGroup != null)
        {
            panelGroup.interactable = false;
            panelGroup.blocksRaycasts = false;
        }
    }
}
