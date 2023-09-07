using Photon.Pun;
using TMPro;

public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    TextMeshPro _textMeshPro;

    // チーム内でユニークなIDが割り当てられる
    // プレイヤー名、スコア、チームID等
    // 各プレイヤーごとに値を持たせる

    // Start is called before the first frame update
    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        // プレイヤー名とプレイヤーIDを表示する
        _textMeshPro.text = $"{photonView.Owner.NickName}({photonView.OwnerActorNr})";
    }
}
