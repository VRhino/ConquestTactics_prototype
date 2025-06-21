using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Main controller that coordinates the battle preparation UI.
/// </summary>
public class PreparationPanel : MonoBehaviour
{
    [Header("Sub Panels")]
    public SelectSquadPanel selectSquadPanel;
    public HeroViewerPanel heroViewerPanel;
    public PerkPreviewPanel perkPreviewPanel;

    [Header("Tab Buttons")]
    public Button squadsTabButton;
    public Button heroTabButton;
    public Button perksTabButton;

    [Header("Other UI")]
    public Button confirmButton;
    public GameObject panelRoot;

    private SquadLoadout selectedLoadout;

    public event System.Action OnPreparationComplete;

    private void Awake()
    {
        if (confirmButton != null)
            confirmButton.onClick.AddListener(OnConfirm);
        if (squadsTabButton != null)
            squadsTabButton.onClick.AddListener(() => ShowPanel(selectSquadPanel.gameObject));
        if (heroTabButton != null)
            heroTabButton.onClick.AddListener(() => ShowPanel(heroViewerPanel.gameObject));
        if (perksTabButton != null)
            perksTabButton.onClick.AddListener(() => ShowPanel(perkPreviewPanel.gameObject));
    }

    private void Start()
    {
        LoadData();
        ShowPanel(selectSquadPanel.gameObject);
    }

    private void LoadData()
    {
        var squads = PlayerProfileManager.GetUnlockedSquads();
        selectSquadPanel.Populate(squads);
        selectSquadPanel.OnLoadoutSelected += l => selectedLoadout = l;

        var hero = PlayerProfileManager.GetActiveCharacter();
        heroViewerPanel.LoadHero(hero);
        if (hero != null)
            perkPreviewPanel.Populate(hero.passivePerks);
    }

    private void ShowPanel(GameObject target)
    {
        selectSquadPanel.gameObject.SetActive(target == selectSquadPanel.gameObject);
        heroViewerPanel.gameObject.SetActive(target == heroViewerPanel.gameObject);
        perkPreviewPanel.gameObject.SetActive(target == perkPreviewPanel.gameObject);
    }

    private void OnConfirm()
    {
        if (selectedLoadout == null)
        {
            Debug.LogWarning("No squad loadout selected");
            return;
        }
        GameManager.SpawnSquad(selectedLoadout);
        if (panelRoot != null)
            panelRoot.SetActive(false);
        OnPreparationComplete?.Invoke();
    }
}
