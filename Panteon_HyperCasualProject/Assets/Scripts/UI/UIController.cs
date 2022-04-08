using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameEvent OnPaintingFinished;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject leaderBoardPanel;
    [SerializeField] private GameObject paintCanvas;
    [SerializeField] private GameObject RestartPanel;
    [SerializeField] private Image fillAmountImage;

    [SerializeField] private List<GameObject> leadingUI;

    [SerializeField] private Sprite boySprite;
    [SerializeField] private Sprite girlSprite;
    
    //[SerializeField] private image

    private GameObject _target;
    
    private void Start()
    {
        _target = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void Update()
    {
        if (fillAmountImage.fillAmount >= 0.998f)
        {
            OnPaintingFinished.Raise();
        }
    }

    public void ActivateStartPanel()
    {
            startPanel.SetActive(true);
    }

    public void ActivatePaintingPanel(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == _target)
        {
            paintCanvas.SetActive(true);
        }
    }

    public void CloseStartPanel()
    {
            startPanel.SetActive(false);
    }
    public void ClosePaintingPanel()
    {
        paintCanvas.SetActive(false);
    }

    public void CloseLeaderBoard(DataPassWithEvent rawData)
    {
        if (rawData.gameObject == _target)
        {
            leaderBoardPanel.SetActive(false);
        }
    }
    
    
    public void UpdateLeaderBoard(List<DataPassWithEvent> rawDataList)
    {
        for (int i = 0; i < rawDataList.Count; i++)
        {
            if (rawDataList[i].GetComponent<PlayerMovement>()!=null)
            {
                leadingUI[i].GetComponentsInChildren<Image>()[1].sprite = boySprite;
            }
            else if (rawDataList[i].GetComponent<NPCMovement>()!=null)
            {
                leadingUI[i].GetComponentsInChildren<Image>()[1].sprite = girlSprite;
            }
            leadingUI[i].GetComponentInChildren<TMP_Text>().SetText(rawDataList[i].GetComponent<Character>().npcName);
        }
    }
    

}
