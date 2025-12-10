using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("スポーンする地点")]
    [SerializeField] GameObject _spawnGameObject;
    [Header("スポーンするもののリスト")]
    [SerializeField] List<GameObject> _spawnList = new List<GameObject>();
    void Start()
    {
        int random = Random.Range(0, 6);
        Instantiate(_spawnList[random], _spawnGameObject.transform.position, Quaternion.identity);
    }


}
