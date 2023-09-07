using Photon.Pun;
using TMPro;

public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    TextMeshPro _textMeshPro;

    // �`�[�����Ń��j�[�N��ID�����蓖�Ă���
    // �v���C���[���A�X�R�A�A�`�[��ID��
    // �e�v���C���[���Ƃɒl����������

    // Start is called before the first frame update
    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        // �v���C���[���ƃv���C���[ID��\������
        _textMeshPro.text = $"{photonView.Owner.NickName}({photonView.OwnerActorNr})";
    }
}
