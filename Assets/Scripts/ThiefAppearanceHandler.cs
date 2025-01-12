using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThiefAppearanceHandler : MonoBehaviour
{
    [SerializeField] private Image headAppearance;
    [SerializeField] private Image bodyAppearance;
    
    [SerializeField] private Sprite gruntBody;
    [SerializeField] private Sprite MinionBody;
    [SerializeField] private Sprite BruteBody;
    [SerializeField] private Sprite ProfessionalBody;
    
    public void SetHeadSprite(Sprite headSprite)
    {
        headAppearance.sprite = headSprite;
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
