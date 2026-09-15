using System.Collections.Generic;
using UnityEngine;

namespace calamity.Compat.Players;

public interface IGorillaPlayer
{
    public Transform Head { get; }
    public Transform Body { get; }
    public Rigidbody Rigidbody { get; }

    public PlayerPlatform Platform { get; }
    public string Name { get; }
    public string UserId { get; }
    public int ActorNumber { get; }
    public Dictionary<object, object> CustomProperties { get; }

    public bool IsLocal { get; }

    public GorillaHand GetHand(Direction direction);
}