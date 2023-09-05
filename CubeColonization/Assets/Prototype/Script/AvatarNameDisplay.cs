using Photon.Pun;
using TMPro;

public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    TextMeshPro _textMeshPro;

    // Start is called before the first frame update
    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        // �v���C���[���ƃv���C���[ID��\������
        _textMeshPro.text = $"{photonView.Owner.NickName}({photonView.OwnerActorNr})";
    }
}
