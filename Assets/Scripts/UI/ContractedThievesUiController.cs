using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ContractedThievesUiController : MonoBehaviour
{
    [SerializeField] private Button showHideButton;
    [SerializeField] private GameObject contractedThievesPanel;

    private Animator contractedThievesPanelAnimator;
    public bool isVisible { get; private set; }

    private void Start()
    {
        isVisible = false;
        showHideButton.gameObject.SetActive(false);
        
        if (showHideButton != null)
        {
            showHideButton.onClick.AddListener(ShowHidePanel);
        }
        
        contractedThievesPanelAnimator = gameObject.GetComponent<Animator>();
        if (contractedThievesPanelAnimator != null)
        {
            contractedThievesPanelAnimator.SetBool("isVisible", isVisible);
        }

        EventManager.Instance.OnCharacterBuffSelected += EnableShowHide;
    }

    private void ShowHidePanel()
    {
        if (!isVisible)
        {
            isVisible = true;
            contractedThievesPanel?.SetActive(true);
        }
        else
        {
            isVisible = false;
        }
        
        if (contractedThievesPanelAnimator != null)
        {
            contractedThievesPanelAnimator.SetBool("isVisible", isVisible);
        }
    }

    private void EnableShowHide(CharacterPassiveBuff buff)
    {
        if (!showHideButton.gameObject.activeSelf)
        {
            showHideButton.gameObject.SetActive(true);
        }
    }
}
