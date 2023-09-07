using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GamePlayer : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        // Object.Instantiateの後に一度だけ必要な初期化処理を行う
    }

    // Start is called before the first frame update
    void Start()
    {
        // 生成後に一度だけ(OnEnableの後に)呼ばれる、ここで初期化処理を行う場合は要注注意
    }

    public override void OnEnable()
    {
        base.OnEnable();

        // PhotonNetwork.Instantiateの生成処理後に必要な初期化処理を行う
    }

    public override void OnDisable()
    {
        base.OnDisable();

        // PhotonNetwork.Destroyの破棄処理前に必要な終了処理を行う
    }

}
