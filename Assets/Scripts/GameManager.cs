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
        _enemyParams = new EnemyParams();
        _playerStats = new PlayerStats();
        _player = GameObject.Find("Player");
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
