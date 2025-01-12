using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    [Header("All Main menu button references")] 
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button creditsButton;
    

    [Header("All UI Panel references")] 
    [SerializeField] private GameObject mainButtonsPanel;
    [SerializeField] private GameObject creditsButtonsPanel;

    private void Start()
    {
        if (playButton != null)
        {
            //Scene transition
            playButton.onClick.AddListener(LoadNextScene);
        }

        if (creditsButton != null)
        {
            creditsButton.onClick.AddListener(OpenCreditsPanel);
        }
        
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitApplication);
        }
    }

    public void LoadNextScene()
    {
        // Get the current active scene's build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene in the build order
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    
    public void OpenOptionsPanel()
    {
        mainButtonsPanel?.SetActive(false);
        creditsButtonsPanel?.SetActive(false);
    }

    public void OpenMainButtonsPanel()
    {
        creditsButtonsPanel?.SetActive(false);
        
        mainButtonsPanel?.SetActive(true);
    }


    private void OpenCreditsPanel()
    {
        mainButtonsPanel?.SetActive(false);
        creditsButtonsPanel?.SetActive(true);
    }
    
    private void ExitApplication()
    {
        Application.Quit();
    }
}
