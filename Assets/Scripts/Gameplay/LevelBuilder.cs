using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject paddlePrefab;
    [SerializeField]
    GameObject standardBlockPrefab;
    [SerializeField]
    GameObject bonusBlockPrefab;
    [SerializeField]
    GameObject pickupBlockPrefab;

    float blockColliderWidth;
    float blockColliderHeight;

    private void Start()
    {
        Instantiate(paddlePrefab);
        SetBlockColliderDimensions();
        InstantiateRowsOfBlocks();

    }

    private void SetBlockColliderDimensions()
    {
        GameObject tempBlock = Instantiate(standardBlockPrefab);
        BoxCollider2D collider = tempBlock.GetComponent<BoxCollider2D>();
        blockColliderWidth = collider.size.x;
        blockColliderHeight = collider.size.y;
        Destroy(tempBlock);
    }

    private void InstantiateRowsOfBlocks(int rowNumber = 3)
    {
        float initPositionY = (Mathf.Abs(ScreenUtils.ScreenTop) + Mathf.Abs(ScreenUtils.ScreenBottom)) * (4.0f / 5.0f) - Mathf.Abs(ScreenUtils.ScreenTop);
        float initPositionX = Mathf.Abs(ScreenUtils.ScreenRight) - Mathf.Abs(ScreenUtils.ScreenLeft);
        int blocksInRow = (int) ((Mathf.Abs(ScreenUtils.ScreenRight) + Mathf.Abs(ScreenUtils.ScreenLeft)) / blockColliderWidth);

        for (int i = 0; i < rowNumber; i++)
        {
            InstantiateRandomBlock(initPositionX, initPositionY);

            float currentPositionX = initPositionX + blockColliderWidth;
            for(int j = 0; j < blocksInRow / 2; j++)
            {
                InstantiateRandomBlock(currentPositionX, initPositionY);
                currentPositionX += blockColliderWidth;
            }

            currentPositionX = initPositionX - blockColliderWidth;
            for (int j = 0; j < blocksInRow / 2; j++)
            {
                InstantiateRandomBlock(currentPositionX, initPositionY);
                currentPositionX -= blockColliderWidth;
            }


            initPositionY -= blockColliderHeight;
        }
    }

    private void InstantiateRandomBlock(float posX, float posY)
    {
        float probability = Random.Range(0f, 1f);
        float cumulative = ConfigurationUtils.PickupBlockProbability;
        if(probability < cumulative)
        {
            PickupBlock pickupBlock = Instantiate(pickupBlockPrefab, new Vector3(posX, posY, 0), Quaternion.identity).GetComponent<PickupBlock>();
            int pickupBlockProbability = Random.Range(0, 100);
            if(pickupBlockProbability < 50)
            {
                pickupBlock.PickupEffect = PickupEffect.Speedup;
            }
            else
            {
                pickupBlock.PickupEffect = PickupEffect.Freezer;
            }
            return;
        }
        cumulative += ConfigurationUtils.BonusBlockProbability;
        if (probability < cumulative)
        {
            Instantiate(bonusBlockPrefab, new Vector3(posX, posY, 0), Quaternion.identity).GetComponent<PickupBlock>();
            return;
        }

        Instantiate(standardBlockPrefab, new Vector3(posX, posY, 0), Quaternion.identity).GetComponent<PickupBlock>();
    }
}
