using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskPoint : MonoBehaviour, IInputListener
{
    public bool isMask;

    public void inputScreenMove(Vector2 delta, Vector2 totalDelta, AYInput ayInput)
    {
        
    }

    public void inputWorldMove(Vector2 delta, Vector2 totalDelta, AYInput ayInput)
    {
       
    }

    public void OnPressed(bool pressed)
    {
        if(pressed)
        {
            isMask = !isMask;
        }

        SetMask(isMask);
    }

    public void updateInputs(List<AYInput> ayInputList)
    {

    }

    public void SetMask(bool isMask)
    {
        this.isMask = isMask;
        MeshRenderer render = this.GetComponent<MeshRenderer>();
        if (isMask)
        {
            render.material.color = Color.red;
        }
        else
        {
            render.material.color = Color.white;
        }
    }

   
    void Start () {
		
	}
	

	void Update () {
		
	}
}
