using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PostProcessOutlineRenderer), PostProcessEvent.AfterStack, "Custom/Outline")]
public sealed class PostProcessOutline : PostProcessEffectSettings
{
    public FloatParameter thickness = new FloatParameter { value = 1f };
    public FloatParameter depthMin = new FloatParameter { value = 0f };
    public FloatParameter depthMax = new FloatParameter { value = 1f };
}

public class PostProcessOutlineRenderer : PostProcessEffectRenderer<PostProcessOutline>
{
    public static RenderTexture outlineRendererTexture;

    public override DepthTextureMode GetCameraFlags()
    {
        return DepthTextureMode.Depth;
    }

    public override void Render(PostProcessRenderContext context)
    {
        PropertySheet sheet = context.propertySheets.Get(Shader.Find("Hidden/Outline"));
        sheet.properties.SetFloat("_Thickness", settings.thickness);
        sheet.properties.SetFloat("_MinDepth", settings.depthMin);
        sheet.properties.SetFloat("_MaxDepth", settings.depthMax);

        if (outlineRendererTexture == null ||
            outlineRendererTexture.width != Screen.width ||
            outlineRendererTexture.height != Screen.height)
        {
            outlineRendererTexture = new RenderTexture(Screen.width, Screen.height, 24);
            context.camera.targetTexture = outlineRendererTexture;
            // Debug.Log("Test: " + context.camera.name);
        }

        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
