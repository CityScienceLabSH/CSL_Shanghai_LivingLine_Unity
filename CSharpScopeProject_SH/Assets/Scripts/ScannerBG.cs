using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerBG : MonoBehaviour, IInputListener
{
    public void inputScreenMove(Vector2 delta, Vector2 totalDelta, AYInput ayInput)
    {

    }

    public void inputWorldMove(Vector2 delta, Vector2 totalDelta, AYInput ayInput)
    {

    }

    public void OnPressed(bool pressed, bool isRight)
    {

    }

    public void updateInputs(List<AYInput> ayInputList)
    {
        if (ayInputList[ayInputList.Count-1].state == AYInput.AYInputState.leave && SingletonTMono<Scanners>.Instance.CreateGirdFlag)

        {
            GameObject go = (GameObject)GameObject.Instantiate(Resources.Load("Grid"));
            go.transform.position = ayInputList[ayInputList.Count - 1].FirstHitPos;
            go.transform.parent = this.transform;
            SingletonTMono<Scanners>.Instance.CreateGirdFlag = false;
            SingletonTMono<Scanners>.Instance.groupList.Add(go.GetComponent<ScannerGridGroup>());
            go.GetComponent<ScannerGridGroup>().Select(true);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
