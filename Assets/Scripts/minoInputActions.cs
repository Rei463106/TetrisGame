using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 入力管理を行うクラス
/// </summary>
public class minoInputActions : MonoBehaviour
{
    [Header("minoActions")]
    [SerializeField] private MinoAction _minoAction;
    [Header("minoMove")]
    [SerializeField] private minoMove _minoMove;

    /// <summary>
    /// 移動キーのコールバックを入れる
    /// </summary>
    private Vector2 _moveInputValue;

    /// <summary>
    /// 回転キーのコールバックを入れる
    /// </summary>
    private Vector2 _rotationInputValue;

    private void OnEnable()
    {
        //初期化
        _minoAction = new MinoAction();
        _minoAction.Enable();

        //イベント登録
        _minoAction.Move.minoMove.started += HandleMove;
        _minoAction.Move.minoRotation.started += HandleRotation;
    }

    private void OnDisable()
    {
        _minoAction.Move.minoMove.started -= HandleMove;
        _minoAction.Move.minoRotation.started -= HandleRotation;
    }

    /// <summary>
    /// 左右移動＆下移動用
    /// </summary>
    /// <param name="context"></param>
    private void HandleMove(InputAction.CallbackContext context)
    {
        if (this.gameObject.tag == "usedMino")
            return;
        _moveInputValue = context.ReadValue<Vector2>();
        _minoMove.mMove(_moveInputValue);
    }

    /// <summary>
    /// 回転用
    /// </summary>
    /// <param name="context"></param>
    private void HandleRotation(InputAction.CallbackContext context)
    {
        if (this.gameObject.tag == "usedMino")
            return;
        _rotationInputValue = context.ReadValue<Vector2>();
        _minoMove.mRotation(_rotationInputValue);
    }
}
