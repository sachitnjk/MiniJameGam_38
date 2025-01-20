using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NotificationText;
    [SerializeField] private Animator notificationAnimator;

    private void Start()
    {
        NotificationText.gameObject.SetActive(false);
    }

    public void AssignAndTriggerNotification(Enum notification)
    {
        if (NotificationText != null)
        {
            NotificationText.gameObject.SetActive(true);
            
            string notificationString = "";
            
            switch (notification)
            {
                case NotificationType.Broke:
                    notificationString = "Insufficient funds to purchase";
                    break;
                case NotificationType.InadequetThieves:
                    notificationString = "No currently unassigned thieves available";
                    break;
                default:
                    break;
            }
            NotificationText.text = notificationString;

            StartCoroutine(StartNotificationTrigger());
        }
    }

    private IEnumerator StartNotificationTrigger()
    {
        notificationAnimator.SetBool("isVisible", true);
        
        yield return new WaitForSeconds(4f);
        
        notificationAnimator.SetBool("isVisible", false);
    }

}
