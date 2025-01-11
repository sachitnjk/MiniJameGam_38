using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterSelectrionPanelController : MonoBehaviour
{
    [SerializeField] private GameObject characterVisiualSelectionPanel;
    [SerializeField] private GameObject characterBuffSelectionPanel;

    private void Start()
    {
        characterVisiualSelectionPanel.SetActive(true);
        characterBuffSelectionPanel.SetActive(false);
    }

    public void SwitchPanel(GameObject panel)
    {
        if (panel == characterVisiualSelectionPanel)
        {
            panel.SetActive(false);
            characterBuffSelectionPanel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
            characterVisiualSelectionPanel.SetActive(true);
        }
    }

    public void CloseAllPanels()
    {
        characterVisiualSelectionPanel.SetActive(false);
        characterBuffSelectionPanel.SetActive(false);
    }
}
