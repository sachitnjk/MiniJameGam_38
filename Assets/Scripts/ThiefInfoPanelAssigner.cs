using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThiefInfoPanelAssigner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI tierText;

    public void SetupUI(ThiefData thiefData)
    {
        nameText.text = thiefData.Name;
        tierText.text = thiefData.Tier.ToString();
    }
}
