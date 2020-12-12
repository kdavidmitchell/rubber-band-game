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
            // Save candidate 1 in candidate 2.
            _candidate2.Speed = _candidate1.Speed;
            _candidate2.SpawnRate = _candidate1.SpawnRate;
            _candidate2.Fitness = _candidate1.Fitness;
            // save newest max candidate as candidate 1.
            _candidate1.Speed = _enemyParams.Speed;
            _candidate1.Fitness = fitness;
            _candidate1.SpawnRate = _enemyParams.SpawnRate;
            Debug.Log(_candidate1.Fitness.ToString() +  " This is candidate 1");
            Debug.Log(_candidate2.Fitness.ToString() + " This is candidate 2");
        }
        Breed();
    }

    private EnemyParams CrossOver()
    {
        EnemyParams crossOverParams = new EnemyParams();
        //cross over speed
        double crossOverSpeed = _candidate1.Speed;
        crossOverSpeed += _candidate2.Speed;
        crossOverSpeed /= 2;

        float crossOverSpawnRate = _candidate1.SpawnRate;
        crossOverSpawnRate += _candidate2.SpawnRate;
        crossOverSpawnRate /= 2;
        crossOverParams.SpawnRate = crossOverSpawnRate;
        
        return crossOverParams;
    }

    private EnemyParams Mutate() 
    {
        Debug.Log("We are mutating!");
        EnemyParams mutatedParams = new EnemyParams();
        float mutatedSpeed = _candidate1.Speed * (Random.Range(5f,30f)/10f);
        float mutatedSpawnRate = _candidate1.SpawnRate * (Random.Range(5f,12f)/10f);
        mutatedParams.Speed = mutatedSpeed;
        mutatedParams.SpawnRate = mutatedSpawnRate;
        return mutatedParams;
    }
    private void Breed()
    {
        EnemyParams newParams = new EnemyParams();
        newParams = (Random.Range(0,1) > 0) ? CrossOver() : Mutate();

        _enemyParams = newParams;
        Debug.Log("Enemy Speed" + _enemyParams.Speed.ToString());
        Debug.Log("Enemy Spawn Rate" + _enemyParams.SpawnRate.ToString());
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
