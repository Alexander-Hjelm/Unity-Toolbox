using UnityEngine;

/// <summary>
/// Various helper functions for finding and manipulating Transforms in the scene
/// </summary>
public static class FindUtils {

    /// <summary>
    /// Breadth-first search, find child transforms recursively by tag.
    /// </summary>
    /// <param name="aParent">Parent Transform</param>
    /// <param name="tag">Child tag</param>
    /// <returns></returns>
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

    /// <summary>
    /// Breadth-first search, find child transforms recursively by name.
    /// </summary>
    /// <param name="aParent">Parent Transform</param>
    /// <param name="name">Child name</param>
    /// <returns></returns>
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

    /// <summary>
    /// Set the Layer of a GameObject and all of its grandchildren.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="newLayer"></param>
    public static void SetLayerRecursively(this Transform aTransform, int newLayer) {
        if (null == aTransform) {
            return;
        }

        aTransform.gameObject.layer = newLayer;

        foreach (Transform child in aTransform) {
            if (null == child) {
                continue;
            }
            SetLayerRecursively(child, newLayer);
        }
    }

    /// <summary>
    /// Find the desired component on any of the current Transform's grandparents
    /// </summary>
    /// <param name="aThis"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T FindComponentInGrandParents<T>(this Transform aThis)
    {
        // Check if component is on this transform
        T tOwn = aThis.GetComponent<T>();
        if (tOwn != null)
        {
            return tOwn;
        }
        
        // Check parents recursively
        Transform aParent = aThis;
        while (aParent.parent != null)
        {
            aParent = aParent.parent;
            T t = aParent.GetComponent<T>();
            if (t != null)
            {
                return t;
            }

        }

        return default(T);
    }
    
    /// <summary>
    /// Check whether an Animator has the desired parameter name
    /// </summary>
    /// <param name="paramName"></param>
    /// <param name="animator"></param>
    /// <returns></returns>
    public static bool AnimatorHasParameter(string paramName, Animator animator)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName)
                return true;
        }
        return false;
    }
}
