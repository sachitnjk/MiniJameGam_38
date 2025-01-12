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
        removeJobButton.onClick.AddListener(CallRemove);
    }

    private void AssignJob()
    {
        List<ThiefData> eligibleThieves = new List<ThiefData>();

        foreach (ThiefData thief in GameManager.Instance.HiredThieves)
        {
            if (thief.Tier >= currentJobInfo.requiredTier)
            {
                eligibleThieves.Add(thief);
            }
        }
        
        int randomIndex = UnityEngine.Random.Range(0, eligibleThieves.Count);
        ThiefData AssignedThief = eligibleThieves[randomIndex];
        
        EventManager.Instance.InvokeOnThiefAssigned(AssignedThief, currentJobInfo);
        
        CallRemove();
    }
    
    private void CallRemove()
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
        this.location = Location;
        this.payoutAmount = PayoutAmount;
        this.requiredTier = RequiredTier;
    }
}
