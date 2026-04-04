# Copilot Instructions for "Prisoners Don't Have Keys" RimWorld Mod

## Mod Overview and Purpose

"Prisoners Don't Have Keys" is a mod for RimWorld that alters the behavior of prisoners during escape attempts. In the vanilla game, prisoners can open doors when escaping, contrary to fleeing raiders who cannot. This mod changes that dynamic, requiring prisoners to bash doors during an escape just like raiders. Additionally, the mod provides options to fine-tune the behavior of prisoners and other entities concerning door interactions, allowing for a more immersive gameplay experience that reflects a variety of scenarios.

## Key Features and Systems

- **Prisoner Door Interaction**: Prisoners are required to break down doors when escaping. This can be toggled to allow prisoners to open cell doors specifically at the beginning of a prison break.
  
- **Mod Options**: Customizable options include:
  - Allowing prisoners to open only cell doors
  - Blocking rioting slaves from opening doors if the Ideology DLC is active
  - Blocking anomaly entities from opening doors if the Anomaly DLC is active

- **Compatibility**: Enhanced support for the "Doors Expanded" mod, ensuring consistent behavior with modded doors.

## Coding Patterns and Conventions

- **C# Conventions**: Follow the standard C# naming conventions with PascalCase for classes and methods.
- **Code Structure**: Organize classes into distinct files grouped by related functionality. 

## XML Integration

- RimWorld uses XML for defining many of its settings. Ensure XML configurations for this mod follow RimWorld's schema, especially when interfacing with in-game settings and objects.
  
- Use XML for defining mod settings and available options. The mod settings should be clear and user-friendly, making use of descriptive names so that users know what they are toggling.

## Harmony Patching

- **Harmony Library**: This mod uses Harmony for runtime patching of RimWorld's base methods.
  
- **Patch Structure**: Keep patches organized and directly related to their respective function. For example, use the `Building_Door_PawnCanOpen` class to handle the logic of pawns checking if they can open doors.

- Ensure patches are robust to future RimWorld updates, verifying the method signatures and any overridden behavior stays current with the game.

## Suggestions for Copilot

When using GitHub Copilot to assist in this mod’s development, consider the following prompts and usage guidance:

- **Debugging Assistance**: "Generate a debugging method for door interaction logic in 'Building_Door_PawnCanOpen' class."
  
- **Settings Development**: "Extend the 'PrisonersDontHaveKeysModSettings' class to add a setting for blocking anomaly entities from doors."

- **Compatibility Handling**: "Create compatibility patches for systems influenced by 'Doors Expanded'."

- **Harmony Patch Examples**: "Provide an example of a postfix method patch using Harmony for the 'CanOpen' function."

- **XML Configuration**: "Suggest XML format for user options in 'ModSettings'."

By leveraging these guidelines, GitHub Copilot can effectively enhance the development process for the "Prisoners Don't Have Keys" mod, ensuring consistent and efficient code production.
