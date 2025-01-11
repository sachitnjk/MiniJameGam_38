using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterSelectionBuffPasser : MonoBehaviour
{
    [SerializeField] private CharacterPassiveBuff passiveBuff;

    public void SelectBuff()
    {
        EventManager.Instance.InvokeOnCharacterBuffSelected(passiveBuff);
    }
}
