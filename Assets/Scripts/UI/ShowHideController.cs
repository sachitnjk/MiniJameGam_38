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
    
    [Header("Button refs")]
    [SerializeField] private Button showHideButton_OJ;
    [SerializeField] private Button showHideButton_CT;

    private void Start()
    {
        if (showHideButton_OJ && showHideButton_CT)
        {
            showHideButton_OJ.onClick.AddListener(ShowOJPanel);
            showHideButton_CT.onClick.AddListener(ShowCTPanel);
        }
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
}
