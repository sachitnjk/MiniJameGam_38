using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThiefInfoPanelAssigner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI tierText;
    [SerializeField] private Image headAppearance;
    [SerializeField] private Image bodyAppearance;
    
    [SerializeField] private Sprite gruntBody;
    [SerializeField] private Sprite MinionBody;
    [SerializeField] private Sprite BruteBody;
    [SerializeField] private Sprite ProfessionalBody;

    public void SetupUI(ThiefData thiefData)
    {
        headAppearance.sprite = thiefData.ThiefHeadAppearance;
        nameText.text = thiefData.Name;
        tierText.text = thiefData.Tier.ToString();
        SetTier(thiefData.Tier);
    }
    
    public void SetTier(ThiefTiers tier)
    {
        switch (tier)
        {
            case ThiefTiers.Grunt:
                bodyAppearance.sprite = gruntBody;
                break;
            case ThiefTiers.Minion:
                bodyAppearance.sprite = MinionBody;
                break;
            case ThiefTiers.Brute:
                bodyAppearance.sprite = BruteBody;
                break;
            case ThiefTiers.Professional:
                bodyAppearance.sprite = ProfessionalBody;
                break;
        }
    }
}
