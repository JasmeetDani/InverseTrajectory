using UnityEngine;

public static class AIUtils
{
    public static Vector3 DetermineHitVelocity_For_StraightFrontWallHit(Vector3 HitPos,
                                                                        float t1,
                                                                        Vector3 FinalLandingPos)
    {
        // xp is the point diametrically opposite to the hit point in x direction
        // xp = (2Z1X2 - Z1X1 + Z2X1) / (Z1 + Z2)
        float xp = (2 * HitPos.z * FinalLandingPos.x - HitPos.z * HitPos.x + FinalLandingPos.z * HitPos.x) /
                                                                            (HitPos.z + FinalLandingPos.z);

        // xi is the x position where the ball is supposed to hit the front wall
        float xi = (HitPos.x + xp) / 2;


        float d1x = xi - HitPos.x;

        float d2x = FinalLandingPos.x - xi;


        float t2 = (d2x * t1) / (d1x * Constants.Bounce_Damping);


        float y1 = HitPos.y;


        // yi = (gt2t2 + gt1t2c + 2y1 * (d2x / d1x)) / (2((d2x / d1x) + 1)))

        float temp1 = Constants.G * t2;

        float temp2 = d2x / d1x;

        float frontWallHitHeight = (temp1 * t2 + temp1 * t1 * Constants.Bounce_Damping +
                                    2 * y1 * temp2) / (2 * (temp2 + 1));

        float d1z = -HitPos.z;


        float u1x = d1x / t1;

        float u1z = d1z / t1;


        float d1y = frontWallHitHeight - HitPos.y;


        float u1y = (2 * d1y + Constants.G * t1 * t1) / (2 * t1);


        Vector3 retVel = Vector3.zero;

        retVel.Set(u1x, u1y, u1z);


        // Try to fix the shot if too low or too high

        if (frontWallHitHeight < Constants.FrontWallLowHitHeightCorrectionThreshold)
        {
            retVel = DetermineHitVelocity_For_StraightFrontWallHit(HitPos,
                                                                   t1 * Random.Range(Constants.FrontWallLowHitTimeCorrection[0], Constants.FrontWallLowHitTimeCorrection[1]),
                                                                   FinalLandingPos);

            return retVel;
        }

        if (frontWallHitHeight > Constants.FrontWallHighHitHeightCorrectionThreshold)
        {
            float t = t1 * Random.Range(Constants.FrontWallHighHitTimeCorrection[0], Constants.FrontWallHighHitTimeCorrection[1]);

            if (t > 0)
            {
                retVel = DetermineHitVelocity_For_StraightFrontWallHit(HitPos, t, FinalLandingPos);
            }

            return retVel;
        }


        return retVel;
    }
}