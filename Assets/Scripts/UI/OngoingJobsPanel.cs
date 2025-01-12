using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OngoingJobsPanel : MonoBehaviour
{
    [SerializeField] private Button showHideButton;
    [SerializeField] private RectTransform OngoingJobPrefab;
    [SerializeField] private Transform prefabParent;
    
    private List<GameObject> ongoingJobs = new List<GameObject>();
    
    private Animator OngoingJobsPanelAnimator;
    private bool isVisible = false;

    private void Start()
    {
        showHideButton.onClick.AddListener(ShowHide);
        
        OngoingJobsPanelAnimator = gameObject.GetComponent<Animator>();

        EventManager.Instance.OnThiefAssigned += HandleOnJobAssigned;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnThiefAssigned -= HandleOnJobAssigned;
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

    private void HandleOnJobAssigned(ThiefData thiefData, JobInfo jobInfo)
    {
        GameObject newOngoingJob = Instantiate(OngoingJobPrefab.gameObject, prefabParent);
        InProgressJob job = newOngoingJob.GetComponent<InProgressJob>();
        
        job?.SetupInfo(thiefData, jobInfo);
        
        ongoingJobs.Add(newOngoingJob);
    }
}
