using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundscapeStudy
{
    public struct ExperimentInterval
    {
        public int number;
        public string participant;
        public ExperimentStimulus stimulus;
    }
    public struct ExperimentDataPoint
    {
        public ExperimentInterval interval;
        public int questionID;
        public int response;
    }

    public class ExperimentStimulus
    {
        public List<string> condition;
        public ExperimentStimulus()
        {
            condition = new List<string>();
        }
        public void AddCondition(string newCondition)
        {
            condition.Add(newCondition);
        }
    }
}
