using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public List <int> unlocked_levels;
    public int current_level;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UnlockNextLevel() {
        GameObject[] levels = GameObject.FindGameObjectsWithTag("Level");
        var next_level = current_level + 1;
        unlocked_levels.Add(next_level);
    }
}
