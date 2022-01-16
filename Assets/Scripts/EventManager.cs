using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onChangeSceneCallback(int i_sceneID)
    {
        SceneManager.LoadScene(i_sceneID);
    }

    public void onChangeSceneCallback(string s_sceneID)
    {
        SceneManager.LoadScene(s_sceneID);
    }
}
