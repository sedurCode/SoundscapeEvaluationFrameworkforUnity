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
            _experimentManager.PerpareIntervals();
        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _experimentManager._surveyManager.SetState(new SurveyStateIdle(_experimentManager._surveyManager));
            _experimentManager.SetState(new IntroDialogState0(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();
        }
    }

    public class IntroDialogState0 : State
    {
        public IntroDialogState0(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro state 0");
            _experimentManager.SetIntroState(true);
        }
        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _experimentManager.Interface._uiElementHandle.SetLabel("Introduction");
            string introString = "Welcome to soundscape evaluation in VR!\n " +
                "The aim of this experiment is to experience a handful of environments and get an idea of their quality.\n " +
                "To do this, you will evaluate 10 environments through a short survey that will be presented on this console.\n" +
                "Please proceed by selecting the 'Next' button with your controller.";
            _experimentManager.Interface._uiElementHandle.SetDescription(introString);
            _experimentManager._surveyManager.SetState(new SurveyStateIdle(_experimentManager._surveyManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }
        public override IEnumerator Next()
        {
            _experimentManager.SetState(new IntroDialogState1(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }
    }

    public class IntroDialogState1 : State
    {
        public IntroDialogState1(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro state 1");
        }
        public override IEnumerator Start()
        {
            _experimentManager.Interface._uiElementHandle.SetLabel("Introduction 1");
            string introString = "At first we will introduce the questions that are used on the survey.\n" +
                                 "Following this, there will be two training intervals where you can practice going through the survey.\n" +
                                 "Then you can begin the 10 test intervals.an" +
                                 "Please proceed by selecting the 'Next' button.";
            _experimentManager.Interface._uiElementHandle.SetDescription(introString);
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();

        }
        public override IEnumerator Next()
        {
            // Do UI Initialisation
            _experimentManager.SetState(new IntroDialogState2(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();
        }
    }

    public class IntroDialogState2 : State
    {
        public IntroDialogState2(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro state 2");
        }
        public override IEnumerator Start()
        {
            _experimentManager.Interface._uiElementHandle.SetLabel("Introduction 2");
            string introString = "There will be 5 types of question to answer.\n" +
                "Each question type will now be explained.";
            _experimentManager.Interface._uiElementHandle.SetDescription(introString);
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();

        }
        public override IEnumerator Next()
        {
            // Do UI Initialisation
            _experimentManager.SetState(new IntroDialogState3(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();
        }
    }

    public class IntroDialogState3 : State
    {
        public IntroDialogState3(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro state 3");
        }
        public override IEnumerator Start()
        {
            _experimentManager.Interface._uiElementHandle.SetLabel("Introduction 3");
            string introString = "The first type of question is the Self Assessment Manikin.\n" +
                "This is a graphical representation of three elements of emotion, attitude and mood that is split into three sets of five pictures.\n" +
                "The three sets will be presented in the next steps.";
            _experimentManager.Interface._uiElementHandle.SetDescription(introString);
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();
        }
        public override IEnumerator Next()
        {
            // Do UI Initialisation
            _experimentManager.SetState(new IntroDialogState4(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();
        }
    }
    public class IntroDialogState4 : State
    {
        public IntroDialogState4(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro state 4");
        }
        public override IEnumerator Start()
        {
            _experimentManager.Interface._uiElementHandle.SetLabel("Valence");
            string _newDescription = "Valence represents the subjective emotions, feelings and attitudes analogous to pleasantness, ranging from negative to positive. For example, if you feel happy because you have had an experience that you enjoyed, you might rate your valence on the positive end of the scale";
            _experimentManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _experimentManager.Interface._uiElementHandle.SetSelectionFieldForSAM();
            _experimentManager.Interface.SetValenceForm();
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }
        public override IEnumerator Next()
        {
            // Do UI Initialisation
            _experimentManager.SetState(new IntroDialogState5(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();
        }
    }

    public class IntroDialogState5 : State
    {
        public IntroDialogState5(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro state 5");
        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            //_surveyManager.Interface.
            _experimentManager.Interface._uiElementHandle.SetLabel("Arousal");
            string _newDescription = "Arousal represents the aspects of excitation and relaxation, ranging from low to high. For example, if you feel bored, sleepy or relaxed you might rate your valence on the low end of the scale. Alternately if you have an experience that gets your heart pumping and gives you a feeling of exhilaration, you might rate your valence as high.";
            _experimentManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _experimentManager.Interface.SetArousalForm();
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();
        }

        public override IEnumerator Next()
        {
            _experimentManager.SetState(new IntroDialogState6(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }
    }

    public class IntroDialogState6 : State
    {
        public IntroDialogState6(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro state 6");
        }

        public override IEnumerator Start()
        {
            _experimentManager.Interface._uiElementHandle.SetLabel("Dominance");
            string _newDescription = "Dominance represents the intensity of the impulse of emotion, such as the impulse to avoid or interact with a stimulus. For example, if you have an experience to which you feel like running away or towards whatever is happening, you might rate your dominance as high.";
            _experimentManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _experimentManager.Interface.SetDominanceForm();
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }

        public override IEnumerator Next()
        {
            _experimentManager.SetState(new IntroDialogState7(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }
    }

    public class IntroDialogState7 : State
    {
        public IntroDialogState7(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro state 7");
        }

        public override IEnumerator Start()
        {
            _experimentManager.Interface.ClearForm();
            _experimentManager.Interface._uiElementHandle.SetLabel("Likert Scales");
            string _newDescription = "There will be several questions that have the form of a question with a 5 point scale.\n" +
                "The questions will often be along the lines of 'To what extent do you agree that the environment is...'\n" +
                "This will be followed with a descriptor such as 'Pleasant'.";
            _experimentManager.Interface._uiElementHandle.SetDescription(_newDescription);
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }

        public override IEnumerator Next()
        {
            _experimentManager.SetState(new IntroDialogState8(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }
    }

    public class IntroDialogState8 : State
    {
        public IntroDialogState8(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro state 8");
        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _experimentManager.Interface._uiElementHandle.SetLabel("Pleasant");
            string _newDescription = "For each of the scales below, to what extent do you agree that the environment is pleasant?";
            _experimentManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _experimentManager.Interface.setAttitudesForm();
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();
        }

        public override IEnumerator Next()
        {
            _experimentManager.SetState(new IntroDialogState9(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }
    }

    public class IntroDialogState9 : State
    {
        public IntroDialogState9(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro state 9");
        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _experimentManager.Interface.ClearForm();
            _experimentManager.Interface._uiElementHandle.SetLabel("Classification");
            string _newDescription = "Some questions will ask you to classify sounds or the soundscape from a list of classes.";
            _experimentManager.Interface._uiElementHandle.SetDescription(_newDescription);
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }

        public override IEnumerator Next()
        {
            _experimentManager.SetState(new IntroDialogState10(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }
    }

    public class IntroDialogState10 : State
    {
        public IntroDialogState10(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro state 10");
        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _experimentManager.Interface._uiElementHandle.SetLabel("Classification");
            string _newDescription = "Which of the following terms best classifies the type of environment you experienced?";
            _experimentManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _experimentManager.Interface.setBasicClassificationForm();
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }

        public override IEnumerator Next()
        {
            _experimentManager.SetState(new IntroDialogState11(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }
    }

    public class IntroDialogState11 : State
    {
        public IntroDialogState11(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro state 11");
        }

        public override IEnumerator Start()
        {
            _experimentManager.Interface.ClearForm();
            _experimentManager.Interface._uiElementHandle.SetLabel("Training");
            string _newDescription = "One question will require you to select an option from a hierarchical structure of sound classes.\n" +
                                     "This question type is still TODO.";
            _experimentManager.Interface._uiElementHandle.SetDescription(_newDescription);
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();
        }

        public override IEnumerator Next()
        {
            _experimentManager.SetState(new IntroDialogState12(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }
    }

    public class IntroDialogState12 : State
    {
        public IntroDialogState12(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro state 12");
        }

        public override IEnumerator Start()
        {
            _experimentManager.Interface._uiElementHandle.SetLabel("Training");
            string _newDescription = "Next we shall move on to two training intervals.";
            _experimentManager.Interface._uiElementHandle.SetDescription(_newDescription);
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();
        }

        public override IEnumerator Next()
        {
            _experimentManager.SetState(new IntroDialogEndState(_experimentManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime);
        }
    }

    public class IntroDialogEndState : State
    {
        public IntroDialogEndState(ExperimentManager manager) : base(manager)
        {
            Debug.Log("Entering intro end state");
            _experimentManager.Interface._uiElementHandle.SetLabel("Introduction End");
        }
        public override IEnumerator Start()
        {
            _experimentManager.Interface.ClearForm();
            _experimentManager.SetIntroState(false);
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();
        }
        public override IEnumerator Next()
        {
            _experimentManager._surveyManager.SetState(new SurveyStart(_experimentManager._surveyManager));
            yield return new WaitForSecondsRealtime(_experimentManager.waitTime); //base.Start();
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
            string _newDescription = "To what extent do you agree that the environment is pleasant?";
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
            string _newDescription = "To what extent do you agree that the environment is annoying?";
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
            string _newDescription = "To what extent do you agree that the environment is vibrant?";
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
            string _newDescription = "To what extent do you agree that the environment is calm?";
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
            string _newDescription = "To what extent do you agree that the environment is chaotic?";
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
            string _newDescription = "To what extent do you agree that the environment is eventful?";
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
            string _newDescription = "To what extent do you agree that the environment is uneventful";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.setAttitudesForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyState12(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyState12 : State
    {
        public SurveyState12(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _surveyManager.IncrementQuestionID();
            _surveyManager.Interface._uiElementHandle.SetLabel("Loudness");
            string _newDescription = "How loud do you percieve the environment to be?";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.setLoudnessForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyState13(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyState13 : State
    {
        public SurveyState13(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _surveyManager.IncrementQuestionID();
            _surveyManager.Interface._uiElementHandle.SetLabel("Classification");
            string _newDescription = "Which of the following terms best classifies the type of environment you experienced?";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.setBasicClassificationForm();
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }

        public override IEnumerator Next()
        {
            _surveyManager.StoreData();
            _surveyManager.SetState(new SurveyState14(_surveyManager));
            yield return new WaitForSecondsRealtime(_surveyManager.waitTime);
        }
    }

    public class SurveyState14 : State
    {
        public SurveyState14(SurveyManager manager) : base(manager)
        {

        }

        public override IEnumerator Start()
        {
            // Do UI Initialisation
            _surveyManager.IncrementQuestionID();
            _surveyManager.Interface._uiElementHandle.SetLabel("Appropriateness");
            string _newDescription = "Overall, to what extent is the sound environment appropriate to the images presented to represent the scene?";
            _surveyManager.Interface._uiElementHandle.SetDescription(_newDescription);
            _surveyManager.Interface.setAppropriatenessForm();
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
            _surveyManager.Interface.ClearForm();
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
            //_surveyManager.Interface._uiElementHandle.SetLabel("State IDLE Label");
            //_surveyManager.Interface._uiElementHandle.SetDescription("State IDLE Text");
            //_surveyManager.Interface.ClearForm();
            _surveyManager.isRunning = false;
            yield return null;
        }
    }
}

