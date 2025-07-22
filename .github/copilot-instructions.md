# GitHub Copilot Instructions for RimWorld Modding Project

Welcome to the RimWorld modding project! This document serves as a comprehensive guide for using GitHub Copilot to assist with developing and improving this mod. Below, you'll find information on the mod's purpose, key features, coding patterns, integration with XML, and the use of Harmony patching.

## Mod Overview and Purpose

This mod focuses on expanding the functionality of doors within RimWorld, as well as introducing unique game mechanics concerning prisoners and their interaction with doors.

### Purpose

- Enhance door interactions to create complex game scenarios.
- Implement mechanics to prevent prisoners from opening doors, increasing challenge and strategic depth for players managing their colonies.

## Key Features and Systems

- **Doors Expanded:** Extend the basic functionality of doors with new interaction rules.
- **Prisoner Security:** Introduce features that prevent prisoners from accessing doors, enhancing security management.

## Coding Patterns and Conventions

### Coding Standards

- **Naming Conventions:** Use PascalCase for class names and camelCase for method names.
- **Internal Classes:** Use internal access modifiers for classes not intended for utilization outside the project.
- **Public Accessibility:** Limit public accessibility to essential classes and methods, aiming for encapsulation.
  
### Project Structure

- **Assembly Info Files:** Include metadata about the assemblies being targeted (.NETFramework, Version v4.7.2 and v4.8).
- **Core Classes:**
  - `DoorsExpandedPatch`: Contains the core logic for the expanded door features.
  - `Building_Door_PawnCanOpen`: Handles logic for determining if certain pawns can interact with doors.
  - `PrisonersDontHaveKeys` and `PrisonersDontHaveKeysMod`: Core classes for managing prisoner mechanics.

## XML Integration

RimWorld mods often require XML integration for defining game objects, data-driven definitions, and translations. Although not listed here, ensure to use properly structured XML files for defining all data-driven content such as new building types, labels, and descriptions.

## Harmony Patching

Harmony is a crucial aspect of modding RimWorld, allowing you to modify game behavior without altering the game's original source code.

- **Methods and Classes:** Use Harmony patches in `DoorsExpandedPatch` to safely override or extend base game functionality.
- **Patch Types:**
  - **Prefix:** Execute code before a target method runs.
  - **Postfix:** Execute code after a target method completes.
  - **Transpiler:** Modify the IL code of a method directly for more intricate changes.

## Suggestions for Copilot

To make effective use of GitHub Copilot:

- **Comment Code Thoroughly:** Providing comments in your code will help Copilot generate more context-aware suggestions.
- **Use Descriptive Naming:** Clear variable and method naming will assist Copilot in understanding your project's intent.
- **Review Suggestions:** Always review Copilot’s code suggestions to ensure they align with your project’s goals and coding standards.
- **Use Copilot for Routine Tasks:** Leverage Copilot for automating repetitive tasks, such as generating boilerplate code or implementing standard patterns.

Feel free to refer to this file for enhancing your development workflow with Copilot, facilitating a smooth and efficient modding process within the RimWorld environment. Happy modding!
