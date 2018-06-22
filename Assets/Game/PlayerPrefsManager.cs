using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {
    const string MASTER_VOL_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static float DefaultVolume = 0.8f;
    public static float DefaultDifficulty = 2f;

    // VOLUME
    public static void SetMasterVolume (float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOL_KEY, volume);
        }
        else {
            Debug.LogError("Volume out of range.");
        } 
    }

    public static float GetMasterVolume () {
        return PlayerPrefs.GetFloat(MASTER_VOL_KEY);
    }

    // LEVEL UNLOCK
    public static void UnlockLevel (int level) {
        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // Use 1 for true
        }
        else {
            Debug.LogError("Trying to unlock nonexistant level.");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            return true;
            }
        else {
            Debug.LogError("Trying to unlock nonexistant level.");
            return false;
            }
        }

    // DIFFICULTY
    public static void SetDifficulty (float difficulty) {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range.");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
