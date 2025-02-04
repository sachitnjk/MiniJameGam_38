using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThiefHirer : MonoBehaviour
{
    public ThiefData currentHireThiefInfo;
    
    [SerializeField] private ThiefAppearanceHandler appearanceHandler;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI tierText;
    [SerializeField] private TextMeshProUGUI costText;
    // [SerializeField] private TextMeshProUGUI expText;

    [SerializeField] private Button HireButton;
    
    private void Start()
    {
        HireButton?.onClick.AddListener(HireThief);
    }

    private void HireThief()
    {
        if (GameManager.Instance.CurrentMoney >= currentHireThiefInfo.cost)
        {
            GameManager.Instance.WithdrawMoney(currentHireThiefInfo.cost);
            EventManager.Instance?.InvokeOnThiefHired(currentHireThiefInfo);
        }
        else
        {
            UIManager.Instance?._notificationHandler?.AssignAndTriggerNotification(NotificationType.Broke);
            // UIManager.Instance?.NotEnoughFundsMessage();
        }
    }

    public void SetThiefData(ThiefData newThiefInfo)
    {
        currentHireThiefInfo = newThiefInfo;
        
        if (currentHireThiefInfo != null)
        {
            appearanceHandler.SetHeadSprite(newThiefInfo.ThiefHeadAppearance);
            nameText.text = newThiefInfo.Name;
            tierText.text = newThiefInfo.Tier.ToString();
            appearanceHandler.SetTier(newThiefInfo.Tier);
            costText.text = newThiefInfo.cost.ToString();
        }
    }
}

