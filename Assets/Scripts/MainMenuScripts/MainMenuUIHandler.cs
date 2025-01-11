using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIHandler : MonoBehaviour
{
    [Header("All Main menu button references")] 
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button audioSettingsButton;
    [SerializeField] private Button creditsButton;
    

    [Header("All UI Panel references")] 
    [SerializeField] private GameObject mainButtonsPanel;
    [SerializeField] private GameObject optionsButtonsPanel;
    [SerializeField] private GameObject audioButtonsPanel;
    [SerializeField] private GameObject creditsButtonsPanel;

    private void Start()
    {
        if (playButton != null)
        {
            //Scene transition
        }

        if (optionsButton != null)
        {
            optionsButton.onClick.AddListener(OpenOptionsPanel);
        }

        if (audioSettingsButton != null)
        {
            
        }

        if (creditsButton != null)
        {
            
        }
        
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitApplication);
        }
    }

    public void OpenOptionsPanel()
    {
        mainButtonsPanel?.SetActive(false);
        audioButtonsPanel?.SetActive(false);
        creditsButtonsPanel?.SetActive(false);
        
        optionsButtonsPanel?.SetActive(true);
    }

    public void OpenMainButtonsPanel()
    {
        optionsButtonsPanel?.SetActive(false);
        audioButtonsPanel?.SetActive(false);
        creditsButtonsPanel?.SetActive(false);
        
        mainButtonsPanel?.SetActive(true);
    }

    private void OpenAudioSettingsPanel()
    {
        optionsButtonsPanel?.SetActive(false);
        
        audioButtonsPanel?.SetActive(true);
    }

    private void OpenCreditsPanel()
    {
        optionsButtonsPanel?.SetActive(false);
        
        creditsButtonsPanel?.SetActive(true);
    }
    
    private void ExitApplication()
    {
        Application.Quit();
    }
}
