using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// UI panel shown when the player interacts with a supply point.
/// Allows selecting a new squad during battle.
/// </summary>
public class SupplyPointInteractionUI : MonoBehaviour
{
    [Header("References")]
    public SelectSquadPanel selectSquadPanel;
    public Button cancelButton;
    public CanvasGroup canvasGroup;
    public float fadeDuration = 0.2f;

    private SupplyPointController currentPoint;

    private void Awake()
    {
        if (cancelButton != null)
            cancelButton.onClick.AddListener(Hide);
    }

    /// <summary>
    /// Opens the panel and populates squad options provided by the player profile.
    /// </summary>
    public void ShowOptions(SupplyPointController point)
    {
        currentPoint = point;

        if (selectSquadPanel != null)
        {
            var squads = PlayerProfileManager.Instance.GetAllLoadouts();
            selectSquadPanel.OnSquadSelected = OnSquadSelected;
            selectSquadPanel.Populate(squads, null);
        }

        gameObject.SetActive(true);
        StartCoroutine(FadeRoutine(1f));
    }

    public void Hide()
    {
        if (gameObject.activeSelf)
            StartCoroutine(FadeRoutine(0f));
    }

    private IEnumerator FadeRoutine(float target)
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                gameObject.SetActive(target > 0f);
                yield break;
            }
        }

        float start = canvasGroup.alpha;
        float time = 0f;
        if (target > 0f)
            gameObject.SetActive(true);
        while (time < fadeDuration)
        {
            time += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, target, time / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = target;
        if (target == 0f)
            gameObject.SetActive(false);
    }

    private void OnSquadSelected(SquadLoadout loadout)
    {
        if (loadout == null)
            return;

        if (currentPoint != null)
            currentPoint.ConfirmSquadChange(loadout);

        Hide();
    }
}
