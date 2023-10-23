using UnityEngine;

namespace RareCoders
{

    public static class GamePreferences
    {
        private const string SOUND = "Sound";
        private static int _sound;
        public static int Sound
        {
            get { return PlayerPrefs.GetInt(SOUND, 1); }
            set { _sound = value; PlayerPrefs.SetInt(SOUND, _sound); }
        }

        private const string MUSIC = "Music";
        private static int _music;
        public static int Music
        {
            get { return PlayerPrefs.GetInt(MUSIC, 1); }
            set { _music = value; PlayerPrefs.SetInt(MUSIC, _music); }
        }

        private const string HIGH_SCORE = "High Score";
        private static int _HighScore;
        public static int HighScore
        {
            get { return PlayerPrefs.GetInt(HIGH_SCORE); }
            set { _HighScore = value; PlayerPrefs.SetInt(HIGH_SCORE, _HighScore); }
        }


        private const string LAST_SCORE = "Last Score";
        private static int _LastScore;
        public static int LastScore
        {
            get { return PlayerPrefs.GetInt(LAST_SCORE); }
            set { _LastScore = value; PlayerPrefs.SetInt(LAST_SCORE, _LastScore); }
        }
    }
}