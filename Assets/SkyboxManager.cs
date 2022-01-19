using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


[RequireComponent(typeof(Cubemap))]
public class SkyboxManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Material skyboxMat4Photo;
    //public Texture texture;
    public Texture[] textures;
    private int currentSkybox;
    private int _numTextures = 30;
    private string _textureString;
    void Start()
    {
        //textures = Resources.FindObjectsOfTypeAll<Texture>("stills");
        //textures = Resources.LoadAll<Texture>("stills");
        currentSkybox = 0;
        _numTextures = textures.Length;
        //Resources.FindObjectsOfTypeAll<Texture>("stills");
    }
    void Update()
    {
        if (skyboxMat4Photo != null)
        {
            RenderSettings.skybox = skyboxMat4Photo;
            DynamicGI.UpdateEnvironment();
        }
    }

    public void ChangeSkybox(int index)
    {
        currentSkybox = index;
        updateSkybox();
    }
    public void ChangeSkybox()
    {
        currentSkybox++;
        currentSkybox = ConstrainIndex(currentSkybox);
        updateSkybox();
    }
    int ConstrainIndex(int idx)
    {
        if (idx < 0)
        {
            idx = _numTextures - 1;
        }
        if (idx >= _numTextures)
        {
            idx = 0;
        }
        return idx;
    }

    void updateSkybox()
    {
        //_textureString = "stills/Woodland1_still";
        //Texture texture = Resources.Load<Texture>(_textureString);
        Texture texture = textures[currentSkybox];
        Debug.Log("New texture name: " + texture.name);
        skyboxMat4Photo = new Material(Shader.Find("Skybox/Cubemap"));
        if (skyboxMat4Photo == null)
        {
            Debug.Log("skybox texture is null!");
            return;
        }
        skyboxMat4Photo.SetTexture("_Tex", texture);
    }

    public string GetSkyboxName()
    {
        return textures[currentSkybox].name;
    }
}
