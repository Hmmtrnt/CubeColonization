using Photon.Pun;
using TMPro;

public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    TextMeshPro _textMeshPro;

    // Start is called before the first frame update
    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        // プレイヤー名とプレイヤーIDを表示する
        _textMeshPro.text = $"{photonView.Owner.NickName}({photonView.OwnerActorNr})";
    }
}
