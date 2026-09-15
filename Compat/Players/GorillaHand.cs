using UnityEngine;

namespace calamity.Compat.Players;

public sealed class GorillaHand
{
    public Vector3 Position;
    public Quaternion Rotation;

    public Vector3 Up;
    public Vector3 Right;
    public Vector3 Forward;

    public Transform HandTransform; // added as a fallback for parenting or api i forgot to implement   
}