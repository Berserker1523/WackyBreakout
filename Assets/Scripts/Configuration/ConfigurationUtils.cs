using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{

    static ConfigurationData configurationData;

    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    /// <summary>
    /// Gets the ball life time in seconds
    /// </summary>
    public static int BallLifeTime
    {
        get { return configurationData.BallLifeTime; }
    }

    /// <summary>
    /// Minimum new ball spawn seconds
    /// </summary>
    public static int MinBallSpawnSeconds
    {
        get { return configurationData.MinBallSpawnSeconds; }
    }

    /// <summary>
    /// Maximum new ball spawn seconds
    /// </summary>
    public static int MaxBallSpawnSeconds
    {
        get { return configurationData.MaxBallSpawnSeconds; }
    }

    /// <summary>
    /// Points obtained for standard blocks
    /// </summary>
    public static int StandardBlockPoints
    {
        get { return configurationData.StandardBlockPoints; }
    }


    /// <summary>
    /// Points obtained for bonus blocks
    /// </summary>
    public static int BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }

    /// <summary>
    /// Points obtained for pickup blocks
    /// </summary>
    public static int PickupBlockPoints
    {
        get { return configurationData.PickupBlockPoints; }
    }

    /// <summary>
    /// Probability for pickup blocks
    /// </summary>
    public static float StandarBlockProbabilty
    {
        get { return configurationData.StandardBlockProbability; }
    }

    /// <summary>
    /// Probability for bonus blocks
    /// </summary>
    public static float BonusBlockProbability
    {
        get { return configurationData.BonusBlockProbability; }
    }

    /// <summary>
    /// Probability for pickup blocks
    /// </summary>
    public static float PickupBlockProbability
    {
        get { return configurationData.PickupBlockProbability; }
    }

    /// <summary>
    /// Number of balls available per game
    /// </summary>
    public static int BallsPerGame
    {
        get { return configurationData.BallsPerGame; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
