using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// MonoBehaviourPunCallbacks:PUNのコールバックを受け取れる
public class SampleScene : MonoBehaviourPunCallbacks
{
    // ルームの名前.
    string _roomName = "Room";

    // Start is called before the first frame update
    private void Start()
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
        // _roomName  : ルーム名
        PhotonNetwork.JoinOrCreateRoom(_roomName, new RoomOptions(), TypedLobby.Default);
    }

    // ネットワーク上で同期させるゲームオブジェクトはネットワークオブジェクト
    // 自身または他プレイヤーでインスタンスを生成すると他プレイヤーまたは自身のインスタンスも生成する
    // プレイヤーだけでなく敵やNPC等のゲームオブジェクトも同期に使える

    // サーバーへの接続が成功した時のコールバック
    public override void OnJoinedRoom()
    {
        // ランダムな座標に自身のアバター(ネットワークオブジェクト)を生成する
        Vector3 position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("Avatar", position, Quaternion.identity);
    }
}
