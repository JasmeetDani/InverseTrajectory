using UnityEngine;

public static class Constants
{
    public const float G = 9.81f;
    
    public const float Bounce_Damping = 0.6f;

    public const float Sleep_Velocity = 0.5f;


    public const float BouncePointMoveDistance = 0.2f;


    // Bot hit time to front wall in case of direct hit
    public const float TimeToHitFrontWallInCaseOfDirectHit = 0.5f;


    // The front wall hit height below which the hit AI algorithm will attempt a correction
    // It is set to 0.48 (Tin height) + 1 / 3 (1.78 - 0.48) (Area between service line and tin)
    public const float FrontWallLowHitHeightCorrectionThreshold = 0.9133f;
    
    // The front wall hit height above which the hit AI algorithm will attempt a correction
    // It is set to 1.78 (Service line height) + 2 / 3 (4.57 - 1.78) (Area between service line and front wall line)
    public const float FrontWallHighHitHeightCorrectionThreshold = 3.64f;


    // The correction time percentage range applied if the hit AI algorithm attempts a correction for a low height
    public static readonly float[] FrontWallLowHitTimeCorrection = { 1.1f, 1.3f };
    
    // The correction time percentage range applied if the hit AI algorithm attempts a correction for a high height
    public static readonly float[] FrontWallHighHitTimeCorrection = { 0.1f, 0.3f };
}