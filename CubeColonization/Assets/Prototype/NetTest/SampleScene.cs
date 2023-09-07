using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// MonoBehaviourPunCallbacks:PUN�̃R�[���o�b�N���󂯎���
public class SampleScene : MonoBehaviourPunCallbacks
{
    // ���[���̖��O.
    string _roomName = "Room";

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�̖��O��ݒ�
        PhotonNetwork.NickName = "Player";
        

        // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ��������������̃R�[���o�b�N
    public override void OnConnectedToMaster()
    {
        // "Room"�Ƃ������O�̃��[���ɎQ������(���[�������݂��Ȃ���΍쐬���ĎQ������)
        // _roomName  : ���[����
        PhotonNetwork.JoinOrCreateRoom(_roomName, new RoomOptions(), TypedLobby.Default);
    }

    // �l�b�g���[�N��œ���������Q�[���I�u�W�F�N�g�̓l�b�g���[�N�I�u�W�F�N�g
    // ���g�܂��͑��v���C���[�ŃC���X�^���X�𐶐�����Ƒ��v���C���[�܂��͎��g�̃C���X�^���X����������
    // �v���C���[�����łȂ��G��NPC���̃Q�[���I�u�W�F�N�g�������Ɏg����

    // �T�[�o�[�ւ̐ڑ��������������̃R�[���o�b�N
    public override void OnJoinedRoom()
    {
        // �����_���ȍ��W�Ɏ��g�̃A�o�^�[(�l�b�g���[�N�I�u�W�F�N�g)�𐶐�����
        Vector3 position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("Avatar", position, Quaternion.identity);
    }
}
