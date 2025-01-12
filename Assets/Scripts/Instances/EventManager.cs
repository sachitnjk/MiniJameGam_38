using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public Action<int> OnCharacterVisualSelected;
    public Action<CharacterPassiveBuff> OnCharacterBuffSelected;
    public Action<ThiefData> OnThiefHired;
    // public Action<int> OnMoneyChanged;
    
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

    #region InvokeFunctions

    public void InvokeOnCharacterVisualSelected(int spriteInt)
    {
        OnCharacterVisualSelected?.Invoke(spriteInt);
    }

    public void InvokeOnCharacterBuffSelected(CharacterPassiveBuff buff)
    {
        OnCharacterBuffSelected?.Invoke(buff);
    }

    public void InvokeOnThiefHired(ThiefData thief)
    {
        OnThiefHired?.Invoke(thief);
    }

    // public void InvokeOnMoneyChanged(int money)
    // {
    //     OnMoneyChanged?.Invoke(money);
    // }
    
    #endregion
    
}
