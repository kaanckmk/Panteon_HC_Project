using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;

public class RaceLeadingCalculator : MonoBehaviour
{
    public GameEvent OnLeadingChanged;
    
    private List<Character> _characters;
    private List<Character> _leadings;
    private List<Character> _tmpLeadings;
    private List<DataPassWithEvent> passableEventList;
    private void Awake()
    {
        _characters = new List<Character>();
        _leadings = new List<Character>();
        _tmpLeadings = new List<Character>();
        passableEventList = new List<DataPassWithEvent>();
        
        var characterArray = FindObjectsOfType<Character>();
        
        foreach (Character character in characterArray)
        {
            _characters.Add(character);
        }

        //sorting
        _characters = _characters.OrderByDescending(x => x.transform.position.z).ToList();

        //add leadings to list
        for (int i = 0; i < 3; i++)
        {
            _leadings.Add(_characters[i]);
        }
    }
    
    void Update()
    {
        _tmpLeadings.Clear();
        passableEventList.Clear();
        
        _characters = _characters.OrderByDescending(x => x.transform.position.z).ToList();
        
        for (int i = 0; i < 3; i++)
        {
            _tmpLeadings.Add(_characters[i]);
        }
        if (!CheckMatch(_leadings,_tmpLeadings))
        {
            _leadings.Clear();
            for (int i = 0; i < _tmpLeadings.Count; i++)
            {
                _leadings.Add(_tmpLeadings[i]);
                passableEventList.Add(_leadings[i].gameObject.GetComponent<DataPassWithEvent>());
            }
            //Debug.Log(_leadings[0].npcName + " " +_leadings[1].npcName + " " + _leadings[2].npcName);

            OnLeadingChanged.sentPassableList = passableEventList;
            OnLeadingChanged.Raise();
        }
        
    }

    private bool CheckMatch(List<Character> l1, List<Character> l2)
    { 
        for (int i = 0; i < l1.Count; i++) 
        {
            if (l1[i].npcName != l2[i].npcName)
                return false;
        }
        return true;
    }
    public List<Character> GetLeadings()
    {
        return _leadings;
    }
}
