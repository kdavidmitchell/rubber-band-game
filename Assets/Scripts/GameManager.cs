using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    private EnemyParams _enemyParams;
    private PlayerStats _playerStats;
    private GameObject _player;
    private bool _playerHit;
    private TextMeshProUGUI _playerScoreValue;
    private Candidate _candidate1;
    private Candidate _candidate2;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        _candidate1 = new Candidate();
        _candidate2 = new Candidate();
        _enemyParams = new EnemyParams();
        _playerStats = new PlayerStats();
        _player = GameObject.Find("Knight");
        _playerHit = false;
        _playerScoreValue = GameObject.Find("PlayerScoreValue").GetComponent<TextMeshProUGUI>();
        UpdatePlayerScore();
    }

    // Update is called once per frame
    void Update()
    {
        this.PlayerStats.TimeSinceLastHit += Time.deltaTime;
        if (this.PlayerHit)
        {
            this.PlayerStats.TimeSinceLastHit = 0;
            this.PlayerHit = false;
        }
    }

    public void PlayerDeath()
    {
        this.PlayerStats.Deaths += 1;
        this.PlayerStats.Kills = 0;
        SceneManager.LoadScene("Demo");
    }

    public void PlayerKill()
    {
        this.PlayerStats.Kills += 1;
        UpdatePlayerScore();
    }

    private void UpdatePlayerScore()
    {
        _playerScoreValue.text = this.PlayerStats.Kills.ToString();
    }

    // enemyfitness = (10000/D(player, enemy)) - 10000*Damage(player);
    public void Evaluate(GameObject enemy, int damageSuccess) 
    {  
        double max = 10000;
        double fitness = max;
        double distance = Vector3.Distance(_player.transform.position , enemy.transform.position);
        distance = (distance < 1) ? 1 : distance;
        distance = (distance > max) ? max : distance;
        fitness /= distance;
        fitness -= max*damageSuccess;

        if (fitness > _candidate1.Fitness) 
        {
            // Save candidate 1 in candidate 2.-
            _candidate2.CandidateObject = _candidate1.CandidateObject;
            _candidate2.Fitness = _candidate1.Fitness;
            // save newest max candidate as candidate 1.
            _candidate1.CandidateObject = enemy;
            _candidate1.Fitness = fitness;
            Debug.Log(_candidate1.Fitness.ToString() +  " This is candidate 1");
            Debug.Log(_candidate2.Fitness.ToString() + " This is candidate 2");
        }
    }


    public EnemyParams EnemyParams 
    {
        get { return _enemyParams; }
        set { _enemyParams = value; }
    }

    public PlayerStats PlayerStats
    {
        get { return _playerStats; }
        set { _playerStats = value; }
    }

    public bool PlayerHit 
    {
        get { return _playerHit; }
        set { _playerHit = value; }
    }
}
