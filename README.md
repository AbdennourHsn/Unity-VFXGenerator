# 🎆 VFX Generator for Unity

This Unity script provides a manager for handling visual effects (VFX) in the game. It allows for spawning VFX at specific positions or as children of parent objects. The manager supports toggling the active state of effects and retrieves configuration settings from `GameConfig`.

## Features

- **🔄 Singleton Pattern**: Ensures a single instance of `VFXGenerator` exists.
- **🎇 VFX Spawning**: Spawn VFX at specific positions or under parent objects.
- **🔧 Configuration Control**: Control effects activation and retrieve settings from `GameConfig`.
- **🔍 Extensibility**: Add custom VFX and modify settings as per game requirements.

## Usage

### Initialization

1. **Ensure a Single Instance**:
    ```csharp
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    ```

### Spawning VFX

- **Spawn VFX at Position**:
    ```csharp
    VFXGenerator.instance.SpawnVFX("explosion", transform.position);
    ```

- **Spawn VFX under Parent Object**:
    ```csharp
    VFXGenerator.instance.SpawnVFX("sparkles", parentTransform);
    ```

### Managing Effects

- **Toggle Effects On/Off**:
    ```csharp
    VFXGenerator.instance.SetEffects(true);
    ```

## Extending the Manager

You can extend the `VFXGenerator` class with additional methods or attributes to enhance VFX management according to your game's needs.

### Example

```csharp
// Adding a method to play a specific VFX sequence
public void PlayVFXSequence(string[] vfxNames, Vector3 startPosition)
{
    foreach (string name in vfxNames)
    {
        VFXGenerator.instance.SpawnVFX(name, startPosition);
    }
}
