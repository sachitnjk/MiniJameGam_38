using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ThiefManageHandler : MonoBehaviour
{
    [SerializeField] private Button ManageButton;
    [SerializeField] private GameObject ThiefManagementPanel;
    [SerializeField] private Button JobsTab;
    [SerializeField] private Button HiringTab;
    [SerializeField] private GameObject HiringPanel;
    [SerializeField] private GameObject JobsPanel;
    
    UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.Instance;
        
        uiManager?.SetIsManagingThievesStatus(false);
        ManageButton.gameObject.SetActive(false);
        ThiefManagementPanel.SetActive(false);
        
        ManageButton?.onClick.AddListener(ThiefManagementPanelVisibility);
        JobsTab?.onClick.AddListener(SwitchToJobTab);
        HiringTab?.onClick.AddListener(SwitchToHiringTab);

        EventManager.Instance.OnCharacterBuffSelected += HandleOnBuffSelected;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnCharacterBuffSelected -= HandleOnBuffSelected;
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
        uiManager.SetIsManagingThievesStatus(false);
        
        ManageButton.gameObject.SetActive(true);
    }

    private void SwitchToJobTab()
    {
        HiringPanel.SetActive(false);
        JobsPanel.SetActive(true);
    }

    private void SwitchToHiringTab()
    {
        JobsPanel.SetActive(false);
        HiringPanel.SetActive(true);
    }

    private void HandleOnBuffSelected(CharacterPassiveBuff buff)
    {
        ManageButton.gameObject.SetActive(true);
    }
    
}
