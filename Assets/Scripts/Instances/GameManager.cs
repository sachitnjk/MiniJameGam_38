using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public MoneyHandler moneyHandler;
    [field: SerializeField] public JobInfoGenerator jobInfoGenerator { get; private set; }
    public int CurrentMoney { get; set; }

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
    }
}
