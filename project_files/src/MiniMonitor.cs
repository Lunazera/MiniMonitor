using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using VNyanInterface;
using Unity.Profiling;
using System.Collections.Generic;
using System.Text;

namespace VNyan_MiniMonitor
{
    class MiniMonitorManifest : IVNyanPluginManifest
    {
        public string PluginName { get; } = "Mini Monitor";
        public string Version { get; } = "1.1";
        public string Title { get; } = "Mini Monitor";
        public string Author { get; } = "lunazera";
        public string Website { get; } = "https://github.com/Lunazera/MiniMonitor";
        public void InitializePlugin()
        {
        }
    }

    public class MiniMonitor : MonoBehaviour
    {
        private static string currentParameterName = "";

        public static void setParamName(string name) => currentParameterName = name;
        public static float getParamValue()
        {
            if ( !string.IsNullOrEmpty(currentParameterName) )
            {
                return VNyanInterface.VNyanInterface.VNyanParameter.getVNyanParameterFloat(currentParameterName);
            }
            return 0f;
        }
    }
}
