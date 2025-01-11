using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerInfo : MonoBehaviour
{
    [Header("Debug")] 
    [Range(1f, 4f)]
    [SerializeField] private int startingLevel;
    [SerializeField] private int startingMoney;
    [SerializeField] private int startingHatTier;
    // [SerializeField] private List<ThiefInfo> startingThievesUnderContract;
    
    [Header("References")]
    [SerializeField] private SpriteRenderer characterSpriteRenderer;
    
    private Sprite selectedCharacterVisual;
    private CharacterPassiveBuff selectedCharacterPassiveBuff;

    private int currentHatTier;
    
    private int currentLevel;
    private int currentMoney;

    // private List<ThiefInfo> thievesUnderContract = new List<ThiefInfo>();

    private void Start()
    {
        // thievesUnderContract?.AddRange(startThievesUnderContract);

        EventManager.Instance.OnCharacterVisualSelected += HandleOnCharacterVisualSelected;
        // EventManager.Instance?.OnMoneyChange += HandleOnMoneyChange;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnCharacterVisualSelected -= HandleOnCharacterVisualSelected;
        // EventManager.Instance?.OnMoneyChange += HandleOnMoneyChange;
    }

    private void HandleOnCharacterVisualSelected(Sprite characterSprite)
    {
        selectedCharacterVisual = characterSprite;
        characterSpriteRenderer.sprite = selectedCharacterVisual;
    }
    
    private void HandleOnMoneyChange(bool moneyAdded, int amount)
    {
        // if (currentMoney < startingMoney)
        // {
        //     //gameOver?
        // }

        if (moneyAdded)
        {
            currentMoney += amount;
        }
        else
        {
            currentMoney -= amount;
        }
        currentMoney = Mathf.Clamp(currentMoney, 0, 1000000);
        
        LevelChangeCheck();
    }

    private void LevelChangeCheck()
    {
        if (currentMoney >= 400000)
        {
            currentLevel = 4;
        }
        else if (currentMoney >= 200000)
        {
            currentLevel = 3;
        }
        else if (currentMoney >= 100000)
        {
            currentLevel = 2;
        }
        else
        {
            currentLevel = 1;
        }
        
        HatChangeCheck();
    }

    private void HatChangeCheck()
    {
        switch (currentLevel)
        {
            case 1:
                currentHatTier = 1;
                //EventManager.Instance?.InvokeOnHatChange;
                break;
            case 2:
                currentHatTier = 2;
                //EventManager.Instance?.InvokeOnHatChange;
                break;
            case 3:
                currentHatTier = 3;
                //EventManager.Instance?.InvokeOnHatChange;
                break;
            case 4:
                currentHatTier = 4;
                //EventManager.Instance?.InvokeOnHatChange;
                break;
            case 5:
                currentHatTier = 5;
                //EventManager.Instance?.InvokeOnHatChange;
                break;
            case 6:
                currentHatTier = 6;
                //EventManager.Instance?.InvokeOnHatChange;
                break;
        }
    }
}
