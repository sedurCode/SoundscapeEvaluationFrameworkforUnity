using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundscapeStudy
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State _currentState;
        // Start is called before the first frame update
        public void SetState(State state)
        {
            _currentState = state;
            StartCoroutine(_currentState.Start());
        }

        public void Continue()
        {
            StartCoroutine(_currentState.Next());
        }

        public State GetCurrentState()
        {
            return _currentState;
        }
    }
}



 
