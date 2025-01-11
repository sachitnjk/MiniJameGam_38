using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JonInfoSO")]
public class JobInfoSO : ScriptableObject
{
    public List<string> jobLocations = new List<string>();
    public List<Sprite> jobBoards = new List<Sprite>();
}
