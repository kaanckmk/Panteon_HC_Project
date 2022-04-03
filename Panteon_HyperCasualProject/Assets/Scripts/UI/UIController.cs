using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject paintingPanel;
    [SerializeField] private GameObject leaderBoardPanel;

    [SerializeField] private List<GameObject> leadingUI;

    [SerializeField] private Sprite boySprite;
    [SerializeField] private Sprite girlSprite;
    
    //[SerializeField] private image

    private GameObject _target;
    
    private void Start()
    {
        _target = FindObjectOfType<PlayerMovement>().gameObject;
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
