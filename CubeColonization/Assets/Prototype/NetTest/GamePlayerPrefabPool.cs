using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

// IPunPrefabPoolインターフェースを実装する
public class GamePlayerPrefabPool : MonoBehaviour, IPunPrefabPool
{
    [SerializeField]
    private GamePlayer _gamePlayerPrefab = default;

    private Stack<GamePlayer> inactiveObjectPool = new Stack<GamePlayer>();

    private void Start()
    {
        // ネットワークオブジェクトの生成・破棄を行う処理を、このクラスの処理に差し替える
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

        // Photon Networkの内部で既に非アクティブ状態にされているので、以下の処理は不要
        // player.gameObject.SetActive(false);

        inactiveObjectPool.Push(player);
    }

}
