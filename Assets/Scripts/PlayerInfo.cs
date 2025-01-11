using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerInfo : MonoBehaviour
{
    [Header("Debug")] 
    [Range(1f, 4f)]
    [SerializeField] private int startingLevel;
    [SerializeField] private int startingMoney;
    [SerializeField] private int startingHatTier;
    [SerializeField] private List<ThiefData> startingThievesUnderContract = new List<ThiefData>();
    
    [Header("References")]
    [SerializeField] private SpriteRenderer characterSpriteRenderer;
    [SerializeField] private List<GameObject> allLevelHats = new List<GameObject>();

    [SerializeField] private GameObject TigerBossVisual;
    [SerializeField] private GameObject BearBossVisual;
    [SerializeField] private GameObject XBossVisual;
    [SerializeField] private GameObject YBossVisual;
    
    private Sprite selectedCharacterVisual;
    private CharacterPassiveBuff selectedCharacterPassiveBuff;

    private int currentHatTier;
    
    private int currentLevel;
    private int currentMoney;

    private List<ThiefData> thievesUnderContract = new List<ThiefData>();

    private void Start()
    {
        foreach (ThiefData thief in startingThievesUnderContract)
        {
            AddThievesUnderContract(thief);
        }

        EventManager.Instance.OnCharacterVisualSelected += HandleOnCharacterVisualSelected;
        EventManager.Instance.OnCharacterBuffSelected += HandleOnCharacterBuffSelected;
        // EventManager.Instance?.OnMoneyChange += HandleOnMoneyChange;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnCharacterVisualSelected -= HandleOnCharacterVisualSelected;
        EventManager.Instance.OnCharacterBuffSelected -= HandleOnCharacterBuffSelected;
        // EventManager.Instance?.OnMoneyChange += HandleOnMoneyChange;
    }

    #region Event Handlers

    private void HandleOnCharacterVisualSelected(int characterSpriteInt)
    {
        TigerBossVisual?.SetActive(false);
        BearBossVisual?.SetActive(false);
        XBossVisual?.SetActive(false);
        YBossVisual?.SetActive(false);
        
        switch (characterSpriteInt)
        {
            case 1:
                TigerBossVisual?.SetActive(true);
                break;
            case 2:
                BearBossVisual?.SetActive(true);
                break;
            case 3:
                XBossVisual?.SetActive(true);
                break;
            case 4:
                YBossVisual?.SetActive(true);
                break;
            default:
                BearBossVisual?.SetActive(false);
                break;
        }
    }

    private void HandleOnCharacterBuffSelected(CharacterPassiveBuff characterPassiveBuff)
    {
        selectedCharacterPassiveBuff = characterPassiveBuff;
    }
    
    private void HandleOnMoneyChange(bool moneyAdded, int amount)
    {
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
    
    #endregion

    #region Helpers

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

    private void AddThievesUnderContract(ThiefData thiefData)
    {
        thievesUnderContract.Add(thiefData);
    }

    #endregion
    
}

[System.Serializable]
public struct ThiefData
{
    public Sprite ThiefHeadAppearance;
    public string Name;
    public ThiefTiers Tier;
    public int Experience;
    public int Loyalty;
}
