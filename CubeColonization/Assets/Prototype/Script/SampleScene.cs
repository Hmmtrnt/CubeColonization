using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// MonoBehaviourPunCallbacks:PUNのコールバックを受け取れる
public class SampleScene : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーの名前を設定
        PhotonNetwork.NickName = "Player";

        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時のコールバック
    public override void OnConnectedToMaster()
    {
        // "Room"という名前のルームに参加する(ルームが存在しなければ作成して参加する)
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    // サーバーへの接続が成功した時のコールバック
    public override void OnJoinedRoom()
    {
        // ランダムな座標に自身のアバター(ネットワークオブジェクト)を生成する
        Vector3 position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("Avatar", position, Quaternion.identity);
        
    }
}
