using TMPro;
using UnityEngine;

[RequireComponent(typeof(UnitAIController))]
public class FSMDebugger : MonoBehaviour
{
    public bool debugFSM = true;
    public Vector3 offset = Vector3.up * 2f;

    private UnitAIController ai;
    private TextMeshPro textMesh;

    private void Awake()
    {
        ai = GetComponent<UnitAIController>();
        ai.OnStateChanged += HandleStateChanged;

        GameObject label = new GameObject("FSM State Text");
        label.transform.SetParent(transform);
        label.transform.localPosition = offset;
        textMesh = label.AddComponent<TextMeshPro>();
        textMesh.text = string.Empty;
        textMesh.gameObject.SetActive(debugFSM);
    }

    private void OnDestroy()
    {
        if (ai != null)
            ai.OnStateChanged -= HandleStateChanged;
    }

    private void HandleStateChanged(UnitAIController.AIState state)
    {
        if (textMesh == null) return;

        if (!debugFSM)
        {
            textMesh.gameObject.SetActive(false);
            return;
        }

        textMesh.gameObject.SetActive(true);
        textMesh.text = state.ToString();
        textMesh.color = GetColorForState(state);
    }

    private Color GetColorForState(UnitAIController.AIState state)
    {
        return state switch
        {
            UnitAIController.AIState.Idle => Color.gray,
            UnitAIController.AIState.EngagingEnemy => new Color(1f, 0.5f, 0f),
            UnitAIController.AIState.Attacking => Color.red,
            _ => Color.white
        };
    }
}
