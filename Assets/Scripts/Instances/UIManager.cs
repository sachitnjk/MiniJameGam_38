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
    [SerializeField] private TextMeshProUGUI notEnoughFundsText;
    [SerializeField] private TextMeshProUGUI totalFundsText;

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

    public void NotEnoughFundsMessage()
    {
        if (notEnoughFundsText != null)
        {
            notEnoughFundsText.gameObject.GetComponent<Animator>()?.SetBool("isVisible", true);
            // notEnoughFundsText.gameObject.SetActive(true);
            
            StartCoroutine(DisplayTimer());
        }
    }
    
    private IEnumerator DisplayTimer()
    {
        yield return new WaitForSeconds(3f);

        if (notEnoughFundsText.gameObject.activeSelf)
        {
            notEnoughFundsText.gameObject.GetComponent<Animator>()?.SetBool("isVisible", false);
            // notEnoughFundsText.gameObject.SetActive(false);
        }
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
