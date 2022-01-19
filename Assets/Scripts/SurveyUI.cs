using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoundscapeStudy
{
    public class SurveyUI : MonoBehaviour
    {

        [SerializeField] private VRUIConsole console;
        
        // Start is called before the first frame update
        public SurveyManager _surveyManager;
        public ExperimentManager _experimentManager;
        public VRUIConsole _uiElementHandle;
        public Texture2D[] valenceImages;
        public Texture2D[] arousalImages;
        public Texture2D[] dominanceImages;
        SurveyUI(SurveyManager manager)
        {
            _surveyManager = manager;
        }
        SurveyUI(ExperimentManager manager)
        {
            _experimentManager = manager;
        }
        public void SetValenceForm()
        {
            _uiElementHandle.ClearChildren();
            _uiElementHandle.SetSelectionFieldForSAM();
            _uiElementHandle.PopulateSelectionField(5, valenceImages);
            _uiElementHandle.AttachButtonsToCallback();
        }
        public void SetArousalForm()
        {
            _uiElementHandle.ClearChildren();
            _uiElementHandle.SetSelectionFieldForSAM();
            _uiElementHandle.PopulateSelectionField(5, arousalImages);
            _uiElementHandle.AttachButtonsToCallback();
        }
        public void SetDominanceForm()
        {
            _uiElementHandle.ClearChildren();
            _uiElementHandle.SetSelectionFieldForSAM();
            _uiElementHandle.PopulateSelectionField(5, dominanceImages);
            _uiElementHandle.AttachButtonsToCallback();
           
        }

        public void setAttitudesForm(string descriptor)
        {
            _uiElementHandle.ClearChildren();
            _uiElementHandle.SetSelectionFieldForLikert();
            //string[] descriptors = { "Pleasant", "Annoying", "Vibrant", "Monotonous", "Calm", "Chaotic", "Eventful", "Uneventful" };
            //string[] descriptors = { "Pleasant"};
            _uiElementHandle.PopulateSelectionField(descriptor);
            _uiElementHandle.AttachButtonsToCallback();
        }
        public void setAttitudesForm()
        {
            _uiElementHandle.ClearChildren();
            _uiElementHandle.SetSelectionFieldForLikert();
            _uiElementHandle.PopulateSelectionField();
            _uiElementHandle.AttachButtonsToCallback();
        }
        public void setBasicClassificationForm()
        {
            _uiElementHandle.ClearChildren();
            _uiElementHandle.SetSelectionFieldForBasicSoundscapeClassification();
            _uiElementHandle.PopulateSelectionField();
            _uiElementHandle.AttachButtonsToCallback();
        }
        public void setLoudnessForm()
        {
            _uiElementHandle.ClearChildren();
            _uiElementHandle.SetSelectionFieldForLoundess();
            _uiElementHandle.PopulateSelectionField();
            _uiElementHandle.AttachButtonsToCallback();
        }
        public void setAppropriatenessForm()
        {
            _uiElementHandle.ClearChildren();
            _uiElementHandle.SetSelectionFieldForAppropriateness();
            _uiElementHandle.PopulateSelectionField();
            _uiElementHandle.AttachButtonsToCallback();
        }
        public void setTextInputForm()
        {
            _uiElementHandle.ClearChildren();
            _uiElementHandle.SetSelectionFieldForTextInput();
            _uiElementHandle.PopulateSelectionFieldText();
            _uiElementHandle.AttachButtonsToCallback();
        }
        public void ClearForm()
        {
            _uiElementHandle.ClearChildren();
        }

        public void SetText()
        {
            return;
        }

        public int GetSelectedOption(int index)
        {
            return _uiElementHandle.GetSelectedOption(index);
        }

        public void SetMode(VRUIConsole.Mode newMode)
        {
            _uiElementHandle.SetMode(newMode);
        }

        public VRUIConsole.Mode GetMode()
        {
            return _uiElementHandle.GetMode();
        }
        public int GetNumelements()
        {
            return _uiElementHandle.GetNumelements();
        }
    }
}

