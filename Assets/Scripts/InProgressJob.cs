using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InProgressJob : MonoBehaviour
{
    [SerializeField] private Image thiefHeadAppearance;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI Location;
    [SerializeField] private TextMeshProUGUI payoutAmoutText;
    [SerializeField] private TextMeshProUGUI tier;
    [SerializeField] private Slider jobProgress;
    
    private int payoutAmount;
    private JobInfo currentJobInfo;
    
    private int CalculateCompletionLimit(ThiefTiers tier)
    {
        int maxTime = 0;
        switch (tier)
        {
            case ThiefTiers.Grunt:
                maxTime = 16;
                break;
            case ThiefTiers.Minion:
                maxTime = 14;
                break;
            case ThiefTiers.Brute:
                maxTime = 12;
                break;
            case ThiefTiers.Professional:
                maxTime = 10;
                break;
        }
        
        int randmoziedTime = UnityEngine.Random.Range(5, maxTime);
        return randmoziedTime;
    }
    
    public void SetupInfo(ThiefData thiefData, JobInfo jobInfo)
    {
        currentJobInfo = jobInfo;
        
        thiefHeadAppearance.sprite = thiefData.ThiefHeadAppearance;
        name.text = thiefData.Name;
        Location.text = jobInfo.location;
        tier.text = thiefData.Tier.ToString();
        payoutAmount = jobInfo.payoutAmount;
        payoutAmoutText.text = payoutAmount.ToString();
        
        jobProgress.maxValue = CalculateCompletionLimit(thiefData.Tier);
        jobProgress.value = jobProgress.maxValue;

        StartCoroutine(DecrementJobProgress());
    }

    private IEnumerator DecrementJobProgress()
    {
        float completionLimit = jobProgress.maxValue;
        while (jobProgress.value > 0)
        {
            jobProgress.value -= Time.deltaTime;
            yield return null;
        }

        EventManager.Instance.InvokeOnJobCompleted(currentJobInfo);
        
        Destroy(gameObject);
    }
}
