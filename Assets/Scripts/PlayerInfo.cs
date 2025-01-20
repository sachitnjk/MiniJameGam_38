using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    
    [SerializeField] private GameObject hat_1;
    [SerializeField] private GameObject hat_2;
    [SerializeField] private GameObject hat_3;
    [SerializeField] private GameObject hat_4;
    [SerializeField] private GameObject hat_5;
    [SerializeField] private GameObject hat_6;

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
    
    public void HandleOnMoneyChange(int value)
    {
        LevelChangeCheck(value);
    }
    
    #endregion

    #region Helpers

    private void LevelChangeCheck(int value)
    {
        if (value > 35000)
        {
            LoadNextScene();
        }
        
        if (value >= 30000)
        {
            currentLevel = 6;
        }
        else if (value >= 25000)
        {
            currentLevel = 5;
        }
        else if (value >= 20000)
        {
            currentLevel = 4;
        }
        else if (value >= 10000)
        {
            currentLevel = 3;
        }
        else if(value >= 2000)
        {
            currentLevel = 2;
        }
        else
        {
            currentLevel = 1;
        }
        
        UIManager.Instance.UpdateLevelUI(currentLevel);
        
        HatChangeCheck();
    }

    public void LoadNextScene()
    {
        // Get the current active scene's build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene in the build order
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    
    private void HatChangeCheck()
    {
        hat_1.gameObject.SetActive(false);
        hat_2.gameObject.SetActive(false);
        hat_3.gameObject.SetActive(false);
        hat_4.gameObject.SetActive(false);
        hat_5.gameObject.SetActive(false);
        hat_6.gameObject.SetActive(false);
        
        
        switch (currentLevel)
        {
            case 1:
                currentHatTier = 1;
                hat_1.gameObject.SetActive(true);
                break;
            case 2:
                currentHatTier = 2;
                hat_2.gameObject.SetActive(true);
                break;
            case 3:
                currentHatTier = 3;
                hat_3.gameObject.SetActive(true);
                break;
            case 4:
                currentHatTier = 4;
                hat_4.gameObject.SetActive(true);
                break;
            case 5:
                currentHatTier = 5;
                hat_5.gameObject.SetActive(true);
                break;
            case 6:
                currentHatTier = 6;
                hat_6.gameObject.SetActive(true);
                // GameManager.Instance.TriggerEnd();
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
