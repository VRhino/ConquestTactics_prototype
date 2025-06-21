using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the UI for creating a new hero.
/// </summary>
public class HeroCreationModal : MonoBehaviour
{
    [Header("Inputs")]
    public TMP_InputField nameInput;
    public TMP_Dropdown specializationDropdown;
    public TMP_InputField fuerzaInput;
    public TMP_InputField destrezaInput;
    public TMP_InputField armaduraInput;
    public TMP_InputField vitalidadInput;
    public Button confirmButton;
    public Button cancelButton;

    [Header("Config")]
    public int minStat = 1;
    public int maxStat = 10;

    public event Action<HeroData> OnHeroCreated;

    private void Awake()
    {
        if (confirmButton != null)
            confirmButton.onClick.AddListener(CreateHero);
        if (cancelButton != null)
            cancelButton.onClick.AddListener(() => gameObject.SetActive(false));
    }

    public void Open()
    {
        if (nameInput != null)
            nameInput.text = string.Empty;
    }

    private void CreateHero()
    {
        string heroName = nameInput != null ? nameInput.text : "Hero";
        int f = ParseStat(fuerzaInput);
        int d = ParseStat(destrezaInput);
        int a = ParseStat(armaduraInput);
        int v = ParseStat(vitalidadInput);

        var hero = new HeroData
        {
            heroId = Guid.NewGuid().ToString(),
            name = heroName,
            level = 1,
            fuerza = Mathf.Clamp(f, minStat, maxStat),
            destreza = Mathf.Clamp(d, minStat, maxStat),
            armadura = Mathf.Clamp(a, minStat, maxStat),
            vitalidad = Mathf.Clamp(v, minStat, maxStat),
            damageSlashing = f,
            damagePiercing = d,
            damageBlunt = Mathf.Max(1, a / 2),
            defenseSlashing = a / 2,
            defensePiercing = a / 2,
            defenseBlunt = a / 2,
            movementSpeed = 5f
        };

        PlayerProfileManager.Instance.AddHero(hero);
        PlayerProfileManager.Instance.SetActiveHero(hero);
        OnHeroCreated?.Invoke(hero);
        gameObject.SetActive(false);
    }

    private int ParseStat(TMP_InputField field)
    {
        if (field == null)
            return minStat;
        return int.TryParse(field.text, out int value) ? value : minStat;
    }
}
