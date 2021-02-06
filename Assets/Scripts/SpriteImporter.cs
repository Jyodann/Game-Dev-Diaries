#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class SpriteImporter : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        var assetToProcess = (TextureImporter) assetImporter;

        assetToProcess.filterMode = FilterMode.Point;
        assetToProcess.maxTextureSize = 1024;
        assetToProcess.SaveAndReimport();
    }
}
#endif