using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スポーン処理を書く
/// </summary>
public class Spawn : MonoBehaviour
{
    [Header("スポーンする地点")]
    [SerializeField] private Transform _spawnGameObject;
    [Header("スポーンするもののリスト")]
    [SerializeField] private List<GameObject> _spawnList = new List<GameObject>();
    [Header("minoMove")]
    [SerializeField] private minoMove _minoMove;
    [Header("Gamemanagement")]
    [SerializeField] private GameManagement _gameManagement;

    /// <summary>
    /// 現在生成されているmino
    /// </summary>
    private GameObject _nowObject;

    /// <summary>
    /// 一回だけ生成するためのフラグ
    /// </summary>
    private bool _isSpawnScheduled = false;

    private void Start()
    {
        StartInstantiate();
    }

    private void Update()
    {
        if (!_nowObject.GetComponent<minoMove>().JudgeGround())
        {
            // まだ予約していない時だけ実行
            if (!_isSpawnScheduled)
            {
                _isSpawnScheduled = true; // 再実行を防ぐ
                _nowObject.gameObject.tag = "usedMino";//タグを変えて、動かないようにする
                _gameManagement.AddGrid(_nowObject);//現在位置の記録
                
                //1秒後に生成を開始する
                Invoke("StartInstantiate", 1);
            }
        }
    }

    /// <summary>
    /// スポーン処理
    /// </summary>
    public void StartInstantiate()
    {
        int random = Random.Range(0, 6);
        _nowObject = Instantiate(_spawnList[random], _spawnGameObject.position, Quaternion.identity);
        _isSpawnScheduled = false;
    }
}
