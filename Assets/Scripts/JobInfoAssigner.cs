using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JobInfoAssigner : MonoBehaviour
{
    public JobInfo currentJobInfo { get; private set; }

    [SerializeField] private Image locationSprite;
    [SerializeField] private TextMeshProUGUI locationText;
    [SerializeField] private TextMeshProUGUI maxThievesText;
    [SerializeField] private TextMeshProUGUI requiredTierText;
    
    [SerializeField] private Button assignJobButton;
    [SerializeField] private Button removeJobButton;
    
    private void Start()
    {
        assignJobButton.onClick.AddListener(AssignJob);
        removeJobButton.onClick.AddListener(CallRemoveJob);

        EventManager.Instance.OnJobCompleted += HandleOnJobCompleted;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnJobCompleted -= HandleOnJobCompleted;
    }

    private void AssignJob()
    {
        
        foreach (ThiefInfoPanelAssigner thiefInfoPanel in GameManager.Instance.ThiefInfoPanels)
        {
            if (thiefInfoPanel.currentThiefData.Tier >= currentJobInfo.requiredTier && thiefInfoPanel.assignedJob == null)
            {
                thiefInfoPanel.AssignJob(currentJobInfo);
                
                EventManager.Instance.InvokeOnThiefAssigned(thiefInfoPanel.currentThiefData, currentJobInfo);
                CallRemoveJob();
                break;
            }
        }
    }
    
    private void CallRemoveJob()
    {
        GameManager.Instance.jobInfoGenerator.RemoveJob(this);
    }
    
    public void SetJobInfo(JobInfo jobInfo)
    {
        currentJobInfo = jobInfo;
        
        if (currentJobInfo != null)
        {
            SetUIElements();
        }
    }

    private void SetUIElements()
    {
        locationSprite.sprite = currentJobInfo.locationSprite;
        locationText.text = currentJobInfo.location;
        maxThievesText.text = currentJobInfo.payoutAmount.ToString();
        requiredTierText.text = currentJobInfo.requiredTier.ToString();
    }

    public void HandleOnJobCompleted(JobInfo jobInfo, ThiefData thiefData)
    {
        foreach (ThiefInfoPanelAssigner thiefInfoPanel in GameManager.Instance.ThiefInfoPanels)
        {
            if (thiefInfoPanel.assignedJob == jobInfo && thiefInfoPanel.currentThiefData == thiefData)
            {
                thiefInfoPanel.EndAssignedJob();
            }
        }
    }
    
}

[System.Serializable]
public class JobInfo
{
    public Sprite locationSprite;
    public string location;
    public int payoutAmount;
    public ThiefTiers requiredTier;
    
    public JobInfo(Sprite locationSprite, string Location, int PayoutAmount, ThiefTiers RequiredTier)
    {
        this.locationSprite = locationSprite;
        this.location = Location;
        this.payoutAmount = PayoutAmount;
        this.requiredTier = RequiredTier;
    }
}
