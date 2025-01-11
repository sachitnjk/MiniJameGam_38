using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JobInfoAssigner : MonoBehaviour
{
    private JobInfo currentJobInfo;

    [SerializeField] private Image locationSprite;
    [SerializeField] private TextMeshProUGUI locationText;
    [SerializeField] private TextMeshProUGUI maxThievesText;
    [SerializeField] private TextMeshProUGUI requiredTierText;
    
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
        maxThievesText.text = currentJobInfo.maxThieves.ToString();
        requiredTierText.text = currentJobInfo.requiredTier.ToString();
    }
    
    
}

[System.Serializable]
public class JobInfo
{
    public Sprite locationSprite;
    public string location;
    public int maxThieves;
    public ThiefTiers requiredTier;
    
    public JobInfo(Sprite locationSprite, string Location, int MaxThieves, ThiefTiers RequiredTier)
    {
        this.location = Location;
        this.maxThieves = MaxThieves;
        this.requiredTier = RequiredTier;
    }
}
