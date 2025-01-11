using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStartingVisualPasser : MonoBehaviour
{ 
    [SerializeField] private int spriteInt;

    //Called through SelectButton in UI
    public void SelectCharacter()
    {
        EventManager.Instance.InvokeOnCharacterVisualSelected(spriteInt);
    }
}
