using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThiefManageHandler : MonoBehaviour
{
    [SerializeField] private Button ManageButton;
    [SerializeField] private GameObject ThiefManagementPanel;
    
    UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.Instance;
        
        uiManager?.SetIsManagingThievesStatus(false);
        ThiefManagementPanel.SetActive(false);
        
        ManageButton?.onClick.AddListener(ThiefManagementPanelVisibility);
    }

    private void ThiefManagementPanelVisibility()
    {
        if (!uiManager.isManagingThieves)
        {
            ManageButton.gameObject.SetActive(false);
            
            ThiefManagementPanel.SetActive(true);
            uiManager.SetIsManagingThievesStatus(true);
        }
    }

    public void CloseThiefManagementPanel()
    {
        ThiefManagementPanel.SetActive(false);
    }
}
