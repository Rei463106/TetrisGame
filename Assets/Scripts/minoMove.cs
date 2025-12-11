using UnityEngine;

/// <summary>
/// minoを動かすためのクラス
/// </summary>
public class minoMove : MonoBehaviour
{
    [Header("落ちるまでの間隔")]
    [SerializeField] private float _prepareTime;
    [Header("横間隔")]
    [SerializeField] private int Width;
    [Header("Spawn")]
    [SerializeField] private Spawn _spawn;

    /// <summary>
    /// インターバル計測用
    /// </summary>
    private float _intervalTime;

    /// <summary>
    /// minoのX座標取得用
    /// </summary>
    private int _roundX;

    /// <summary>
    /// minoのY座標取得用
    /// </summary>
    private int _roundY;

    private void Update()
    {
        _intervalTime += Time.deltaTime;

        if (_prepareTime - _intervalTime <= 0)
        {
            if (JudgeGround())
            {
                //自動で下に動くようにする
                transform.position += new Vector3(0, -1, 0);
            }
            _intervalTime = 0;
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    public void mMove(Vector3 moveInputValue)
    {
        transform.position += moveInputValue;

        if (!JudgeEdge())
        {
            //現在のX座標を取得して、roundX<=0なら、そのBindingを書き換える…みたいな
            if (_roundX <= 0)
            {
                Debug.Log("0");
            }
            else if (_roundX > Width)
            {
                Debug.Log("Width");
            }
        }
        else if (JudgeEdge())
        {
            //キーのバインディングを復活させる
            Debug.Log("復活！");
        }
    }

    /// <summary>
    /// 回転
    /// </summary>
    public void mRotation(Vector3 rotationInputValue)
    {
        transform.Rotate(0f, 0f, rotationInputValue.x * 90);
    }

    /// <summary>
    /// 下まで行ったら動きを止める
    /// </summary>
    public bool JudgeGround()
    {
        foreach (Transform t in transform)
        {
            _roundY = Mathf.RoundToInt(t.transform.position.y);

            if (_roundY <= 0)
                return false;
        }
        return true;
    }

    /// <summary>
    /// 左右飛び出ないようにする
    /// </summary>
    public bool JudgeEdge()
    {
        foreach (Transform t in transform)
        {
            _roundX = Mathf.RoundToInt(t.transform.position.x);

            if (_roundX <= 0 || _roundX > Width) return false;
        }
        return true;
    }
}
