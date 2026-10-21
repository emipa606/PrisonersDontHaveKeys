# GitHub Copilot Instructions for Prisoners Dont Have Keys

Welcome to the GitHub repository for the "Prisoners Dont Have Keys" mod for RimWorld. This document provides an overview of the mod, its key features, coding patterns, XML integration, harmony patching, and suggestions on how to effectively leverage GitHub Copilot for development and maintenance tasks.

## Mod Overview and Purpose

"Prisoners Dont Have Keys" is a RimWorld mod designed to alter the behavior of prisoners during prison breaks by restricting their ability to open doors without bashing them, aligning their capabilities more closely with fleeing raiders. The mod also adds mod-options to customize this behavior further, allowing flexibility depending on player preferences and game expansions.

## Key Features and Systems

- **Prisoner Door Interaction:** Prisoners cannot open doors autonomously and must bash them to escape, mimicking fleeing raiders' behavior.
- **Mod-Options Configuration:**
  - Allow prisoners to open cell-doors during a prison break but restrict access to other doors.
  - Option to prevent rioting slaves from opening doors if the Ideology DLC is present.
  - Option to block anomaly entities from opening doors if the Anomaly DLC is installed.
- **Enhanced Compatibility:** Added support for the "Doors Expanded" mod, providing seamless integration and improved game experience.

## Coding Patterns and Conventions

- **Namespace Organization:** Classes are organized under distinct namespaces such as `DoorsExpandedPatch` and `PrisonersDontHaveKeys`, reflecting their roles and functionalities.
- **Object-Oriented Design:** Utilize object-oriented principles for clarity and maintainability with clearly defined class responsibilities.
- **Modular Code Structure:** Code is structured in a modular way to separate responsibilities and facilitate easy updates and maintenance.

## C# File Breakdown

- **DoorsExpandedPatch.cs:** Contains the class for compatibility patches with "Doors Expanded".
- **PrisonersDontHaveKeys.cs:** Core functionality for handling prisoner door interaction logic.
- **Building_Door_PawnCanOpen.cs:** Patches related to checking whether prisoners can open doors.
- **PrisonersDontHaveKeysMod.cs:** Implementations for mod configuration interface and settings.
- **PrisonersDontHaveKeysModSettings.cs:** Handles the storage and exposure of mod settings.

## XML Integration

The current iteration of "Prisoners Dont Have Keys" does not utilize XML definitions directly. Configuration and game interactions are managed through C# code and Harmony patches. If future updates require XML integration for defs or configurations, ensure to use RimWorld's XML conventions and structure for mod compatibility.

## Harmony Patching

- **Dependency Management:** The mod depends on `brrainz.harmony` for runtime code modifications.
- **Patch Implementation:** Implement patches using Harmony to adjust existing functionality without altering core game files. 
- **Example Patch Usage:** Use `[HarmonyPostfix]` and `[HarmonyPrefix]` to implement custom logic post and pre original method execution.

## Suggestions for Copilot

- **Pattern Recognition:** Utilize Copilot to identify common coding patterns within the mod for efficient code suggestion and completion.
- **Code Generation:** Allow Copilot to generate repetitive code constructs such as property getters/setters, or UI components in mod-settings.
- **Refactoring Assistance:** Leverage Copilot to fetch suggested improvements or refactoring opportunities to enhance code readability and efficiency.
- **Error Handling:** Use Copilot recommendations to enhance error handling and logging, ensuring greater stability and less runtime issues.
- **Documentation:** Generate inline documentation or comments using Copilot to keep code annotations up to date and helpful for new developers.

This is a living document that can evolve alongside mod updates and changes. Feedback and additional contributions are always welcome to ensure the efficiency and quality of the development process. Happy modding!

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

