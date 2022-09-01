using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
    private AndroidNotificationChannel _channel;

    void Start()
    {
        _RegisterNotificationChannel();
        _SendCleaningNotification();
    }

    private void _RegisterNotificationChannel()
    {
        _channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(_channel);
    }

    private void _SendCleaningNotification()
    {
        var notification = new AndroidNotification("¬рем€ разбора!", "—сылки без категорий ждут", DateTime.Now.Date + new TimeSpan(20, 0, 0), new TimeSpan(24, 0, 0));

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }

    private void OnApplicationQuit()
    {
        AndroidNotificationCenter.DeleteNotificationChannel(_channel.Id);
    }
}
