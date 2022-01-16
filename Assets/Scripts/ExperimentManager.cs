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
        public float waitTime = 10f;
        public int _intervalIndex = 0;
        public int _numIntervals = 1;

        // Execution 
        //#region Execution
        public void Start()
       {
           SetState(new BeginState(this)); // Kicks off the logic
       }

        public void onNextButton()
        {
            StartCoroutine(_currentState.Init());
        }
        //State Specific Behaviour
        public void onNextButtonPressed()
        {
            if (_surveyManager.isRunning == false)
            {
                if (_intervalIndex >= _numIntervals)
                {
                    _surveyManager._dataManager.StoreData();
                }
                ExperimentStimulus _stimulus = new ExperimentStimulus();
                _skyboxManager.ChangeSkybox();
                if (_intervalIndex == 0)
                {
                    _audioManager.PlayClip();
                }
                else
                {
                    _audioManager.NextClip();
                }
                _stimulus.AddCondition(_audioManager.GetCurrentClipInfo());
                _stimulus.AddCondition(_skyboxManager.GetSkyboxName());
                _dataStorageManager.ConstructInterval(_intervalIndex++, _stimulus);
                _surveyManager.BeginSequence();
            } else
            {
                _surveyManager.Continue();
            }
        }

        
        // Start is called before the first frame update

    }
}
