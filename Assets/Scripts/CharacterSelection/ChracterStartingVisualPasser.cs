using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStartingVisualPasser : MonoBehaviour
{ 
    [SerializeField] private GameObject characterSelectionGO;

    private Sprite characterSprite;

    private void Start()
    {
        characterSprite = characterSelectionGO?.GetComponent<Image>().sprite;
    }

    //Called through SelectButton in UI
    public void SelectCharacter()
    {
        EventManager.Instance.InvokeOnCharacterVisualSelected(characterSprite);
    }
}
