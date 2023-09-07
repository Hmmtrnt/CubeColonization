using Photon.Pun;
using Photon.Realtime;

public class AvatarContainerChild : MonoBehaviourPunCallbacks
{
    public Photon.Realtime.Player Owner => photonView.Owner;

    public override void OnDisable()
    {
        base.OnDisable();

        var container = FindObjectOfType<AvatarContainer>();
        if(container != null)
        {
            transform.SetParent(container.transform);
        }
    }
}
