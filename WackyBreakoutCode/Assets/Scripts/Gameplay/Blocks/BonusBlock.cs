using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    private void Start()
    {
        scorePoints = ConfigurationUtils.BonusBlockPoints;
    }
}
