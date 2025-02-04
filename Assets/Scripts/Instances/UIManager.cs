using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public bool isManagingThieves { get; private set; }
    public GameObject FundsCanvas;
    [SerializeField] private TextMeshProUGUI totalFundsText;
    [SerializeField] private TextMeshProUGUI levelText;
    
    [field: SerializeField] public NotificationHandler _notificationHandler { get; private set; }

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

    private void Start()
    {
        EventManager.Instance.OnCharacterBuffSelected += EnableMoneyCanvas;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnCharacterBuffSelected -= EnableMoneyCanvas;
    }

    // public void NotEnoughFundsMessage()
    // {
    //     if (notEnoughFundsText != null)
    //     {
    //         notEnoughFundsText.gameObject.GetComponent<Animator>()?.SetBool("isVisible", true);
    //         
    //         StartCoroutine(DisplayTimer());
    //     }
    // }

    public void UpdateLevelUI(int level)
    {
        levelText.text = level.ToString();
    }
    
    public void SetIsManagingThievesStatus(bool status)
    {
        isManagingThieves = status;
    }

    public void HandleOnMoneyChanged(int value)
    {
        totalFundsText.text = value.ToString();
    }

    private void EnableMoneyCanvas(CharacterPassiveBuff buff)
    {
        FundsCanvas.gameObject.SetActive(true);
    }
}
