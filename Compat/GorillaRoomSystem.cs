using System;
using System.Collections.Generic;
using calamity.Compat.Players;
using GorillaLocomotion;

namespace calamity.Compat;

public static class GorillaRoomSystem
{
    public static string RoomName { get; private set; }
    public static bool InPublicRoom { get; private set; }
    public static bool InRoom { get; private set; }

    public static event Action OnJoinedRoomEvent;
    public static event Action OnLeftRoomEvent;

    public static event Action<GorillaPlayer> OnPlayerJoinedRoomEvent;
    public static event Action<GorillaPlayer> OnPlayerLeftRoomEvent; 

    public static int MaxPlayers { get; private set; }

    public static IReadOnlyList<IGorillaPlayer> Players => _activePlayers.AsReadOnly();
    private static List<IGorillaPlayer> _activePlayers = [];
    private static List<IGorillaPlayer> _players = [];

    public static void Setup()
    {
        GTPlayer.Instance.AddComponent<LocalGorillaPlayer>();
        NetworkSystem.Instance.OnJoinedRoomEvent.Add(() =>
        {
            InRoom = true;
            InPublicRoom = NetworkSystem.Instance.CurrentRoom.isPublic;
            RoomName = NetworkSystem.Instance.RoomName;
            MaxPlayers = NetworkSystem.Instance.CurrentRoom.MaxPlayers;

            OnJoinedRoomEvent?.Invoke();
        });
    }
}