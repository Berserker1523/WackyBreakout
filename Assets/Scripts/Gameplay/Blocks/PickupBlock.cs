using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBlock : Block
{
    [SerializeField]
    Sprite freezerBlockSprite;
    [SerializeField]
    Sprite SpeedupBlockSprite;

    PickupEffect pickupEffect;

    public PickupEffect PickupEffect
    {
        set
        {
            pickupEffect = value;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (pickupEffect == PickupEffect.Speedup)
            {
                spriteRenderer.sprite = SpeedupBlockSprite;
            }
            else
            {
                spriteRenderer.sprite = freezerBlockSprite;
            }
        }
    }

    private void Start()
    {
        scorePoints = ConfigurationUtils.PickupBlockPoints;
    }
}
