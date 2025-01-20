using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThiefInfoPanelAssigner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI tierText;
    [SerializeField] private ThiefAppearanceHandler appearanceHandler;

    public JobInfo assignedJob { get; private set; }
    public ThiefData currentThiefData { get; private set; }

    public void AssignJob(JobInfo job)
    {
        assignedJob = job;
    }

    public void EndAssignedJob()
    {
        assignedJob = null;
    }

    public void InitializeThiefData(ThiefData thiefData)
    {
        assignedJob = null;
        currentThiefData = thiefData;
        
        SetupUI(currentThiefData);
    }
    
    public void SetupUI(ThiefData thiefData)
    {
        if (currentThiefData != null)
        {
            appearanceHandler.SetHeadSprite(thiefData.ThiefHeadAppearance);
            nameText.text = thiefData.Name;
            tierText.text = thiefData.Tier.ToString();
            appearanceHandler.SetTier(thiefData.Tier);
        }
    }
}
