using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraShaderApplierScript : MonoBehaviour {

    public Material Shader;

    public List<Material> ShaderList;
    int ShaderIndex = 0;

    // Use this for initialization
    void Start () {

        GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, Shader);
    }
}
