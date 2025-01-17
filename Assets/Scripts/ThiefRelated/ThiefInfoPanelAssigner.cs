using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThiefInfoPanelAssigner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI tierText;
    [SerializeField] private ThiefAppearanceHandler appearanceHandler;

    public void SetupUI(ThiefData thiefData)
    {
        appearanceHandler.SetHeadSprite(thiefData.ThiefHeadAppearance);
        nameText.text = thiefData.Name;
        tierText.text = thiefData.Tier.ToString();
        appearanceHandler.SetTier(thiefData.Tier);
    }
}
