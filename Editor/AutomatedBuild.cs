using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class AutomatedBuild : MonoBehaviour
{
    // ******* CONFIGURATION *******

    private static string _executableName = "game";
    private static string _executableVersion = "0.1";
    
    private static BuildTarget[] _buildTargets = new[]
    {
        BuildTarget.StandaloneWindows,
        BuildTarget.StandaloneWindows64,
        BuildTarget.StandaloneOSX,
        BuildTarget.StandaloneLinux,
        BuildTarget.StandaloneLinux64,
        BuildTarget.WebGL
    };

    private static string[] _scenesToBuild = new[]
    {
        "Assets/Scene1.unity",
        "Assets/Scene2.unity"
    };
    
    private static string _buildOutputPath = "~/game_build/";
    
    // ***** END CONFIGURATION *****

    private static Dictionary<BuildTarget, string> _buildEndings = new Dictionary<BuildTarget, string>();

    [MenuItem("Build/Full Build")]
    public static void BuildFull()
    {
        _buildEndings[BuildTarget.StandaloneWindows] =
            _executableName + "_" + _executableVersion + "_" + "win/" + _executableName + ".exe";
        _buildEndings[BuildTarget.StandaloneWindows64] =
            _executableName + "_" + _executableVersion + "_" + "win64/" + _executableName + ".exe";
        
        _buildEndings[BuildTarget.StandaloneLinux] =
            _executableName + "_" + _executableVersion + "_" + "linux/" + _executableName;
        _buildEndings[BuildTarget.StandaloneLinux64] =
            _executableName + "_" + _executableVersion + "_" + "linux64/" + _executableName;

        _buildEndings[BuildTarget.StandaloneOSX] =
            _executableName + "_" + "OSX";

        _buildEndings[BuildTarget.WebGL] =
            _executableName + "_" + _executableVersion + "_" + "WebGL";
        
        
        foreach (BuildTarget buildTarget in _buildTargets)
        {
            BuildReport report = BuildPlatform(buildTarget);
            BuildSummary summary = report.summary;

            if (summary.result == BuildResult.Succeeded)
            {
                Debug.Log(buildTarget.ToString() + " build succeeded: " + summary.totalSize + " bytes");
            }

            if (summary.result == BuildResult.Failed)
            {
                Debug.Log(buildTarget.ToString() + " build failed. Stopping build process.");
                return;
            }
        }
    }
    
    public static BuildReport BuildPlatform(BuildTarget buildTarget)
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = _scenesToBuild;
        if (_buildEndings.ContainsKey(buildTarget))
            buildPlayerOptions.locationPathName = _buildOutputPath + _buildEndings[buildTarget];
        else
            buildPlayerOptions.locationPathName = _buildOutputPath + _executableName + "_" + _executableVersion + "_" +
                                                  buildTarget.ToString();
        buildPlayerOptions.target = buildTarget;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        return report;
    }
}