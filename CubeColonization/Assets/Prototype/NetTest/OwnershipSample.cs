using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class OwnershipSample : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        // 自身が管理者かどうかを判定する
        if (photonView.IsMine)
        {
            // 所有者を取得する
            Photon.Realtime.Player owner = photonView.Owner;
            // 所有者のプレイヤー名とIDをコンソールに出力する
            Debug.Log($"{owner.NickName}({photonView.OwnerActorNr})");
        }

        // RoomObjectプレハブからルームオブジェクトを生成する
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.InstantiateRoomObject("NetworkObject", Vector3.zero, Quaternion.identity);
        }
    }
}