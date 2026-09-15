using System.IO;
using UnityEngine;

namespace calamity.Compat.Players;

public class LocalGorillaPlayer : MonoBehaviour, IGorillaPlayer
{
    public static LocalGorillaPlayer Instance { get; private set; }

    public Transform Head { get; private set; }
    public Transform Body { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private GorillaHand _leftHand;
    private GorillaHand _rightHand;

    public GorillaHand GetHand(Direction direction)
    {
        return direction switch
        {
            Direction.Left => _leftHand,
            Direction.Right => _rightHand,
            _ => throw new InvalidDataException(
                "The method 'LocalGorillaPlayer:GetHand(Direction)' only accepts the directions 'Direction:Left' and 'Direction:Right'!")
        };
    }

    private void Awake()
    {
        if (Instance)
        {
            Logging.LogWarning("An instance already exists, cancelling.");
            Destroy(this);
            return;
        }

        Instance = this;
    }
}