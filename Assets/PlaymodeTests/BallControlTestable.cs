using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.TestTools;

public class BallControlTestable : BallControl, IMonoBehaviourTest
{
    float? startTime;

    public bool IsTestFinished
    {
        get
        {
            if (startTime == null)
            {
                startTime = Time.fixedTime;
            }
            return Time.fixedTime > startTime.Value + SecondsForceApplied;
        }
    }
}