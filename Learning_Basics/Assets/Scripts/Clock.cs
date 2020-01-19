using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] Transform hoursTransform, minutesTransform, secondsTransform;
    [SerializeField] bool continuous;

    private const float degreesPerHour = 30,
                        degreesPerMinute = 6f,
                        degreesPerSecond = 6f;


    private void Update()
    {
        if(continuous)
        {
            UpdateContinuous();
        }
        else
        {
            UpdateDiscrete();
        }
    }

    private void UpdateContinuous()
    {
        TimeSpan timeSpan = DateTime.Now.TimeOfDay;

        hoursTransform.localRotation = Quaternion.Euler(0, (float) timeSpan.TotalHours * degreesPerHour, 0);
        minutesTransform.localRotation = Quaternion.Euler(0, (float) timeSpan.TotalMinutes * degreesPerMinute, 0);
        secondsTransform.localRotation = Quaternion.Euler(0, (float) timeSpan.TotalSeconds * degreesPerSecond, 0);
    }

    private void UpdateDiscrete()
    {
        DateTime dateTime = DateTime.Now;

        hoursTransform.localRotation = Quaternion.Euler(0, dateTime.Hour * degreesPerHour, 0);
        minutesTransform.localRotation = Quaternion.Euler(0, dateTime.Minute * degreesPerMinute, 0);
        secondsTransform.localRotation = Quaternion.Euler(0, dateTime.Second * degreesPerSecond, 0);
    }
}
