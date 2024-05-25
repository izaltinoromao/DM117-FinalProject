using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelUiController : MonoBehaviour
{

    [SerializeField] TMP_Text enemyCount;
    [SerializeField] int startingEnemies;

    public static LevelUiController Instance;

    private int deathCount;

    public int DeathCount
    {
        get { return deathCount; }
        set 
        { 
            deathCount = value;
            int alive = startingEnemies - deathCount;
            enemyCount.text = $"Enemies Alive: {alive}";
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        enemyCount.text = $"Enemies Alive: {startingEnemies}";
    }

    void Update()
    {
        
    }
}
