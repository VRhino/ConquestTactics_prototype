using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Simple local login manager used during development.
/// Generates a mock player profile and loads the next scene.
/// </summary>
public class LoginManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField playerNameInput;
    public Button loginButton;
    public string nextScene = "Lobby";

    private void Awake()
    {
        if (loginButton != null)
            loginButton.onClick.AddListener(OnLoginButtonPressed);
    }

    private void Update()
    {
        if (playerNameInput == null)
            return;
        bool ctrl = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        if (ctrl && Input.GetKeyDown(KeyCode.L) && string.IsNullOrEmpty(playerNameInput.text))
        {
            playerNameInput.text = $"Guest_{UnityEngine.Random.Range(1000, 9999)}";
            OnLoginButtonPressed();
        }
    }

    /// <summary>
    /// Called by the login button. Validates the input and loads the profile.
    /// </summary>
    public void OnLoginButtonPressed()
    {
        if (playerNameInput == null)
            return;

        string name = playerNameInput.text.Trim();
        if (name.Length < 3)
        {
            Debug.LogWarning("Nombre de jugador inválido");
            return;
        }

        if (loginButton != null)
            loginButton.interactable = false;

        PlayerProfileManager.Instance.LoadMockProfile(name);
        SceneLoader.LoadScene(nextScene);
    }

    /// <summary>
    /// Creates a simple mock profile data instance for future extensions.
    /// </summary>
    private PlayerProfileData CreateMockProfile(string name)
    {
        return new PlayerProfileData
        {
            playerId = Guid.NewGuid().ToString(),
            playerName = name,
            unlockedSquads = new List<SquadLoadout>(),
            perksPasivos = new List<PerkData>()
        };
    }
}
