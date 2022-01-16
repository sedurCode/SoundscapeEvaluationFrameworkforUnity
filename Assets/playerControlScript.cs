using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlScript : MonoBehaviour
{
    private int numTextures;
    public Material skyboxMat4Photo;
    public Texture[] textures;
    // Start is called before the first frame update
    void Start()
    {
        textures = Resources.LoadAll<Texture>("stills");
        numTextures = textures.Length;
        setRandomTexture();
    }

    // Update is called once per frame
    void Update()
    {
        if (skyboxMat4Photo != null)
            RenderSettings.skybox = skyboxMat4Photo;
            DynamicGI.UpdateEnvironment();
    }

    public void setRandomTexture()
    {
        int locIdx = Random.Range(0, numTextures);
        setTexture(locIdx);
    }

    private void setTexture(int idx)
    {
        var texture = textures[idx];
        Debug.Log("New texture name: " + texture.name);
        skyboxMat4Photo = new Material(Shader.Find("Skybox/Cubemap")); // Material(Shader.Find("Materials/SkyboxMaterialA"));
        //skyboxMat4Photo.mainTexture = texture;
        //skyboxMat4Photo.mainTexture = textures[idx];
        //skyboxMat4Photo.SetTexture("_MainTex", texture)
        skyboxMat4Photo.SetTexture("_Tex", texture);
        //skyboxMat4Photo.mainTexture = texture;
        //RenderSettings.skybox.SetTexture("_MainTex", texture
        //RenderSettings.skybox.SetTexture("_MainTex", texture);
        //RenderSettings.skybox = skyboxMat4Photo;
        //DynamicGI.UpdateEnvironment();
    }

    public void goBackOneTexture()
    {

    }
}
