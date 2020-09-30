using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "WackyBreakoutConfigurations.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
    static int ballLifeTime = 10;
    static int minBallSpawnSeconds = 5;
    static int maxBallSpawnSeconds = 10;
    static int standardBlockPoints = 1;
    static int bonusBlockPoints = 2;
    static int pickupBlockPoints = 2;
    static float standardBlockProbability = 0.7f;
    static float bonusBlockProbability = 0.2f;
    static float pickupBlockProbability = 0.1f;
    static int ballsPerGame = 20;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
    /// Gets the ball life time in seconds
    /// </summary>
    public int BallLifeTime
    {
        get { return ballLifeTime; }
    }

    /// <summary>
    /// Minimum new ball spawn seconds
    /// </summary>
    public int MinBallSpawnSeconds
    {
        get { return minBallSpawnSeconds; }
    }

    /// <summary>
    /// Maximum new ball spawn seconds
    /// </summary>
    public int MaxBallSpawnSeconds
    {
        get { return maxBallSpawnSeconds; }
    }

    /// <summary>
    /// Points obtained for standard blocks
    /// </summary>
    public int StandardBlockPoints
    {
        get { return standardBlockPoints; }
    }

    /// <summary>
    /// Points obtained for bonus blocks
    /// </summary>
    public int BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    /// <summary>
    /// Points obtained for pickup blocks
    /// </summary>
    public int PickupBlockPoints
    {
        get { return pickupBlockPoints; }
    }

    /// <summary>
    /// Probability for standard blocks
    /// </summary>
    public float StandardBlockProbability
    {
        get { return standardBlockProbability; }
    }

    /// <summary>
    /// Probability for bonus blocks
    /// </summary>
    public float BonusBlockProbability
    {
        get { return bonusBlockProbability; }
    }

    /// <summary>
    /// Probability for pickup blocks
    /// </summary>
    public float PickupBlockProbability
    {
        get { return pickupBlockProbability; }
    }

    /// <summary>
    /// Number of balls available per game
    /// </summary>
    public int BallsPerGame
    {
        get { return ballsPerGame; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader file = null;
        try
        {
            file = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            file.ReadLine();
            string[] values = file.ReadLine().Split(';');
            paddleMoveUnitsPerSecond = float.Parse(values[0]);
            ballImpulseForce = float.Parse(values[1]);
            ballLifeTime = int.Parse(values[2]);
            minBallSpawnSeconds = int.Parse(values[3]);
            maxBallSpawnSeconds = int.Parse(values[4]);
            standardBlockPoints = int.Parse(values[5]);
            bonusBlockPoints = int.Parse(values[6]);
            pickupBlockPoints = int.Parse(values[7]);
            standardBlockProbability = float.Parse(values[8]);
            bonusBlockProbability = float.Parse(values[9]);
            pickupBlockProbability = float.Parse(values[10]);
            ballsPerGame = int.Parse(values[11]);

        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
        finally
        {
            if(file != null)
            {
                file.Close();
            }
        }
    }

    #endregion
}
