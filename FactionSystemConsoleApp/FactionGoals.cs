using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactionSystemConsoleApp
{
    public class FactionGoals
    {
        private string _goalName;
        private string _goalDescription;
        private int _goalCount;
        private int _goalCurrentCount;
        private int _goalDifficulty;
        private FactionGoals _lastGoal;

        public FactionGoals(string goalName, string goalDescription, int goalCount, int goalCurrentCount, FactionGoals lastGoal)
        {
            _goalName = goalName;
            _goalDescription = goalDescription;
            _goalCount = goalCount;
            _goalCurrentCount = goalCurrentCount;
            _goalDifficulty = CalcDifficulty();
            _lastGoal = lastGoal;
        }

        public string GoalName { get => _goalName; set => _goalName = value; }
        public string GoalDescription { get => _goalDescription; set => _goalDescription = value; }
        public int GoalCount { get => _goalCount; set => _goalCount = value; }
        public int GoalCurrentCount { get => _goalCurrentCount; set => _goalCurrentCount = value; }
        public int GoalDifficulty { get => _goalDifficulty; set => _goalDifficulty = value; }
        public FactionGoals LastGoal { get => _lastGoal; set => _lastGoal = value; }

        public int CalcDifficulty()
        {
            // temp
            return 0;
        }
    }
}
