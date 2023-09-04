using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 隣に移動するのにかかる時間
    public float _rotationPeriod = 0.3f;
    // Cubeの辺の長さ
    public float _sideLength = 1f;

    // Cubeが回転中かどうかを検出するフラグ
    bool _isRotate = false;
    // 回転方向フラグ
    float _directionX = 0;
    float _directionZ = 0;

    // 回転前のCubeの位置
    Vector3 _startPos;
    // 回転中の時間経過
    float _rotationTime = 0;
    // 重心の起動半径
    float _radius;
    // 回転前のCubeのクォータニオン
    Quaternion _fromRotation;
    // 回転後のCubeのクォータニオン
    Quaternion _toRotation;

    // 左右か
    private bool _isLeftRight;
    // 上下か
    private bool _isUpDown;

    // Start is called before the first frame update
    void Start()
    {
        // 重心の回転起動半径を計算
        _radius = _sideLength * Mathf.Sqrt(2f) / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;
        float y = 0;

        

        // キー入力
        x = Input.GetAxisRaw("Horizontal");
        if(x == 0)
        {
            y = Input.GetAxisRaw("Vertical");
        }

        Debug.Log(x);

        // キー入力がある　かつ　Cubeが回転中でない場合　Cubeを回転する
        if ((x != 0 || y != 0) && !_isRotate)
        {
            // 回転方向セット(x,yどちらかは必ず0)
            _directionX = -x;
            _directionZ = y;
            // 回転前の座標を保持
            _startPos = transform.position;
            // 回転前のクォータニオンを保持
            _fromRotation = transform.rotation;
            // 回転方向に90度回転させる
            transform.Rotate(_directionZ * 90, 0, _directionX * 90, Space.World);
            // 回転後のクォータニオンを保持
            _toRotation = transform.rotation;
            // CubeのRotationを回転前に戻す
            transform.rotation = _fromRotation;
            // 回転中の経過時間を0に
            _rotationTime = 0;
            // 回転中フラグを立てる
            _isRotate = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isRotate)
        {
            // 経過時間を増やす
            _rotationTime += Time.fixedDeltaTime;
            // 回転の時間に対する今の時間経過の割合
            float ratio = Mathf.Lerp(0, 1, _rotationTime / _rotationPeriod);
            
            // 移動
            // 回転角をラジアンで
            float thetaRad = Mathf.Lerp(0,Mathf.PI / 2f, ratio);
            // X軸の移動距離
            float distanceX = -_directionX * _radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));
            // Y軸の移動距離
            float distanceY = _radius * (Mathf.Sin(45f * Mathf.Deg2Rad + thetaRad) - Mathf.Sin(45f * Mathf.Deg2Rad));
            // Z軸の移動距離
            float distanceZ = _directionZ * _radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));
            // 現在の位置をセット
            transform.position = new Vector3(_startPos.x + distanceX, _startPos.y + distanceY, _startPos.z + distanceZ);

            // 回転
            // Quaternion.Lerpで現在の回転角をセット
            transform.rotation = Quaternion.Lerp(_fromRotation, _toRotation, ratio);

            // 移動・回t年修了時に各パラメータを初期化、isRotateフラグを下ろす
            if(ratio == 1)
            {
                _isRotate = false;
                _directionX = 0;
                _directionZ = 0;
                _rotationTime = 0;
            }
        }

    }
}
