using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScannerGridGroup : MonoBehaviour ,IInputListener{
    public List<ScannerGrid> gridList;
    public string buildingID;

    public float scale = 0.5f;

    public static ScannerGridGroup selectScannerGrid;

    bool bSelect = false;
    void Start () {
		
	}
	
    public void UpdateColor()
    {
        for(int i=0;i<4;i++)
        {
            gridList[i].scannerId = gridList[i].UpdateColor();

            //Debug.Log("!!!!" + gridList[i].gameObject.name+"  "+ gridList[i].scannerId);
        }
    }

    public void Select(bool isSelect)
    {
        Tool.GetChildInDepth("Select", this.gameObject).SetActive(isSelect);

		if (isSelect) {
			if (selectScannerGrid != null) {
				selectScannerGrid.Select (false);
			}
			selectScannerGrid = this;
			Tool.GetChildInDepth ("MaskInputField", SingletonTMono<Scanners>.Instance.maskUI).GetComponent<InputField> ().text = buildingID;
		} else {
			selectScannerGrid = null;
		}

        this.bSelect = isSelect;
    }

    public void updateInputs(List<AYInput> ayInputList)
    {
        
    }

    public void inputScreenMove(Vector2 delta, Vector2 totalDelta, AYInput ayInput)
    {
        delta = delta / 200;
        this.transform.position = this.transform.position + new Vector3(delta.x, 0, delta.y);
    }

    public void inputWorldMove(Vector2 delta, Vector2 totalDelta, AYInput ayInput)
    {
        //Debug.Log("!!!!!!!!!!!!!" + this.transform.position+"   $$ "+delta);
        //this.transform.position = this.transform.position+new Vector3( delta.x,0,delta.y);
    }

    
    public void OnPressed(bool pressed, bool isRight)
    {
        if(pressed)
        Select(!bSelect);
        

    }

    private const float defaultScale = 0.012f;
    private const float defaultScalePos = 0.01f;
    public void SetScale(float scale)
    {
        this.scale = scale;

        //Debug.Log("" + defaultScale * scale / 0.5f+"   " + scale);
        for(int i=0;i<4;i++)
        {
            gridList[i].transform.localScale = new Vector3(defaultScale * scale / 0.5f *1.3f, defaultScale * scale / 0.5f * 1.3f, defaultScale * scale / 0.5f * 1.3f);
            switch(i)
            {
                case 0:
                    gridList[i].transform.localPosition = new Vector3(-(defaultScalePos * scale / 0.5f + 0.005f), 0, -(defaultScalePos * scale / 0.5f + 0.005f));
                    break;
                case 1:
                    gridList[i].transform.localPosition = new Vector3(defaultScalePos * scale / 0.5f + 0.005f, 0, -(defaultScalePos * scale / 0.5f + 0.005f));
                    break;
                case 2:
                    gridList[i].transform.localPosition = new Vector3(defaultScalePos * scale / 0.5f + 0.005f, 0, defaultScalePos * scale / 0.5f + 0.005f);
                    break;
                case 3:
                    gridList[i].transform.localPosition = new Vector3(-(defaultScalePos * scale / 0.5f + 0.005f), 0, defaultScalePos * scale / 0.5f + 0.005f);
                    break;

            }
        }

    }

    public int[] GetGroupCode()
    {
        int[] groupCode = new int[4];
        for(int i=0;i<4;i++)
        {
            //returnId+= gridList[i].scannerId *(int) Math.Pow(10, i + 1);
            groupCode[i] = gridList[i].scannerId;
        }

        return groupCode;
    }

    public void ShowGrid()
    {

    }

    public void SetIsShow(bool isShow)
    {
        foreach(ScannerGrid grid in this.gridList)
        {
            grid.SetIsShow(isShow);
        }
    }
}
