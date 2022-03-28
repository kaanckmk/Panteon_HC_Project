using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject PaintingPanel;


    public void ActivateStartPanel()
    {
        startPanel.SetActive(true);
    }

    public void ActivatePaintingPanel()
    {
        PaintingPanel.SetActive(true);
    }

    public void CloseStartPanel()
    {
        startPanel.SetActive(false);
    }
    public void ClosePaintingPanel()
    {
        PaintingPanel.SetActive(false);
    }
    
    

}
