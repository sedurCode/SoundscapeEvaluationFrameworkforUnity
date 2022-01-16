using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoundscapeStudy
{
    public delegate void FooBarDelegate(Button x);
    public class VRUIConsole : MonoBehaviour
    {
        public enum Mode
        {
            SAM,
            Likert
        }
        [SerializeField] private Mode currentMode;
        [SerializeField] public Text labelField;
        [SerializeField] public Text descriptionField;
        [SerializeField] public GameObject selectionField;
        [SerializeField] public Text buttonField;
        [SerializeField] private int selectedField;
        [SerializeField] private List<int> _selectedOption;
        [SerializeField] private int numElements;
        [SerializeField] private int numOptions;
        [SerializeField] private List<string> _buttonText;

        public void SetLabel(string newLabel)
        {
            labelField.text = newLabel;
        }
        public void SetDescription(string newDescription)
        {
            descriptionField.text = newDescription;
        }
        public void ClearChildren()
        {
            selectionField.GetComponent<PopulateGrid>().ClearChildren();
        }
        public void SetSelectionFieldForSAM()
        {
            // Grid Layout Group
            GridLayoutGroup _glg = selectionField.GetComponent<GridLayoutGroup>();
            _glg.constraintCount = 1;
            _glg.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            _glg.childAlignment = TextAnchor.MiddleCenter;
            _glg.startAxis = GridLayoutGroup.Axis.Horizontal;
            _glg.startCorner = GridLayoutGroup.Corner.UpperLeft;
            _glg.cellSize.Set(120, 180);
            _glg.spacing.Set(5, 5);
            SetMode(Mode.SAM);
            numElements = 1;
            _selectedOption.Clear();
            for (int i = 0; i < numElements; i++)
            {
                _selectedOption.Add(-1);
            }
            numOptions = 5;
            _buttonText.Clear();
            for (int i = 0; i < numOptions; i++)
            {
                _buttonText.Add("select");
            }
            // ContentSizeFitter
        }
        public void SetSelectionFieldForLikert()
        {
            // Grid Layout Group
            GridLayoutGroup _glg = selectionField.GetComponent<GridLayoutGroup>();
            //_glg.constraint = GridLayoutGroup.Constraint.Flexible;
            _glg.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            _glg.constraintCount = 1;
            _glg.childAlignment = TextAnchor.MiddleCenter;
            _glg.startAxis = GridLayoutGroup.Axis.Horizontal;
            _glg.startCorner = GridLayoutGroup.Corner.UpperLeft;
            _glg.cellSize.Set(120, 180); //_glg.cellSize.Set(30, 30);
            _glg.spacing.Set(5, 5);
            SetMode(Mode.Likert);
            numElements = 1;
            _selectedOption.Clear();
            for (int i = 0; i < numElements; i++)
            {
                _selectedOption.Add(-1);
            }
            numOptions = 5;
            _buttonText.Clear();
            _buttonText.Add("Strongly Disagree");
            _buttonText.Add("Somewhat Disagree");
            _buttonText.Add("Neither Agree nor Disagree");
            _buttonText.Add("Somewhat Agree");
            _buttonText.Add("Strongly Agree");
            // ContentSizeFitter
            //ContentSizeFitter _csf = selectionField.GetComponent<ContentSizeFitter>();
            //_csf.horizontalFit = ContentSizeFitter.FitMode.MinSize;
            //_csf.verticalFit = ContentSizeFitter.FitMode.MinSize;
        }
        public void PopulateSelectionField(int numToPopulate, Texture2D[] textures)
        {
            selectionField.GetComponent<PopulateGrid>().PopulateSAM(numToPopulate, textures);
        }

        public void PopulateSelectionField(string[] descriptors)
        {
            for (int i = 0; i < descriptors.Length; i++)
            {
                selectionField.GetComponent<PopulateGrid>().PopulateLikert(descriptors[i], _buttonText.ToArray(), i);
            }
        }

        public void PopulateSelectionField(string descriptor)
        {
            selectionField.GetComponent<PopulateGrid>().PopulateLikert(descriptor, _buttonText.ToArray(), 0);
        }
        public void PopulateSelectionField()
        {
            selectionField.GetComponent<PopulateGrid>().PopulateLikert(_buttonText.ToArray(), 0);
        }

        public void AttachButtonsToCallback()
        {
            selectionField.GetComponent<PopulateGrid>().AttachButtonsToCallback(onButtonClick);
        }

        public void onButtonClick(Button btn)
        {
            SurveyButtonInfo info = btn.GetComponent<SurveyButtonInfo>();
            _selectedOption[info.elementNum] = info.instanceNum;
            selectionField.GetComponent<PopulateGrid>().RefreshButtonText(_buttonText.ToArray());
            btn.GetComponentInChildren<Text>().text = "Selected";
            Debug.Log("clicked " + info.instanceNum + " at " + info.elementNum);
        }

        public void SetButtonText(string newButtonText)
        {
            buttonField.text = newButtonText;
        }

        public int GetSelectedOption(int index)
        {
            return _selectedOption[index];
        }

        public void SetMode(Mode newMode)
        {
            currentMode = newMode;
        }

        public Mode GetMode()
        {
            return currentMode;
        }
        public int GetNumelements()
        {
            return numElements;
        }
    }
}