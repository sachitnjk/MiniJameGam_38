using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public bool isManagingThieves { get; private set; }
    [SerializeField] private TextMeshProUGUI notEnoughFundsText;

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

    public void NotEnoughFundsMessage()
    {
        if (notEnoughFundsText != null && !notEnoughFundsText.gameObject.activeSelf)
        {
            notEnoughFundsText.gameObject.SetActive(true);
            
            StartCoroutine(DisplayTimer());
        }
    }
    
    private IEnumerator DisplayTimer()
    {
        yield return new WaitForSeconds(3f);

        if (notEnoughFundsText.gameObject.activeSelf)
        {
            notEnoughFundsText.gameObject.SetActive(false);
        }
    }
    
    public void SetIsManagingThievesStatus(bool status)
    {
        isManagingThieves = status;
    }
}
