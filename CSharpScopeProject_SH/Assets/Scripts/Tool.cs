using UnityEngine;
using System.Collections;

public class Tool
{


    public static GameObject GetChildInDepth(string name, GameObject rootGO)
    {
        Transform transform = rootGO.transform;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.name == name)
            {
                return transform.GetChild(i).gameObject;
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject go = GetChildInDepth(name, transform.GetChild(i).gameObject);
            if (go != null)
            {
                return go;
            }
        }
        return null;
    }

    public static void SetLayer(string name, GameObject go)
    {
        go.layer = LayerMask.NameToLayer(name);

        foreach (Transform tran in go.GetComponentsInChildren<Transform>())
        {
            tran.gameObject.layer = LayerMask.NameToLayer(name);//更改物体的Layer层  
        }
    }
}
