using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DPUtils.Systems.DateTime
{
    public class TimeHandler : MonoBehaviour
    {
        // Variables
        [Header("Date & Time Settings")]
        [Range(1, 30)]
        public int dayInMonth;
        
        [Range(0, 24)]
        public int hour;
        
        [Range(0, 6)]
        public int minutes;

        private DateTime DateTime;

        // VERY IMPORTANT FOR GAME DESIGN
        [Header("Tick Settings")]
        public int TickMinutesIncreased = 10;
        public float TimeBetweenTicks  = 1;
        private float currentTimeBetweenTicks = 0;

        public static UnityAction<DateTime> OnDateTimeChanged;


        private void Awake()
        {
         
            DateTime = new DateTime(dayInMonth, hour, minutes);

        }

        void Start()
        {
            OnDateTimeChanged?.Invoke(DateTime);
        }

        void Update()
        {
            currentTimeBetweenTicks += Time.deltaTime;

            if (currentTimeBetweenTicks >= TimeBetweenTicks) 
            {
                currentTimeBetweenTicks = 0;
                Tick();
            }
        }

        void Tick() 
        {
            DateTime.AdvanceMinutes(TickMinutesIncreased);

            OnDateTimeChanged?.Invoke(DateTime);
        }

    }

    [System.Serializable]
    public struct DateTime {
        #region Fields
        private int date;
        private int hour;
        private int minutes;
        private bool end;
        #endregion

        #region Properties
        public int Date => date;
        public int Hour => hour;
        public int Minutes => minutes;
        public bool End => end;
        #endregion
    
        #region Constructors
        public DateTime(int date, int hour, int minutes) {
            this.date = date;
            this.hour = hour;
            this.minutes = minutes;
            this.end = false;
        }
        #endregion

        #region Time Advancement
        public void AdvanceMinutes(int SecondsToAdvanceBy) 
        {
            if (minutes + SecondsToAdvanceBy >= 60) {
                minutes = (minutes + SecondsToAdvanceBy) % 60;
                AdvanceHour();
            } else {
                minutes += SecondsToAdvanceBy;
            }
        }

        private void AdvanceHour() {
            if ((hour + 1) == 24) {
                hour = 0;
                AdvanceDay();
            } else {
                hour++;
            }
        }

        private void AdvanceDay() {
            if ((date + 1) > 30) {
                date = 1;
                end = true;
            } else {
                date++;
            }
        }
        #endregion

        #region Bool Checks
        public bool IsNight() {
            return hour > 18 || hour < 6;
        }

        public bool IsDay() {
            return hour <= 18 && hour > 6;
        }

        public bool IsNewDay() {
            return hour == 6 && minutes == 0;
        }
        #endregion
    }

}