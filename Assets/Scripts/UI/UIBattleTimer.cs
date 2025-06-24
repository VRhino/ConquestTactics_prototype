using TMPro;
using UnityEngine;

/// <summary>
/// Displays the current battle time on a TextMeshProUGUI element.
/// </summary>
public class UIBattleTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Color normalColor = Color.white;
    public Color warningColor = Color.red;

    private void OnEnable()
    {
        if (BattleTimer.Instance != null)
        {
            BattleTimer.Instance.OnTimerTick += UpdateDisplay;
            BattleTimer.Instance.OnTimeWarning += OnWarning;
            UpdateDisplay(BattleTimer.Instance.GetElapsedTime());
        }
    }

    private void OnDisable()
    {
        if (BattleTimer.Instance != null)
        {
            BattleTimer.Instance.OnTimerTick -= UpdateDisplay;
            BattleTimer.Instance.OnTimeWarning -= OnWarning;
        }
    }

    private void UpdateDisplay(float time)
    {
        if (timerText != null && BattleTimer.Instance != null)
            timerText.text = BattleTimer.Instance.GetFormattedTime();
    }

    private void OnWarning(float remaining)
    {
        if (timerText != null)
            timerText.color = warningColor;
    }
}
