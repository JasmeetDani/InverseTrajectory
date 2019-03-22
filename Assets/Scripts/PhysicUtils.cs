using UnityEngine;

public static class PhysicUtils
{
    public static Vector3 BounceFromPlane(Vector3 InitialVelocity, Vector3 FaceNormal)
    {
        return Vector3.Reflect(InitialVelocity * Constants.Bounce_Damping, FaceNormal);
    }
}