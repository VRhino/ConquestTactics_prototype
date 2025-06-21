using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Simple UI component representing a hero inside the character selection list.
/// </summary>
public class HeroCardUI : MonoBehaviour
{
    public Image icon;
    public Text nameText;
    public Text levelText;
    public Text statsText;
    public Button selectButton;

    private HeroData boundHero;

    public System.Action<HeroData> OnSelected;

    /// <summary>
    /// Initializes the card with the given hero data.
    /// </summary>
    public void Setup(HeroData data)
    {
        boundHero = data;
        if (icon != null)
            icon.sprite = data.icon;
        if (nameText != null)
            nameText.text = data.name;
        if (levelText != null)
            levelText.text = $"Nivel {data.level}";
        if (statsText != null)
            statsText.text = $"FUE {data.fuerza}  DES {data.destreza}  ARM {data.armadura}  VIT {data.vitalidad}";

        if (selectButton != null)
        {
            selectButton.onClick.RemoveAllListeners();
            selectButton.onClick.AddListener(() => OnSelected?.Invoke(boundHero));
        }
    }
}
