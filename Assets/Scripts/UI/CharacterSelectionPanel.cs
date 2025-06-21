using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Allows the player to view, create and select one of their heroes.
/// Works entirely on the local PlayerProfileManager.
/// </summary>
public class CharacterSelectionPanel : MonoBehaviour
{
    [Header("UI References")]
    public HeroCardUI heroCardPrefab;
    public Transform heroListContainer;
    public Button createHeroButton;
    public HeroCreationModal creationModal;
    [Tooltip("Scene loaded after selecting a hero")]
    public string nextScene = "Lobby";

    private readonly List<HeroCardUI> createdCards = new();
    private List<HeroData> heroes;

    private void Start()
    {
        Populate();
    }

    /// <summary>
    /// Fills the list with the player's heroes and applies startup behaviour.
    /// </summary>
    public void Populate()
    {
        Clear();
        heroes = PlayerProfileManager.Instance.GetAllHeroes();
        foreach (var hero in heroes)
        {
            var card = Instantiate(heroCardPrefab, heroListContainer);
            card.Setup(hero);
            card.OnSelected += UseHero;
            createdCards.Add(card);
        }

        if (createHeroButton != null)
            createHeroButton.onClick.AddListener(OpenCreation);

        if (heroes.Count == 0)
        {
            // Force hero creation when none exist
            OpenCreation();
        }
        else if (heroes.Count == 1)
        {
            // Auto select the only hero
            PlayerProfileManager.Instance.SetActiveHero(heroes[0]);
        }
    }

    private void Clear()
    {
        foreach (var c in createdCards)
            Destroy(c.gameObject);
        createdCards.Clear();
    }

    private void OpenCreation()
    {
        if (creationModal == null)
            return;
        creationModal.gameObject.SetActive(true);
        creationModal.OnHeroCreated += OnHeroCreated;
        creationModal.Open();
    }

    private void OnHeroCreated(HeroData hero)
    {
        creationModal.OnHeroCreated -= OnHeroCreated;
        Populate();
    }

    private void UseHero(HeroData hero)
    {
        PlayerProfileManager.Instance.SetActiveHero(hero);
        SceneLoader.LoadScene(nextScene);
    }
}
