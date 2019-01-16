using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FindUtils {

    //Breadth-first search, find child transforms recursively
    public static Transform FindDeepChildByTag(this Transform aParent, string tag)
    {
        if (aParent.tag == tag) return aParent;
        
        foreach (Transform child in aParent) {
            Transform result = child.FindDeepChildByTag(tag);
            if (result != null && result.tag == tag)
                return result;
        }
        return null;
    }

    //Breadth-first search, find child transforms recursively
    public static Transform FindDeepChildByName(this Transform aParent, string name)
    {
        if (aParent.name == name) return aParent;
        
        foreach (Transform child in aParent) {
            Transform result = child.FindDeepChildByName(name);
            if (result != null && result.name == name)
                return result;
        }
        return null;
    }

    public static void SetLayerRecursively(GameObject obj, int newLayer) {
        if (null == obj) {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform) {
            if (null == child) {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

}
