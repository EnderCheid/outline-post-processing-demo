using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PostProcessOutlineCompositeRenderer), PostProcessEvent.AfterStack, "Custom/Outline Composite")]
public sealed class PostProcessOutlineComposite : PostProcessEffectSettings
{
    public ColorParameter color = new ColorParameter() { value = Color.white };
}

public class PostProcessOutlineCompositeRenderer : PostProcessEffectRenderer<PostProcessOutlineComposite>
{
    static RenderTexture outlineRendererTexture;

    public override void Render(PostProcessRenderContext context)
    {
        PropertySheet sheet = context.propertySheets.Get(Shader.Find("Hidden/OutlineComposite"));
  
        sheet.properties.SetColor("_Color", settings.color);

        if (PostProcessOutlineRenderer.outlineRendererTexture != null)
        {
            sheet.properties.SetTexture("_OutlineTex", PostProcessOutlineRenderer.outlineRendererTexture);
            // Debug.Log("Test2: " + context.camera.name);

        }

        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
