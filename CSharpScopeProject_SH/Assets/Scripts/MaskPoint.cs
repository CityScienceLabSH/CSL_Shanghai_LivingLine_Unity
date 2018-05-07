using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskPoint : MonoBehaviour, IInputListener
{
    public bool isMask;
    public int cubeIndex;
    public int innerCubeIndex;

    public Color color;
    public int currID;

    public static MaskPoint s_SelectMaskPoint;
    public void inputScreenMove(Vector2 delta, Vector2 totalDelta, AYInput ayInput)
    {
        
    }

    public void inputWorldMove(Vector2 delta, Vector2 totalDelta, AYInput ayInput)
    {
       
    }

    public void OnPressed(bool pressed,bool isRight)
    {
        if(pressed&& !isRight)
        {
            
            s_SelectMaskPoint = this;
            Tool.GetChildInDepth("MaskInnerInputField", GameObject.Find("MaskUI")).GetComponent<InputField>().text = innerCubeIndex.ToString();
            Tool.GetChildInDepth("MaskInputField", GameObject.Find("MaskUI")).GetComponent<InputField>().text = innerCubeIndex.ToString();
        }

        if(!pressed&&isRight)
        {
            isMask = !isMask;
            SetMask(isMask);
        }
       
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

    public void SetMask(MaskPointData pointData)
    {
        this.isMask = pointData.isMask;
        this.cubeIndex = pointData.cubeIndex;
        this.innerCubeIndex = pointData.innerCubeIndex;
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
