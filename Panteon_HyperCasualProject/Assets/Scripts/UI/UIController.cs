using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject paintingPanel;

    private GameObject _target;
    
    private void Start()
    {
        _target = FindObjectOfType<PlayerMovement>().gameObject;
        Debug.Log(_target.name);
    }

    public void ActivateStartPanel()
    {
            startPanel.SetActive(true);
    }

    public void ActivatePaintingPanel(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == _target)
        {
            paintingPanel.SetActive(true);
        }
    }

    public void CloseStartPanel()
    {
            startPanel.SetActive(false);
    }
    public void ClosePaintingPanel()
    {
            paintingPanel.SetActive(false);
    }
    

}
