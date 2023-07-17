using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    bool objHighlighted;

    static void Swaplayer(GameObject obj, string layerName)
    {
        Swaplayer(obj, layerName, true);
    }

    static void Swaplayer(GameObject obj, string layerName, bool children)
    {
        obj.layer = LayerMask.NameToLayer(layerName);

        if (children)
        {
            foreach (Transform child in obj.transform)
            {
                Swaplayer(child.gameObject, layerName, children);
            }
        }
    }

    public void ObjectMouseEnter()
    {
        Swaplayer(gameObject, "HighlightOutline");
    }

    public void ObjectMouseExit()
    {
        Swaplayer(gameObject, "Default");
    }
}
