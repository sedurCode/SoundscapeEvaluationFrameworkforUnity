using System.Collections;
using UnityEngine;

namespace SoundscapeStudy
{
    public class BeginState : State
    {
        public BeginState(ExperimentManager manager) : base(manager)
        {
            long dt = System.DateTime.Now.Ticks;
            _experimentManager._dataStorageManager.SetParticipantID(string.Format("{0:X}", dt));
            Debug.Log("New participant ID " + _experimentManager._dataStorageManager._participantID);
        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _experimentManager._surveyManager.SetState(new SurveyStateIdle(_experimentManager._surveyManager));
            _experimentManager.SetState(new IntroDialogState(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();
        }
    }

    public class IntroDialogState : State
    {
        public IntroDialogState(ExperimentManager manager) : base(manager)
        {
        }
    }

    public class ListeningState : State
    {
        public ListeningState(ExperimentManager manager) : base(manager)
        {
        }
    }

    public class SurveyState : State
    {
        public SurveyState(ExperimentManager manager) : base(manager)
        {

        }
    }

    public class SurveyStart : State
    {
        public SurveyStart(SurveyManager manager) : base(manager)
        {
            
        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            //_surveyManager.Interface.
            _surveyManager.Interface._uiElementHandle.SetLabel("State Start Label");
            _surveyManager.Interface._uiElementHandle.SetDescription("State Start Text");
            _surveyManager.SetState(new SurveyState1(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime); //base.Start();
        }
    }
    public class SurveyState1 : State
    {
        public SurveyState1(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            //_surveyManager.Interface.
            _surveyManager.Interface._uiElementHandle.SetLabel("Valence");
            string _newDescription = "Valence represents the subjective emotions, feelings and attitudes analogous to pleasantness, ranging from negative to positive. For example, if you feel happy because you have had an experience that you enjoyed, you might rate your valence on the positive end of the scale";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface._uiElementHandle.SetSelectionFieldForSAM();
            _surveyManager.Interface.SetValenceForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyState2(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyState2 : State
    {
        public SurveyState2(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            //_surveyManager.Interface.
            _surveyManager.IncrementQuestionID();
            _surveyManager.Interface._uiElementHandle.SetLabel("Arousal");
            string _newDescription = "Arousal represents the aspects of excitation and relaxation, ranging from low to high. For example, if you feel bored, sleepy or relaxed you might rate your valence on the low end of the scale. Alternately if you have an experience that gets your heart pumping and gives you a feeling of exhilaration, you might rate your valence as high.";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.SetArousalForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime); //base.Start();
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyState3(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyState3 : State
    {
        public SurveyState3(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _surveyManager.IncrementQuestionID();
            _surveyManager.Interface._uiElementHandle.SetLabel("Dominance");
            string _newDescription = "Dominance represents the intensity of the impulse of emotion, such as the impulse to avoid or interact with a stimulus. For example, if you have an experience to which you feel like running away or towards whatever is happening, you might rate your dominance as high.";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.SetDominanceForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime); //base.Start();
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyState4(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyState4 : State
    {
        public SurveyState4(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _surveyManager.IncrementQuestionID();
            _surveyManager.Interface._uiElementHandle.SetLabel("Pleasant");
            string _newDescription = "For each of the scales below, to what extent do you agree that the environment is pleasant?";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.setAttitudesForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime); //base.Start();
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyState5(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyState5 : State
    {
        public SurveyState5(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _surveyManager.IncrementQuestionID();
            _surveyManager.Interface._uiElementHandle.SetLabel("Annoying");
            string _newDescription = "For each of the scales below, to what extent do you agree that the environment is annoying?";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.setAttitudesForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime); //base.Start();
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyState6(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyState6 : State
    {
        public SurveyState6(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _surveyManager.IncrementQuestionID();
            _surveyManager.Interface._uiElementHandle.SetLabel("Vibrant");
            string _newDescription = "For each of the scales below, to what extent do you agree that the environment is vibrant?";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.setAttitudesForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime); //base.Start();
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyState7(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyState7 : State
    {
        public SurveyState7(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _surveyManager.IncrementQuestionID();
            _surveyManager.Interface._uiElementHandle.SetLabel("Monotonous");
            string _newDescription = "For each of the scales below, to what extent do you agree that the environment i Monotonous?";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.setAttitudesForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime); //base.Start();
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyState8(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyState8 : State
    {
        public SurveyState8(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _surveyManager.IncrementQuestionID();
            _surveyManager.Interface._uiElementHandle.SetLabel("Calm");
            string _newDescription = "For each of the scales below, to what extent do you agree that the environment is calm?";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.setAttitudesForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime); //base.Start();
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyState9(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyState9 : State
    {
        public SurveyState9(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _surveyManager.IncrementQuestionID();
            _surveyManager.Interface._uiElementHandle.SetLabel("Chaotic");
            string _newDescription = "For each of the scales below, to what extent do you agree that the environment is chaotic?";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.setAttitudesForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime); //base.Start();
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyState10(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyState10 : State
    {
        public SurveyState10(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _surveyManager.IncrementQuestionID();
            _surveyManager.Interface._uiElementHandle.SetLabel("Eventful");
            string _newDescription = "For each of the scales below, to what extent do you agree that the environment is eventful?";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.setAttitudesForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyState11(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyState11 : State
    {
        public SurveyState11(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _surveyManager.IncrementQuestionID();
            _surveyManager.Interface._uiElementHandle.SetLabel("Uneventful");
            string _newDescription = "For each of the scales below, to what extent do you agree that the environment is uneventful";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.setAttitudesForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyStateEnd(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyStateEnd : State
    {
        public SurveyStateEnd(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _surveyManager.Interface.ClearForm();
            _surveyManager.Interface._uiElementHandle.SetLabel("State END Label");
            _surveyManager.Interface._uiElementHandle.SetDescription("State END Text");
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime); //base.Start();
        }

        public override IEnumerator Next()
        {
            _surveyManager.SetState(new SurveyStateIdle(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }
    public class SurveyStateIdle : State
    {
        public SurveyStateIdle(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            //_surveyManager.Interface.
            _surveyManager.Interface._uiElementHandle.SetLabel("State IDLE Label");
            _surveyManager.Interface._uiElementHandle.SetDescription("State IDLE Text");
            _surveyManager.Interface.ClearForm();
            _surveyManager.isRunning = false;
            yield return null;
        }
    }
}

