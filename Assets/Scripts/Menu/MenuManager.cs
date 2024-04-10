using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SettingsPanel;

    private void Start() {
        SettingsPanel.SetActive(false);
    }

    public void PlayButton() {
        SceneManager.LoadScene("Game");
    }

    public void SettingsButton() {
        SettingsPanel.SetActive(true);
    }

    public void CloseSettingsButton() {
        SettingsPanel.SetActive(false);
    }

    public void ExitButton() {
        Application.Quit();
    }
}
