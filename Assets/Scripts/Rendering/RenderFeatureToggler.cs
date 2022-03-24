using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public struct RenderFeatureToggle
{
    public ScriptableRendererFeature feature;
    public bool isEnabled;
}

[ExecuteInEditMode]
public class RenderFeatureToggler : MonoBehaviour
{
    private List<ScriptableRendererFeature> m_DisabledRenderFeatures = new List<ScriptableRendererFeature>();

    [SerializeField]
    private List<RenderFeatureToggle> renderFeatures = new List<RenderFeatureToggle>();
    [SerializeField]
    private UniversalRenderPipelineAsset pipelineAsset;

    private void Awake()
    {
        

        //DisableRenderFeature<ScriptableRendererFeature>(pipelineAsset);
    }

    private void Update()
    {
        foreach (RenderFeatureToggle toggleObj in renderFeatures)
        {
            //DisableRenderFeature <pipelineAsset.> (pipelineAsset);
            toggleObj.feature.SetActive(toggleObj.isEnabled);
        }
    }

    private void DisableRenderFeature<T>(UniversalRenderPipelineAsset asset) where T : ScriptableRendererFeature
    {
        var renderFeature = asset.DisableRenderFeature<T>();

        if (renderFeature != null)
        {
            m_DisabledRenderFeatures.Add(renderFeature);
        }
    }
}



public static class UniversalRenderPipelineAssetExtensions
{
    public static ScriptableRendererFeature DisableRenderFeature<T>(this UniversalRenderPipelineAsset asset) where T : ScriptableRendererFeature
    {
        var type = asset.GetType();
        var propertyInfo = type.GetField("m_RendererDataList", BindingFlags.Instance | BindingFlags.NonPublic);

        if (propertyInfo == null)
        {
            return null;
        }


        var scriptableRenderData = (ScriptableRendererData[])propertyInfo.GetValue(asset);

        if (scriptableRenderData != null && scriptableRenderData.Length > 0)
        {
            foreach (var renderData in scriptableRenderData)
            {
                foreach (var rendererFeature in renderData.rendererFeatures)
                {
                    if (rendererFeature is T)
                    {
                        rendererFeature.SetActive(false);

                        return rendererFeature;
                    }
                }
            }
        }

        return null;
    }
}