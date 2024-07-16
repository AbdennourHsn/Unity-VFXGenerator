using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameConfigurations is a singleton class that manages game settings such as music, sound effects (SFX), 
/// visual effects, vibration, and volume. These settings are saved to and loaded from PlayerPrefs, 
/// allowing persistence across game sessions.
/// 
/// Features:
/// - Singleton Pattern: Ensures a single instance of GameConfigurations exists.
/// - Configuration Persistence: Saves and loads settings from PlayerPrefs.
/// - Easy Access: Provides properties to access and modify each setting.
/// 
/// Usage:
/// - Call setConfigurationFromPlayerPrefabs() to load settings from PlayerPrefs.
/// - Access and modify settings through properties (e.g., GameConfigurations._instance.Music).
/// - Call ResetToDefaultValues() to reset settings to their default values.
/// </summary>

namespace CleanArchitect
{
    public class GameConfig : MonoBehaviour
    {
        public static GameConfig instance;

        [SerializeField] private bool music = true;
        [SerializeField] private bool sfx = true;
        [SerializeField] private bool effects = true;
        [SerializeField] private bool vibration = true;
        [SerializeField] [Range(0, 1)] private float volume = 0.5f;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Loads configuration settings from PlayerPrefs.
        /// </summary>
        public void setConfigurationFromPlayerPrefabs()
        {
            music = PlayerPrefs.HasKey("config_music") ? PlayerPrefs.GetInt("config_music") == 1 : true;
            sfx = PlayerPrefs.HasKey("config_sfx") ? PlayerPrefs.GetInt("config_sfx") == 1 : true;
            effects = PlayerPrefs.HasKey("config_effects") ? PlayerPrefs.GetInt("config_effects") == 1 : true;
            vibration = PlayerPrefs.HasKey("config_vibration") ? PlayerPrefs.GetInt("config_vibration") == 1 : true;
            volume = PlayerPrefs.HasKey("config_volume") ? PlayerPrefs.GetFloat("config_volume") : 0.5f;
        }

        /// <summary>
        /// Resets configuration settings to their default values and updates PlayerPrefs.
        /// </summary>
        public void ResetToDefaultValues()
        {
            PlayerPrefs.SetInt("config_music", 1);
            PlayerPrefs.SetInt("config_sfx", 1);
            PlayerPrefs.SetInt("config_effects", 1);
            PlayerPrefs.SetInt("config_vibration", 1);
            PlayerPrefs.SetFloat("config_volume", 0.5f);
            PlayerPrefs.Save();
            music = true;
            sfx = true;
            effects = true;
            vibration = true;
            volume = 0.5f;
        }

        public bool Music
        {
            get { return music; }
            set
            {
                music = value;
                PlayerPrefs.SetInt("config_music", music ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        public bool Sfx
        {
            get { return sfx; }
            set
            {
                sfx = value;
                PlayerPrefs.SetInt("config_sfx", sfx ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        public bool Effects
        {
            get { return effects; }
            set
            {
                effects = value;
                PlayerPrefs.SetInt("config_effects", effects ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        public bool Vibration
        {
            get { return vibration; }
            set
            {
                vibration = value;
                PlayerPrefs.SetInt("config_vibration", vibration ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        public float Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                PlayerPrefs.SetFloat("config_volume", volume);
                PlayerPrefs.Save();
            }
        }
    }
}
