using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] private int startingMoney = 500;
    [SerializeField] private TextMeshProUGUI moneyText;

    private int currentMoney;
    private void Start()
    {
        currentMoney = GameManager.Instance.CurrentMoney;
        
        GameManager.Instance.CurrentMoney = startingMoney;
    }

    public void AddMoney(int money)
    {
        currentMoney += money;
    }

    public void SpendMoney(int money)
    {
        currentMoney -= money;
    }
}
