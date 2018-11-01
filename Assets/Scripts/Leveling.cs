using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leveling : MonoBehaviour {

    public int currentLevel;

    public int currentExp;

    public int[] toLevelUp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (currentExp >= toLevelUp[currentLevel])
        {
            currentLevel++;
        }
		
	}

    internal void AddExperience(int expToAdd)
    {
        currentExp += expToAdd;
    }
}
