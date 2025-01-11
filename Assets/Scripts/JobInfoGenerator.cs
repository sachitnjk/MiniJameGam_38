using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class JobInfoGenerator : MonoBehaviour
{
    [SerializeField] private JobInfoSO jobInfoSO;
    [SerializeField] private RectTransform jobInfoPrefab;
    [SerializeField] private Transform jobInfoUIParent;
    
    private List<JobInfo> generatedJobs = new List<JobInfo>();

    private int currentNumberOfJobsGenerated = 0;
    private int maxJobsToGenerate = 15;

    public void GenerateJobs()
    {
        if (generatedJobs.Count > 0)
        {
            generatedJobs.Clear();
        }
        
        int jobsToGenerate = Random.Range(5, maxJobsToGenerate);

        for (int i = 0; i < jobsToGenerate; i++)
        {
            JobInfo newJobInfo = new JobInfo(
                GetRandomJobBoard(), 
                GetRandomJobLocation(), 
                GetRandomMaxThievesNumber(),
                GetRandomThiefTier());
            
            generatedJobs.Add(newJobInfo);
            
            AddNewJobToUI(newJobInfo);
        }
    }

    private void AddNewJobToUI(JobInfo newJobInfo)
    {
        GameObject newJobInfoUI = Instantiate(jobInfoPrefab.gameObject, jobInfoUIParent);
        
        JobInfoAssigner newJobInfoAssigner = newJobInfoUI.GetComponent<JobInfoAssigner>();
        if (newJobInfoAssigner != null)
        {
            newJobInfoAssigner.SetJobInfo(newJobInfo);
        }
    }

    private Sprite GetRandomJobBoard()
    {
        int randomIndex = Random.Range(0, jobInfoSO.jobBoards.Count);
        
        Sprite randomizedJobBoard = jobInfoSO.jobBoards[randomIndex];
        
        return randomizedJobBoard;
    }

    private String GetRandomJobLocation()
    {
        int randomIndex = Random.Range(0, jobInfoSO.jobLocations.Count);
        
        String randomJobLocation = jobInfoSO.jobLocations[randomIndex];
        
        return randomJobLocation;
    }

    private int GetRandomMaxThievesNumber()
    {
        return 3;
    }
    
    private ThiefTiers GetRandomThiefTier()
    {
        ThiefTiers thiefTier = ThiefTiers.None;
        // Get all the values of the ThiefTiers enum
        ThiefTiers[] values = (ThiefTiers[])System.Enum.GetValues(typeof(ThiefTiers));
        
        // Generate a random index
        int randomIndex = Random.Range(0, values.Length);
        
        // Assign a random value to the thiefTier variable
        thiefTier = values[randomIndex];
        return thiefTier;
    }
}
