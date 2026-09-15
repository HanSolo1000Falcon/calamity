using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;
using InvalidDataException = System.IO.InvalidDataException;

namespace calamity.Compat.Players;

public class LocalGorillaPlayer : MonoBehaviour, IGorillaPlayer
{
    public static LocalGorillaPlayer Instance { get; private set; }

    public Transform Head { get; private set; }
    public Transform Body { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    public PlayerPlatform Platform { get; private set; }
    public string Name { get; private set; }
    public string UserId { get; private set; }
    public int ActorNumber { get; private set; }
    public Dictionary<object, object> CustomProperties { get; private set; }

    public bool IsLocal { get; } = true;

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

    private void Start()
    {
        UserId = NetworkSystem.Instance.LocalPlayer.UserId;
    }

    public void SetCustomProperties(Dictionary<object, object> newProperties)
    {
        var properties = new Hashtable();
        foreach (var property in newProperties)
        {
            properties.Add(property.Key, property.Value);
        }
        PhotonNetwork.LocalPlayer.SetCustomProperties(properties);
    }
}