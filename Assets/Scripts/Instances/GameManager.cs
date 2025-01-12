using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [field: SerializeField] public JobInfoGenerator jobInfoGenerator { get; private set; }
    public int CurrentMoney { get; private set; }

    public List<ThiefData> HiredThieves { get; private set; } = new List<ThiefData>();
    
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
        
        AddMoney(500);
        UIManager.Instance.FundsCanvas.SetActive(false);
    }

    private void Start()
    {
        EventManager.Instance.OnThiefHired += HandleOnThiefHired;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnThiefHired -= HandleOnThiefHired;
    }

    public void AddMoney(int amount)
    {
        CurrentMoney += amount;
        UIManager.Instance.HandleOnMoneyChanged(CurrentMoney);
    }

    public void WithdrawMoney(int amount)
    {
        CurrentMoney -= amount;
        UIManager.Instance.HandleOnMoneyChanged(CurrentMoney);
    }

    private void HandleOnThiefHired(ThiefData thiefData)
    {
        
    }
}
