using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 盤面の操作をするためのクラス
/// </summary>
public class GameManagement : MonoBehaviour
{
    //画面全体の横幅
    private static int _width = 10;
    //画面全体の縦間隔
    private static int _height = 20;

    /// <summary>
    /// グリッド用
    /// </summary>
    public Transform[,] _grid = new Transform[_width, _height];

    /// <summary>
    /// スポーンの時にこれを呼び出して今の座標を記録する
    /// </summary>
    public void AddGrid(GameObject NowObject)
    {
        foreach (Transform t in NowObject.transform)
        {
            int roundX = Mathf.RoundToInt(t.transform.position.x);
            int roundY = Mathf.RoundToInt(t.transform.position.y);

            _grid[roundX, roundY] = t;

            Debug.Log($"pos=({t.transform.position.x},{t.transform.position.y}) → round=({roundX},{roundY})");
        }

        //確認用
        string result = "";

        for (int y = _grid.GetLength(1) - 1; y >= 0; y--)
        {
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                if (_grid[x, y] == null)
                    result += " . ";
                else
                    result += " X ";
            }

            result += "\n";
        }
        
        Debug.Log(result);
    }
}
