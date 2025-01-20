using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [field: SerializeField] public JobInfoGenerator jobInfoGenerator { get; private set; }
    [field: SerializeField] public ThiefInfoGenerator thiefInfoGenerator { get; private set; }
    
    [SerializeField] private PlayerInfo playerInfo;
    
    [Header("Audio Refernces")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSoundEffectClip;
    public int CurrentMoney { get; private set; }
    public List<ThiefInfoPanelAssigner> ThiefInfoPanels { get; private set; } = new List<ThiefInfoPanelAssigner>();
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        AddMoney(1000);
        UIManager.Instance.FundsCanvas.SetActive(false);
    }

    private void Start()
    {
        EventManager.Instance.OnJobCompleted += HandleMoneyOnJobCompleted;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnJobCompleted -= HandleMoneyOnJobCompleted;
    }

    private void HandleMoneyOnJobCompleted(JobInfo jobInfo, ThiefData thiefData)
    {
        AddMoney(jobInfo.payoutAmount);
        
    }
    
    public void AddMoney(int amount)
    {
        CurrentMoney += amount;
        UIManager.Instance.HandleOnMoneyChanged(CurrentMoney);
        playerInfo.HandleOnMoneyChange(CurrentMoney);
        // EventManager.Instance.InvokeOnMoneyChanged(CurrentMoney);
    }

    public void WithdrawMoney(int amount)
    {
        CurrentMoney -= amount;
        UIManager.Instance.HandleOnMoneyChanged(CurrentMoney);
        EventManager.Instance.InvokeOnMoneyChanged(CurrentMoney);
    }

    public void PlayClickSoundEffect()
    {
        audioSource.PlayOneShot(clickSoundEffectClip);
    }
}
