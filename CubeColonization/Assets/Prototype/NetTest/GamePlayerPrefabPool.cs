using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

// IPunPrefabPool�C���^�[�t�F�[�X����������
public class GamePlayerPrefabPool : MonoBehaviour, IPunPrefabPool
{
    [SerializeField]
    private GamePlayer _gamePlayerPrefab = default;

    private Stack<GamePlayer> inactiveObjectPool = new Stack<GamePlayer>();

    private void Start()
    {
        // �l�b�g���[�N�I�u�W�F�N�g�̐����E�j�����s���������A���̃N���X�̏����ɍ����ւ���
        PhotonNetwork.PrefabPool = this;
    }

    GameObject IPunPrefabPool.Instantiate(string prefabId, Vector3 position, Quaternion rotation)
    {
        switch (prefabId)
        {
            case "GamePlayer":
                GamePlayer player;

                if(inactiveObjectPool.Count > 0)
                {
                    player = inactiveObjectPool.Pop();
                    player.transform.SetPositionAndRotation(position, rotation);
                }
                else
                {
                    player = Instantiate(_gamePlayerPrefab, position, rotation);
                    player.gameObject.SetActive(false);
                }

                return player.gameObject;
        }
        return null;
    }

    void IPunPrefabPool.Destroy(GameObject gameObject)
    {
        var player = gameObject.GetComponent<GamePlayer>();

        // Photon Network�̓����Ŋ��ɔ�A�N�e�B�u��Ԃɂ���Ă���̂ŁA�ȉ��̏����͕s�v
        // player.gameObject.SetActive(false);

        inactiveObjectPool.Push(player);
    }

}
