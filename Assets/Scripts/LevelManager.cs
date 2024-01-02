using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{

    private static LevelManager instance = null;
    public int Gold= 100;
    public int LivesLeft = 5;
    public int EnemyLeft = 20;
    public int NextLevel;
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager> ();
            }
            return instance;
        }
    }

    [SerializeField] private Transform towerUIParent;
    [SerializeField] private GameObject towerUIPrefab;
    [SerializeField] private Tower[] towerPrefabs;

    private List<Tower> spawnedTowers = new List<Tower> ();

    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text statusInfo;
    [SerializeField] private TMP_Text LivesText;
    [SerializeField] private TMP_Text TotalEnemyText;
    [SerializeField] private TMP_Text GoldText;

    private int _currentLives;
    private int _enemyCounter;

    // Start is called before the first frame update
    private void Start()
    {
        
        InstantiateAllTowerUI ();
    }

    // Update is called once per frame
    private void Update()
    {
        GoldText.text = "Gold: "+ Gold.ToString();
        LivesText.text = "Lives: " + LivesLeft.ToString();
        TotalEnemyText.text = "Enemys: " + EnemyLeft.ToString();
        if (Input.GetKeyDown (KeyCode.R))
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        }
       
        if (LivesLeft <= 0)
        {
            SetGameOver(false);
        }
        else if (EnemyLeft <= 0)
        {
            SetGameOver(false);

        }
       
      
       
        
    }

    private void InstantiateAllTowerUI ()
    {
        foreach (Tower tower in towerPrefabs)
        {
            GameObject newTowerUIObj = Instantiate (towerUIPrefab.gameObject, towerUIParent);
            TowerUI newTowerUI = newTowerUIObj.GetComponent<TowerUI> ();
            newTowerUI.SetTowerPrefab (tower);
            newTowerUI.transform.name = tower.name;
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(NextLevel);

    }
   
    public void SetGameOver (bool isWin)
    {
     
        statusInfo.text = isWin ? "You Win!" : "You Lose!";
        panel.gameObject.SetActive (true);
    }
}
