using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThiefInfoGenerator : MonoBehaviour
{
    [SerializeField] private ThiefAppearanceHeadSO _thiefAppearanceHeadSO;
    [SerializeField] private ThiefNameSO _thiefNameSO;
    [SerializeField] private RectTransform thiefInfoPrefab;
    [SerializeField] private Transform thiefInfoParent;
    
    private List<ThiefData> generatedHires = new List<ThiefData>();
    private List<GameObject> GeneratedThiefGOList = new List<GameObject>();
    
    private int maxThievesToGenerate = 15;

    private void Start()
    {
        EventManager.Instance.OnThiefHired += HandleOnThiefHired;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnThiefHired -= HandleOnThiefHired;
    }

    public void GenerateThiefHireInfo()
    {
        generatedHires.Clear();
        
        int generatedThieves = Random.Range(5, maxThievesToGenerate);
        // int generatedThieves = 4;
        for (int i = 0; i < generatedThieves; i++)
        {
            ThiefTiers randomlyPickedTier = GetRandomThiefTier();
            int TierWiseCost = SetCostAccordingToThiefTier(randomlyPickedTier);
            
            ThiefData newThiefData = new ThiefData(
                PickRandomAppearanceHead(), PickRandomName(), randomlyPickedTier, TierWiseCost);
            
            generatedHires.Add(newThiefData);
            
            AddNewThiefToUI(newThiefData);
        }
    }

    private Sprite PickRandomAppearanceHead()
    {
        if (_thiefAppearanceHeadSO != null)
        {
            int randomIndex = Random.Range(0, _thiefAppearanceHeadSO.headAppearance.Count);
            Sprite randomSprite = _thiefAppearanceHeadSO.headAppearance[randomIndex];
            
            return randomSprite;
        }
        return null;
    }

    private String PickRandomName()
    {
        if (_thiefNameSO != null)
        {
            int randomIndex = Random.Range(0, _thiefNameSO.names.Count);
            String randomName = _thiefNameSO.names[randomIndex];
            
            return randomName;
        }

        return null;
    }
    
    private ThiefTiers GetRandomThiefTier()
    {
        ThiefTiers thiefTier;
        // Get all the values of the ThiefTiers enum
        ThiefTiers[] values = (ThiefTiers[])System.Enum.GetValues(typeof(ThiefTiers));
        
        // Generate a random index
        int randomIndex = Random.Range(1, values.Length);
        
        // Assign a random value to the thiefTier variable
        thiefTier = values[randomIndex];
        return thiefTier;
    }

    private int SetCostAccordingToThiefTier(ThiefTiers thiefTier)
    {
        int cost = 0;
        switch (thiefTier)
        {
            case ThiefTiers.None:
                cost = 0;
                break;
            case ThiefTiers.Grunt:
                cost = Random.Range(100, 200);
                break;
            case ThiefTiers.Minion:
                cost = Random.Range(200, 500);
                break;
            case ThiefTiers.Brute:
                cost = Random.Range(400, 800);
                break;
            case ThiefTiers.Professional:
                cost = Random.Range(800, 1500);
                break;
        }
        
        return cost;
    }

    private void AddNewThiefToUI(ThiefData newThiefData)
    {
        GameObject newThiefDataUI = Instantiate(thiefInfoPrefab.gameObject, thiefInfoParent);
        
        ThiefHirer newThiefHirerInfo = newThiefDataUI.GetComponent<ThiefHirer>();
        if (newThiefHirerInfo != null)
        {
            newThiefHirerInfo.SetThiefData(newThiefData);
            GeneratedThiefGOList.Add(newThiefHirerInfo.gameObject);
        }
    }

    private void HandleOnThiefHired(ThiefData newThiefData)
    {
        foreach (GameObject newThiefGO in GeneratedThiefGOList)
        {
            ThiefHirer thiefHirerComponent = newThiefGO.GetComponent<ThiefHirer>();
            if (thiefHirerComponent != null && thiefHirerComponent.currentHireThiefInfo == newThiefData)
            {
                GameManager.Instance.AddToHiredThiefList(newThiefData);
                GeneratedThiefGOList.Remove(newThiefGO);
                Destroy(newThiefGO);
                break;
            }
        }
    }
}
