using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GamePlayer : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        // Object.Instantiate�̌�Ɉ�x�����K�v�ȏ������������s��
    }

    // Start is called before the first frame update
    void Start()
    {
        // ������Ɉ�x����(OnEnable�̌��)�Ă΂��A�����ŏ������������s���ꍇ�͗v������
    }

    public override void OnEnable()
    {
        base.OnEnable();

        // PhotonNetwork.Instantiate�̐���������ɕK�v�ȏ������������s��
    }

    public override void OnDisable()
    {
        base.OnDisable();

        // PhotonNetwork.Destroy�̔j�������O�ɕK�v�ȏI���������s��
    }

}
