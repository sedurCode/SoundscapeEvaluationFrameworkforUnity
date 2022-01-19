using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoundscapeStudy
{

    public class PopulateGrid : MonoBehaviour
    {
        public GameObject SAMPrefab;
        public GameObject LikertHeaderPrefab;
        public GameObject LikertElementPrefab;
        public GameObject InputFieldPrefab;
        public AudioClip hoverSound;
        public AudioClip clickSound;

        public void PopulateSAM(int numToCreate, Texture2D[] textures)
        {
            GameObject newObj;
            for (int i = 0; i < numToCreate; i++)
            {
                newObj = (GameObject)Instantiate(SAMPrefab, transform);
                newObj.GetComponentInChildren<RawImage>().texture = textures[i];
                newObj.GetComponentInChildren<SurveyButtonInfo>().instanceNum = i;
                newObj.GetComponentInChildren<SurveyButtonInfo>().elementNum = 0;
                AddButtonAudioToObject(newObj);
                AttachButtonsToAudioCallback(newObj.GetComponentInChildren<Button>());
            }
        }

        public void PopulateLikert(string descriptor, string[] fields, int element)
        {
            GameObject newObj;
            newObj = (GameObject)Instantiate(LikertHeaderPrefab, transform);
            newObj.GetComponentInChildren<Text>().text = descriptor;
            for (int i = 0; i < fields.Length; i++)
            {
                newObj = (GameObject)Instantiate(LikertElementPrefab, transform);
                Button btn = newObj.GetComponentInChildren<Button>();
                btn.GetComponentInChildren<Text>().text = fields[i];
                AddButtonAudioToObject(newObj);
                AttachButtonsToAudioCallback(btn);
                newObj.GetComponentInChildren<SurveyButtonInfo>().instanceNum = i;
                newObj.GetComponentInChildren<SurveyButtonInfo>().elementNum = element;
            }
        }

        public void PopulateLikert(string[] fields, int element)
        {
            GameObject newObj;
            for (int i = 0; i < fields.Length; i++)
            {
                newObj = (GameObject)Instantiate(LikertElementPrefab, transform);
                Button btn = newObj.GetComponentInChildren<Button>();
                btn.GetComponentInChildren<Text>().text = fields[i];
                AddButtonAudioToObject(newObj);
                AttachButtonsToAudioCallback(btn);
                newObj.GetComponentInChildren<SurveyButtonInfo>().instanceNum = i;
                newObj.GetComponentInChildren<SurveyButtonInfo>().elementNum = element;
            }
        }

        public void PopulateTextInput(BNG.VRKeyboard AttachedKeyboard)
        {
            GameObject newObj;
            newObj = (GameObject)Instantiate(InputFieldPrefab, transform);
            newObj.GetComponentInChildren<SurveyButtonInfo>().instanceNum = 0;
            newObj.GetComponentInChildren<SurveyButtonInfo>().elementNum = 0;
            newObj.GetComponent<BNG.VRTextInput>().AttachedKeyboard = AttachedKeyboard;
        }

        public void AttachButtonsToCallback(FooBarDelegate function)
        {
            var children = new List<GameObject>();
            foreach (Transform child in transform) children.Add(child.gameObject);
            foreach (GameObject child in children)
            {
                Button btn = child.GetComponentInChildren<Button>();
                if (btn == null)
                {
                    continue;
                }
                btn.onClick.AddListener(() => function(btn));
            }
        }
        public void AttachButtonsToAudioCallback(Button btn)
        {
            btn.onClick.AddListener(() => ClickAudioCallback(btn));
        }
        public void RefreshButtonText(string[] buttonText)
        {
            var children = new List<GameObject>();
            int i = 0;
            foreach (Transform child in transform) children.Add(child.gameObject);
            foreach (GameObject child in children)
            {
                Button btn = child.GetComponentInChildren<Button>();
                if (btn == null)
                {
                    continue;
                } else
                {
                    btn.GetComponentInChildren<Text>().text = buttonText[i];
                    i++;
                    if (i >= buttonText.Length)
                    {
                        i = 0;
                    }
                }
            }
        }
        public void ClearChildren()
        {
            var children = new List<GameObject>();
            foreach (Transform child in transform) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));
        }

        public void AddButtonAudioToObject(GameObject gameObj)
        {
            gameObj.AddComponent<AudioSource>();
            gameObj.AddComponent<ONSPAudioSource>();
            AudioSource audioSource = gameObj.GetComponent<AudioSource>();
            audioSource.spatialize = true;
            audioSource.spatialBlend = 1f;
            audioSource.volume = db2mag(-12f);
        }
        public void ClickAudioCallback(Button btn)
        {
            AudioSource audioSource = btn.GetComponentInParent<AudioSource>();
            audioSource.clip = clickSound;
            audioSource.Play();

        }

        public float db2mag(float x)
        {
            return Mathf.Pow(10f,(x / 20f));
        }

    }
}

