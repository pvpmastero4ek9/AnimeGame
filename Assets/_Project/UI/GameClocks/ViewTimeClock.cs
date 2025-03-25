using UnityEngine;
using TMPro;
using Core.GameClocks;

namespace UI.GameClocks
{
    public class ViewTimeClock : MonoBehaviour
    {
        [SerializeField] private GameClock _gameClock;
        [SerializeField] private TMP_Text _timeClockText;

        private int _clockSeconds => (int)_gameClock.Seconds;
        private int _clockMinutes => _gameClock.Minutes;
        private int _clockHours => _gameClock.Hours;

        private void OnEnable()
        {
            OnChangeUiText();
            _gameClock.TimeChanged += OnChangeUiText;
        }

        private void OnDisable()
        {
            _gameClock.TimeChanged -= OnChangeUiText;
        }

        private void OnChangeUiText()
        {   
            _timeClockText.text = $"{CheckTime(_clockHours)}:{CheckTime(_clockMinutes)}:{CheckTime(_clockSeconds)}";
        }

        private string CheckTime(int time)
        {
            string timeText = "";
            if (time < 10)
            {
                timeText = $"0{time}";
            }
            else
            {
                timeText = $"{time}";
            }
            return timeText;
        }
    }
}
