using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    public List<LevelManager> levels;
    public List<Transform> levelsTransform;
    public Transform current;
    public LevelManager currentLevel;
    public LevelManager oldLevel;
    public int currentLevelIndex;
    public int money;
    public Transform gameStartPos;
    #region Singleton
    public static SceneManager instance;

    void Awake()
    {
        instance = this;
        money = PlayerPrefs.GetInt("money",0);
        currentLevelIndex = PlayerPrefs.GetInt("Level", currentLevelIndex);
        current= Instantiate(levelsTransform[currentLevelIndex], gameStartPos.position, Quaternion.identity);
        
    }
    #endregion

    public void CreateNextLevel()
    {
        oldLevel = current.GetComponent<LevelManager>();
        if (currentLevelIndex > levelsTransform.Count)
        {
           
            Transform newPos = levels[Random.Range(0, levels.Count)].levelEnd;
            current = Instantiate(levelsTransform[Random.Range(0,levels.Count)], newPos.transform.position, Quaternion.identity);
            currentLevelIndex = levelsTransform.IndexOf(current);
            currentLevel = current.GetComponent<LevelManager>();
        }
        else
        {
            oldLevel = current.GetComponent<LevelManager>();
            Transform newPos = levels[currentLevelIndex].levelEnd;
            current = Instantiate(levelsTransform[currentLevelIndex + 1], newPos.transform.position, Quaternion.identity);
            currentLevel = current.GetComponent<LevelManager>();
        }
   
    }
    public void DestroyOldLevel()
    {
        currentLevelIndex++;

        oldLevel.gameObject.SetActive(false);
        PlayerPrefs.SetInt("Level", currentLevelIndex);
    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
