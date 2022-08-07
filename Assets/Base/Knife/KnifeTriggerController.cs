using System;
using UnityEngine;

public class KnifeTriggerController : MonoBehaviour
{
    private const string groundStr = "Ground";
    private const string cutStr = "Cut";
    private const string finishStr = "Finish";
    private const string obstacleStr = "Obstacle";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(groundStr) || other.CompareTag(obstacleStr))
        {
            KnifeBaseController.I.OnGroundTrigger();
            UIManager.I.OnFailGame();
        }
        else if (other.CompareTag(cutStr))
        {
            KnifeSliceController.I.OnCutObject(other);
        }
        else if (other.CompareTag(finishStr))
        {
            KnifeBaseController.I.OnFinishTrigger(other);
            LevelManager.I.NextLevelData();
            UIManager.I.OnFailGame();
        }
    }
}
