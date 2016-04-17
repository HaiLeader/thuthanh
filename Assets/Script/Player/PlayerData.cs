﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PlayerType{
    TYPE1,
    TYPE2,
    TYPE3,
    TYPE4,
    TYPE5,
    TYPE6
}

public class PlayerData : MonoBehaviour {

	public PlayerType playerType;
    public List<PlayerLevel> levels;
    private PlayerLevel currentLevel;

    public PlayerLevel CurrentLevel {

        get {
            return currentLevel;
        }

        set {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            GameObject levelVisualization = levels[currentLevelIndex].visualization;
            for (int i = 0; i < levels.Count; i++) {
                if (levelVisualization != null) {
                    if (i == currentLevelIndex)
                    {
                        levels[i].visualization.SetActive(true);
                    }
                    else {
                        levels[i].visualization.SetActive(false);
                    }
                }
            }
        }
    }

    void OnEnable() {
        CurrentLevel = levels[0];
    }

    public PlayerLevel getNextLevel() {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            return levels[currentLevelIndex + 1];
        }
        else {
            return null;
        }
    }

    public void increaseLevel() {
        int currentLevelIndex = levels.IndexOf(currentLevel);

        if (currentLevelIndex < levels.Count - 1) {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }
}
