# LumiTool

A "swiss army knife"-type tool that allows for many different manipulations on Unity Asset Bundles, AssetAssistant Manifests, and various other files. Made with BDSP mods in mind.

## Features

- **Change Bundle Platform**
  - Sets a bundle's Platform.
- **Add MonoScript**
  - Adds MonoScripts to a bundle's type tree.
- **Bundle Prepper**
  - Converts bundles rebuilt from ripping to the Unity Editor (usually using AssetRipper) back into proper bundles for BDSP.
  - Requires reassigning shaders. The tool will automatically ask for those.
- **Shader Bundle PathID Fixer**
  - Changes the PathIDs of all shader and material assets in a bundle to PathIDs from a different bundle, based on the names of the assets.
  - If an asset can't be found in the second bundle, it gets skipped.
- **AssetAssistant Manifest Refresher** (WIP)
  - Refreshes the records in an AssetAssistant manifest by updating the sizes of all records (based on a mod RomFS and a vanilla RomFS) and removing any that cannot be found.

## Planned Features

- **ColorVariation Generator**
  - Allows previewing and editing color palettes to be used with BDSP's ColorVariation system.
- **AssetAssistant Manifest Editor**
  - Allows directly editing an AssetAssistant manifest.
