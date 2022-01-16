using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

namespace SoundscapeStudy
{
    public class DataStorageManager : MonoBehaviour
    {
        public ExperimentManager _experimentManager;
        public SurveyManager _surveyManager;
        public List<ExperimentDataPoint> dataPoints;
        public ExperimentInterval _currentInterval;
        public string _participantID;

        public DataStorageManager()
        {
            dataPoints = new List<ExperimentDataPoint>();
        }

        public void AddDatapoint(ExperimentDataPoint newDataPoint)
        {
            dataPoints.Add(newDataPoint);
        }

        public ExperimentDataPoint ConstructDataPoint(int newResponse, int newQuestionID)
        {
            ExperimentDataPoint dataPoint = new ExperimentDataPoint();
            dataPoint.response = newResponse;
            dataPoint.questionID = newQuestionID;
            dataPoint.interval = _currentInterval;
            return dataPoint;
        }

        public ExperimentInterval ConstructInterval(int intervalNumber, ExperimentStimulus newStimulus)
        {
            _currentInterval = new ExperimentInterval();
            _currentInterval.number = intervalNumber;
            _currentInterval.participant = _participantID;
            _currentInterval.stimulus = newStimulus;
            return _currentInterval;
        }

        public void SetParticipantID(string newID)
        {
            _participantID = newID;
        }

        public void StoreData()
        {
            string filePath = Application.persistentDataPath;
            string fullPath = filePath + "/listeningtestdata.csv";
            string headerLine = "participant,stimulus,interval,questionID,response\r";
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine(headerLine);
                foreach(ExperimentDataPoint dataPoint in dataPoints)
                {
                    // Participant ID
                    StringBuilder sb = new StringBuilder(dataPoint.interval.participant, 150);
                    // Stimulus info
                    sb.Append(",{");
                    foreach(string stimElement in dataPoint.interval.stimulus.condition)
                    {
                        sb.Append("{");
                        sb.Append(stimElement);
                        sb.Append("}");
                    }
                    sb.Append("},");
                    sb.AppendFormat("{0},", dataPoint.interval.number);
                    sb.AppendFormat("{0},", dataPoint.questionID);
                    sb.AppendFormat("{0},", dataPoint.response);
                    sb.Append("\r");
                    writer.WriteLine(sb.ToString());
                }
            }
        }
    }
}

