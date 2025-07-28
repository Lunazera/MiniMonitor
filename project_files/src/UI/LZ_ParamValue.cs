using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VNyanInterface;

namespace LZUI
{
    class LZ_ParamValue : MonoBehaviour
    {
        public Text parameterValueText;

        void Start()
        {
            changeThemeSettings();
        }

        void Update()
        {
            parameterValueText.text = VNyan_MiniMonitor.MiniMonitor.getParamValue().ToString("0.000");
        }

        public void changeThemeSettings()
        {
            parameterValueText.GetComponent<Text>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Text));
        }
    }
}
