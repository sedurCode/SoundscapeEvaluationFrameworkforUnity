using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundscapeStudy
{
    public class ExperimentManager : StateMachine
    {
        public SurveyManager _surveyManager;
        public DataStorageManager _dataStorageManager;
        public AudioManager _audioManager;
        public SkyboxManager _skyboxManager;
        [SerializeField] private SurveyUI ui;
        public SurveyUI Interface => ui;
        public float waitTime = 10f;
        public int _intervalIndex = 0;
        public int _numIntervals = 1;
        [SerializeField] private int[] intervals;
        [SerializeField] private bool isIntroState = false;

        // Execution 
        //#region Execution
        public void Start()
       {
            // Allocation 
            SetState(new BeginState(this)); // Kicks off the logic
       }

        public void onNextButton()
        {
            StartCoroutine(_currentState.Init());
        }
        //State Specific Behaviour
        public void onNextButtonPressed()
        {
            if (isIntroState == true)
            {
                Continue();
                return;
            }
            if (_surveyManager.isRunning == false)
            {
                if (_intervalIndex >= _numIntervals)
                {
                    _surveyManager._dataManager.StoreData();
                }
                _intervalIndex++;
                ExperimentStimulus _stimulus = new ExperimentStimulus();
                _skyboxManager.ChangeSkybox(intervals[_intervalIndex]);
                _audioManager.SetClipID(intervals[_intervalIndex]);
                //_skyboxManager.ChangeSkybox();
                _audioManager.PlayClip();
                _stimulus.AddCondition(_audioManager.GetCurrentClipInfo());
                _stimulus.AddCondition(_skyboxManager.GetSkyboxName());
                _dataStorageManager.ConstructInterval(_intervalIndex, _stimulus);
                _surveyManager.BeginSequence();
            } else
            {
                _surveyManager.Continue();
            }
        }
        
        public void PerpareIntervals()
        {
            intervals = new int[10];
            Random.InitState((int)System.DateTime.Now.Ticks);
            for (int i = 0; i < 10; i++)
            {
                intervals[i] = Mathf.FloorToInt(Random.Range(0f, 30f));
            }
        }
        
        public void SetIntroState(bool newState)
        {
            isIntroState = newState;
        }
        // Start is called before the first frame update

    }
}
