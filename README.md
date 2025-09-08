# LumiTool

A "swiss army knife"-type tool that allows for many different manipulations on Unity Asset Bundles, AssetAssistant Manifests, and various other files. Made with BDSP mods in mind but very flexible.

## Features

- **Change Bundle Platform**
  - Sets a bundle's Platform.
- **Add MonoScript**
  - Adds MonoScripts to a bundle's type tree.
- **Shader Bundle PathID Fixer**
  - Changes the PathIDs of all shader and material assets in a bundle to PathIDs from a different bundle, based on the names of the assets.
  - If an asset can't be found in the second bundle, it gets skipped.
- **Bundle Prepper**
  - Converts bundles rebuilt from ripping to the Unity Editor (usually using AssetRipper) back into proper bundles for use in the game.
  - For bundles with dependencies, this requires reassigning references to those dependencies and is therefore only available with a proper JSON file detailing the path IDs of those references.
	- An example of a valid configuration file is available in the tool's Config folder.
	- The prepper will automatically ask for what the assets referenced are and will remember those choices when the same path IDs are seen again.
  - There is also a version that allows converting a full folder's worth of bundles.
- **Bundle Renamer**
  - Changes the Asset Bundle Name of a bundle inside its manifest/preload table at path ID 1.
  - Also changes the "CAB Name" of that bundle to a new user-provided one.
- **AssetAssistant Manifest Refresher** (WIP)
  - Refreshes the records in an AssetAssistant manifest by updating the sizes of all records (based on a mod RomFS and a vanilla RomFS) and removing any that cannot be found.
- **AssetAssistant Manifest Editor**
  - Allows directly editing an AssetAssistant manifest.
- **Wwise Event Cloner**
  - Clones a given Wwise event in a bank.
- **Wwise Event Browser**
  - Allows looking at an overview of all events in a Wwise bank and their actions.

## Planned Features

- **ColorVariation Generator**
  - Allows previewing and editing color palettes to be used with BDSP's ColorVariation system.