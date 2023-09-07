using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class OwnershipSample : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        // ���g���Ǘ��҂��ǂ����𔻒肷��
        if (photonView.IsMine)
        {
            // ���L�҂��擾����
            Photon.Realtime.Player owner = photonView.Owner;
            // ���L�҂̃v���C���[����ID���R���\�[���ɏo�͂���
            Debug.Log($"{owner.NickName}({photonView.OwnerActorNr})");
        }

        // RoomObject�v���n�u���烋�[���I�u�W�F�N�g�𐶐�����
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.InstantiateRoomObject("NetworkObject", Vector3.zero, Quaternion.identity);
        }
    }
}