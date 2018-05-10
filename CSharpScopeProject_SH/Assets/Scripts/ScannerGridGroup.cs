using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerGridGroup : MonoBehaviour ,IInputListener{
    public List<ScannerGrid> gridList;
    public string buildingID;

    public static ScannerGridGroup selectScannerGrid;

	void Start () {
		
	}
	
    public void UpdateColor()
    {
        for(int i=0;i<4;i++)
        {
            gridList[i].scannerId = gridList[i].UpdateColor();
        }
    }

    public void Select(bool isSelect)
    {
        Tool.GetChildInDepth("Select", this.gameObject).SetActive(isSelect);

        if(isSelect)
        {
            if(selectScannerGrid!=null)
            {
                selectScannerGrid.Select(false);
            }
            selectScannerGrid = this;

        }
    }

    public void updateInputs(List<AYInput> ayInputList)
    {
        
    }

    public void inputScreenMove(Vector2 delta, Vector2 totalDelta, AYInput ayInput)
    {
        
    }

    public void inputWorldMove(Vector2 delta, Vector2 totalDelta, AYInput ayInput)
    {
        this.transform.position += new Vector3( delta.x,delta.y);
    }

    public void OnPressed(bool pressed, bool isRight)
    {
        if(pressed)
        Select(true);
    }
}
