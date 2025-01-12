using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OngoingJobsPanel : MonoBehaviour
{
    [SerializeField] private Button showHideButton;
    
    private Animator OngoingJobsPanelAnimator;
    private bool isVisible = false;

    private void Start()
    {
        showHideButton.onClick.AddListener(ShowHide);
        
        OngoingJobsPanelAnimator = gameObject.GetComponent<Animator>();
    }

    private void ShowHide()
    {
        if (!isVisible)
        {
            isVisible = true;
        }
        else
        {
            isVisible = false;
        }
        
        //Trigger animation with same bool
        OngoingJobsPanelAnimator?.SetBool("isVisible", isVisible);
    }

    // private void HandleOnJobAssigned()
    // {
    //     
    // }
}
