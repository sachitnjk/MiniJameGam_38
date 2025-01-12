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
    // private int currentMoney;

    private List<ThiefData> thievesUnderContract = new List<ThiefData>();

    private void Start()
    {
        foreach (ThiefData thief in startingThievesUnderContract)
        {
            AddThievesUnderContract(thief);
        }

        EventManager.Instance.OnCharacterVisualSelected += HandleOnCharacterVisualSelected;
        EventManager.Instance.OnCharacterBuffSelected += HandleOnCharacterBuffSelected;
        EventManager.Instance.OnMoneyChanged += HandleOnMoneyChange;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnCharacterVisualSelected -= HandleOnCharacterVisualSelected;
        EventManager.Instance.OnCharacterBuffSelected -= HandleOnCharacterBuffSelected;
        EventManager.Instance.OnMoneyChanged -= HandleOnMoneyChange;
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
    
    private void HandleOnMoneyChange(int value)
    {
        LevelChangeCheck(value);
    }
    
    #endregion

    #region Helpers

    private void LevelChangeCheck(int value)
    {
        if (value >= 400000)
        {
            currentLevel = 4;
        }
        else if (value >= 200000)
        {
            currentLevel = 3;
        }
        else if (value >= 100000)
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
                break;
            case 2:
                currentHatTier = 2;
                break;
            case 3:
                currentHatTier = 3;
                break;
            case 4:
                currentHatTier = 4;
                break;
            case 5:
                currentHatTier = 5;
                break;
            case 6:
                currentHatTier = 6;
                break;
        }
        
        // EventManager.Instance.InvokeOnHatChange(currentHatTier);
    }

    private void AddThievesUnderContract(ThiefData thiefData)
    {
        thievesUnderContract.Add(thiefData);
    }

    #endregion
    
}

[System.Serializable]
public class ThiefData
{
    public Sprite ThiefHeadAppearance;
    public string Name;
    public ThiefTiers Tier;
    public int cost;

    public ThiefData(Sprite thiefHeadAppearance, string name, ThiefTiers tier, int cost)
    {
        this.ThiefHeadAppearance = thiefHeadAppearance;
        this.Name = name;
        this.Tier = tier;
        this.cost = cost;
    }
}
