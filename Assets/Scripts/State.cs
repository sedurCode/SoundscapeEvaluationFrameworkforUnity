using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SoundscapeStudy
{
    public abstract class State
    {
        protected readonly ExperimentManager _experimentManager;
        protected readonly SurveyManager _surveyManager;
        public State(ExperimentManager manager)
        {
            _experimentManager = manager;
        }

        public State(SurveyManager manager)
        {
            _surveyManager = manager;
        }
        public virtual IEnumerator Init()
        {
            yield break;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual IEnumerator Next()
        {
            yield break;
        }
        public virtual IEnumerator Store()
        {
            yield break;
        }
    }

}

