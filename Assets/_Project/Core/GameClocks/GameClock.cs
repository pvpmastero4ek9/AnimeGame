using UnityEngine;

namespace Core.GameClocks
{
    public class GameClock : MonoBehaviour
    {
        [SerializeField] private int _startTimeGameInHourse;
        [SerializeField] private int _timeAccelerationMultiplier = 1;

        public float Seconds { get; private set; }
        public int Minutes { get; private set; }
        public int Hours { get; private set; }

        public delegate void TimeChangedDelegate();
        public event TimeChangedDelegate TimeChanged;
        
        private void Start() 
        {
            Hours = _startTimeGameInHourse;
            Minutes = 0;
            Seconds = 0;
        }

        private void Update()
        {
            Seconds += Time.deltaTime * _timeAccelerationMultiplier; 

            if (Seconds >= 60)
            {
                Seconds = 0;
                Minutes += 1;

                if (Minutes >= 60)
                {
                    Minutes = 0;
                    Hours += 1;

                    if (Hours >= 24)
                    {
                        Hours = 0;
                    }
                }
            }

            TimeChanged?.Invoke();  
        }
    }
}
