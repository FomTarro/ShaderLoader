# Shader Loader
A an example for loading shaders from an external file.

## How to Use
* Follow the [Asset Bundle Workflow](https://docs.unity3d.com/Manual/AssetBundles-Workflow.html) to make and compile shaders in-editor.
* The example code will then load the bundles out of `StreamingAssets/Shaders` and populate the dropdown UI element

In practice, the workflow will involve having users export custom shaders using the Unity editor, and having the standalone application be able to read these bundles at runtime. Sadly, there's no way for Unity to compile shaders at runtime, yet.