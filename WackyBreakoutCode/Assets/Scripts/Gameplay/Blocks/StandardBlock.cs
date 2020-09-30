using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{

    private void Start()
    {
        scorePoints = ConfigurationUtils.StandardBlockPoints;
    }
}
