using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �ׂɈړ�����̂ɂ����鎞��
    public float _rotationPeriod = 0.3f;
    // Cube�̕ӂ̒���
    public float _sideLength = 1f;

    // Cube����]�����ǂ��������o����t���O
    bool _isRotate = false;
    // ��]�����t���O
    float _directionX = 0;
    float _directionZ = 0;

    // ��]�O��Cube�̈ʒu
    Vector3 _startPos;
    // ��]���̎��Ԍo��
    float _rotationTime = 0;
    // �d�S�̋N�����a
    float _radius;
    // ��]�O��Cube�̃N�H�[�^�j�I��
    Quaternion _fromRotation;
    // ��]���Cube�̃N�H�[�^�j�I��
    Quaternion _toRotation;

    // ���E��
    private bool _isLeftRight;
    // �㉺��
    private bool _isUpDown;

    // Start is called before the first frame update
    void Start()
    {
        // �d�S�̉�]�N�����a���v�Z
        _radius = _sideLength * Mathf.Sqrt(2f) / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;
        float y = 0;

        

        // �L�[����
        x = Input.GetAxisRaw("Horizontal");
        if(x == 0)
        {
            y = Input.GetAxisRaw("Vertical");
        }

        Debug.Log(x);

        // �L�[���͂�����@���@Cube����]���łȂ��ꍇ�@Cube����]����
        if ((x != 0 || y != 0) && !_isRotate)
        {
            // ��]�����Z�b�g(x,y�ǂ��炩�͕K��0)
            _directionX = -x;
            _directionZ = y;
            // ��]�O�̍��W��ێ�
            _startPos = transform.position;
            // ��]�O�̃N�H�[�^�j�I����ێ�
            _fromRotation = transform.rotation;
            // ��]������90�x��]������
            transform.Rotate(_directionZ * 90, 0, _directionX * 90, Space.World);
            // ��]��̃N�H�[�^�j�I����ێ�
            _toRotation = transform.rotation;
            // Cube��Rotation����]�O�ɖ߂�
            transform.rotation = _fromRotation;
            // ��]���̌o�ߎ��Ԃ�0��
            _rotationTime = 0;
            // ��]���t���O�𗧂Ă�
            _isRotate = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isRotate)
        {
            // �o�ߎ��Ԃ𑝂₷
            _rotationTime += Time.fixedDeltaTime;
            // ��]�̎��Ԃɑ΂��鍡�̎��Ԍo�߂̊���
            float ratio = Mathf.Lerp(0, 1, _rotationTime / _rotationPeriod);
            
            // �ړ�
            // ��]�p�����W�A����
            float thetaRad = Mathf.Lerp(0,Mathf.PI / 2f, ratio);
            // X���̈ړ�����
            float distanceX = -_directionX * _radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));
            // Y���̈ړ�����
            float distanceY = _radius * (Mathf.Sin(45f * Mathf.Deg2Rad + thetaRad) - Mathf.Sin(45f * Mathf.Deg2Rad));
            // Z���̈ړ�����
            float distanceZ = _directionZ * _radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));
            // ���݂̈ʒu���Z�b�g
            transform.position = new Vector3(_startPos.x + distanceX, _startPos.y + distanceY, _startPos.z + distanceZ);

            // ��]
            // Quaternion.Lerp�Ō��݂̉�]�p���Z�b�g
            transform.rotation = Quaternion.Lerp(_fromRotation, _toRotation, ratio);

            // �ړ��E��t�N�C�����Ɋe�p�����[�^���������AisRotate�t���O�����낷
            if(ratio == 1)
            {
                _isRotate = false;
                _directionX = 0;
                _directionZ = 0;
                _rotationTime = 0;
            }
        }

    }
}
