using System;
using TMPro;
using UnityEngine;

namespace Client
{
    [Serializable]
    public struct UIComponent
    {
        public int CurrentScore;
        public int CurrentWave;
        
        public TextMeshProUGUI ScoreText;
        public TextMeshProUGUI WaveText;

        public GameObject EnemyParent;
    }
}