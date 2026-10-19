# GitHub Copilot Instructions for Dustproof Boots (Continued) Mod Development

## Mod Overview and Purpose

**Mod Name:** Dustproof Boots (Continued)  
**Description:** This mod is an update of AKreedz's original mod, adding Dustproof Boots into RimWorld. The primary function of these boots is to prevent colonists from creating dust or trash as they move around, thereby maintaining a tidier and more efficient colony.

## Key Features and Systems

- **Dustproof Boots:** Essential footwear designed for colonists to prevent dust and trash generation. Note that they do not prevent colonists from leaving blood or other natural substances.
- **System Integration:** The core of the mod revolves around modifying colonist interaction with the environment to reduce unwanted filth production.
  
## Coding Patterns and Conventions

- **Organized Structure:** The mod comprises four key C# files and one XML file, which are structured to enhance readability and cohesion.
- **Naming Conventions:** Classes and methods use PascalCase for naming, ensuring consistency across the mod's codebase.

## XML Integration

- The XML file `Apparel_Boots.xml` defines the apparel item properties in RimWorld, including its attributes and effects. It ensures that the Dustproof Boots are recognized as a legitimate in-game item with the desired functionalities.

## Harmony Patching

- **Harmony Dependency:** The mod leverages `brrainz.harmony` for patching, ensuring smooth integration with the game by modifying specific methods without altering the base game code.
- **Patch Examples:**
  - `Pawn_FilthTracker_Notify_EnteredNewCell.cs` and `Pawn_FilthTracker_GainFilth.cs` introduce patches that handle scenarios when colonists move to a new cell or gain filth, respectively.
  - `FilthMaker_TryMakeFilth.cs` includes a prefix patch method to modify behavior regarding filth creation.

## Suggestions for Copilot

To streamline the development process and maintain the quality of your mod, consider leveraging GitHub Copilot with these suggestions:

1. **Commenting:** Ensure all methods and classes in C# have appropriate XML comments to enhance understanding (`/// <summary>...</summary>`).

2. **Method Stubs:** Use Copilot to generate method stubs and implement the desired logic by focusing on method signatures and expected outcomes.

3. **Patch Method Generation:** Utilize Copilot to create Harmony patch methods by outlining the target method and desired changes.

4. **XML Schema Definitions:** Allow Copilot to assist with writing XML by auto-completing tag names and common attributes based on existing XML schemata within the RimWorld modding context.

5. **Error Handling:** Enable Copilot to generate robust error handling code to alert users to issues when the mod becomes part of more extensive mod packs.

By following these instructions and leveraging Copilot efficiently, you'll ensure that the Dustproof Boots (Continued) mod is both robust and maintainable, providing RimWorld players with a cleaner, more organized gameplay experience.

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

