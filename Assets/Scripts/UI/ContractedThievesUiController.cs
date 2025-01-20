using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ContractedThievesUiController : MonoBehaviour
{
    [SerializeField] private Button showHideButton;
    [SerializeField] private GameObject contractedThievesPanel;
    [SerializeField] private RectTransform ThiefInfoPrefab;
    [SerializeField] private Transform thiefDataParent;
    
    private Animator contractedThievesPanelAnimator;
    public bool isVisible { get; private set; }

    private void Start()
    {
        // showHideButton.gameObject.SetActive(false);
        
        // if (showHideButton != null)
        // {
        //     showHideButton.onClick.AddListener(ShowHidePanel);
        // }
        //
        // if (contractedThievesPanelAnimator != null)
        // {
        //     contractedThievesPanelAnimator.SetBool("isVisible", isVisible);
        // }
        // isVisible = false;
        
        contractedThievesPanelAnimator = gameObject.GetComponent<Animator>();

        EventManager.Instance.OnCharacterBuffSelected += EnableShowHide;
        EventManager.Instance.OnThiefHired += HandleOnThiefHired;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnCharacterBuffSelected -= EnableShowHide;
        EventManager.Instance.OnThiefHired -= HandleOnThiefHired;
    }

    private void ShowHidePanel()
    {
        UIManager uiManager = UIManager.Instance;
        
        if (!isVisible && !uiManager.isManagingThieves)
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

    private void HandleOnThiefHired(ThiefData thiefData)
    {
        GameObject newThiefDataUI = Instantiate(ThiefInfoPrefab.gameObject, thiefDataParent);
        ThiefInfoPanelAssigner instantiatedThiefPanelAssigner = newThiefDataUI.GetComponent<ThiefInfoPanelAssigner>();

        instantiatedThiefPanelAssigner?.InitializeThiefData(thiefData);
        // instantiatedThiefPanelAssigner?.SetupUI(thiefData);
        
        GameManager.Instance.ThiefInfoPanels.Add(instantiatedThiefPanelAssigner);
    }
    
    public void TriggerPanelShow()
    {
        if (contractedThievesPanelAnimator.GetBool("isVisible"))
        {
            TriggerPanelHide();
        }
        else
        {
            contractedThievesPanelAnimator?.SetBool("isVisible", true);
        }
    }
    
    public void TriggerPanelHide()
    {
        contractedThievesPanelAnimator?.SetBool("isVisible", false);
    }
}
