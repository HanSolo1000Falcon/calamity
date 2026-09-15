using UnityEngine;

namespace calamity.Compat.Players;

public interface IGorillaPlayer
{
    public Transform Head { get; }
    public Transform Body { get; }
    public Rigidbody Rigidbody { get; }

    public GorillaHand GetHand(Direction direction);
}