using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShowHideController : MonoBehaviour
{
    [Header("Panel script refs")]
    [SerializeField] private OngoingJobsPanel ongoingJobsPanel;
    [SerializeField] private ContractedThievesUiController contractedThievesUIController;
    
    [Header("UI refs")]
    [SerializeField] private GameObject OJPanel;
    [SerializeField] private GameObject HTPanel;
    [SerializeField] private Button showHideButton_OJ;
    [SerializeField] private Button showHideButton_HT;

    private void Start()
    {
        OJPanel?.SetActive(false);
        HTPanel?.SetActive(false);
        
        ongoingJobsPanel?.TriggerPanelHide();
        contractedThievesUIController?.TriggerPanelHide();
        
        if (showHideButton_OJ && showHideButton_HT)
        {
            showHideButton_OJ.onClick.AddListener(ShowOJPanel);
            showHideButton_HT.onClick.AddListener(ShowCTPanel);
        }

        EventManager.Instance.OnCharacterBuffSelected += HandleOnBuffSelected;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnCharacterBuffSelected -= HandleOnBuffSelected;
    }

    private void ShowOJPanel()
    {
        contractedThievesUIController?.TriggerPanelHide();
        ongoingJobsPanel?.TriggerPanelShow();
    }

    private void ShowCTPanel()
    {
        ongoingJobsPanel?.TriggerPanelHide();
        contractedThievesUIController?.TriggerPanelShow();
    }

    private void HandleOnBuffSelected(CharacterPassiveBuff buff)
    {
        OJPanel?.SetActive(true);
        HTPanel?.SetActive(true);
    }
}
