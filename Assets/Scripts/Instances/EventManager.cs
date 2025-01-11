using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public Action<Sprite> OnCharacterVisualSelected;
    public Action<CharacterPassiveBuff> OnCharacterBuffSelected;
    
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

    public void InvokeOnCharacterVisualSelected(Sprite sprite)
    {
        OnCharacterVisualSelected?.Invoke(sprite);
    }

    public void InvokeOnCharacterBuffSelected(CharacterPassiveBuff buff)
    {
        OnCharacterBuffSelected?.Invoke(buff);
    }

    #endregion
    
}
