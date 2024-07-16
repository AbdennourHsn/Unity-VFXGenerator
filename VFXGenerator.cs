using System.Collections.Generic;
using System.Linq;
using CleanArchitect;
using UnityEngine;

namespace CleanArchitect
{
    /// <summary>
    /// Manages the generation and control of visual effects (VFX) in the game.
    /// </summary>
    public class VFXGenerator : MonoBehaviour
    {
        public static VFXGenerator instance; // Singleton instance

        public bool effects_Active = true; // Flag to control if effects are active
        public List<VFX> Vfxes = new List<VFX>(); // List of available VFX
        public Transform DefaultSpawnParent = null; // Default parent for spawned VFX

        private void Awake()
        {
            // Singleton pattern implementation
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
        }

        private void Start()
        {
            try
            {
                // Initialize effects active state from game configuration
                effects_Active = GameConfig.instance.Effects;
            }
            catch
            {
                Debug.LogWarning("Fail to get Game configuration!");
            }
        }

        /// <summary>
        /// Spawns a VFX at a specific position in the scene.
        /// </summary>
        /// <param name="name">Name of the VFX to spawn.</param>
        /// <param name="position">Position in the scene to spawn the VFX.</param>
        public void SpawnVFX(string name, Vector3 position)
        {
            if (!effects_Active) return; // Check if effects are active
            try
            {
                VFX vfx = GetVFX(name); // Retrieve the VFX from the list
                Instantiate(vfx.prefab, position, Quaternion.identity); // Instantiate the VFX prefab
            }
            catch
            {
                Debug.LogError("Fail to Instantiate VFX!");
            }
        }

        /// <summary>
        /// Spawns a VFX as a child of a parent object.
        /// </summary>
        /// <param name="name">Name of the VFX to spawn.</param>
        /// <param name="parentObj">Parent transform to spawn the VFX under.</param>
        public void SpawnVFX(string name, Transform parentObj)
        {
            if (!effects_Active) return; // Check if effects are active
            try
            {
                VFX vfx = GetVFX(name); // Retrieve the VFX from the list
                GameObject vfxPrefab = Instantiate(vfx.prefab, parentObj); // Instantiate the VFX prefab under the parent

                vfxPrefab.transform.SetParent(parentObj); // Set the parent of the instantiated VFX
                vfxPrefab.transform.localPosition = Vector3.zero; // Reset local position
                vfxPrefab.transform.localRotation = Quaternion.identity; // Reset local rotation
            }
            catch
            {
                Debug.LogError("Fail to Instantiate VFX!");
            }
        }

        /// <summary>
        /// Retrieves a VFX from the list by its name.
        /// </summary>
        /// <param name="name">Name of the VFX to retrieve.</param>
        /// <returns>The VFX struct corresponding to the name.</returns>
        private VFX GetVFX(string name)
        {
            VFX vfx = Vfxes.FirstOrDefault(v => v.name == name); // Find the VFX by name in the list
            return vfx;
        }

        /// <summary>
        /// Sets the active state of visual effects.
        /// </summary>
        /// <param name="active">True to enable effects, false to disable.</param>
        public void SetEffects(bool active)
        {
            this.effects_Active = active; // Update local effects active state
            GameConfig.instance.Effects = active; // Update game configuration with new effects state
        }

    }

    /// <summary>
    /// Represents a visual effect (VFX) with a name and corresponding prefab.
    /// </summary>
    [System.Serializable]
    public struct VFX
    {
        public string name; // Name of the VFX
        public GameObject prefab; // Prefab GameObject of the VFX
    }
}
