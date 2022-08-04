using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public List<LevelManager> levels;
    public List<Transform> levelsTransform;
    public Transform current;
    public int currentLevelIndex;
    #region Singleton
    public static SceneManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

   public void CreateNextLevel()
    {
        Transform newPos = levels[currentLevelIndex].levelEnd;
        current = Instantiate(levelsTransform[currentLevelIndex++],newPos.transform.position,Quaternion.identity);
    }
}
