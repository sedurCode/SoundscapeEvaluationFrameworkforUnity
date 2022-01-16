using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundscapeStudy
{

    public class SurveyManager : StateMachine
    {
        [SerializeField] private SurveyUI ui;
        [SerializeField] private int _questionID;
        public DataStorageManager _dataManager;
        public float waitTime = 10f;
        public SurveyUI Interface => ui;
        public bool isRunning = false;
        // Start is called before the first frame update
        public void BeginSequence()
        {
            ResetQuestionID();
            isRunning = true;
            SetState(new SurveyStart(this)); // Kicks off the logic
        }

        public void StoreData()
        {
            VRUIConsole.Mode uiMode = ui.GetMode();
            switch(uiMode)
            {
                case VRUIConsole.Mode.SAM:
                    {
                        ExperimentDataPoint _dataPoint = _dataManager.ConstructDataPoint(ui.GetSelectedOption(0), _questionID);
                        _dataManager.AddDatapoint(_dataPoint);
                        break;
                    }

                case VRUIConsole.Mode.Likert:
                    {
                        ExperimentDataPoint _dataPoint = new ExperimentDataPoint();
                        for (int i = 0; i < ui.GetNumelements() - 1; i++)
                        {
                            _dataPoint = _dataManager.ConstructDataPoint(ui.GetSelectedOption(i), _questionID);
                            _dataManager.AddDatapoint(_dataPoint);
                            IncrementQuestionID();
                        }
                        _dataPoint = _dataManager.ConstructDataPoint(ui.GetSelectedOption(ui.GetNumelements() - 1), _questionID);
                        _dataManager.AddDatapoint(_dataPoint);
                        break;
                    }
            }
        }

        public void SetQuestionID(int newID)
        {
            _questionID = newID;
        }
        public int GetQuestionID()
        {
            return _questionID;
        }

        public void IncrementQuestionID()
        {
            _questionID++;
        }

        public void ResetQuestionID()
        {
            _questionID = 0;
        }
    }
}
