using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VNyanInterface;

namespace LZUI
{
    class LZ_CloseButton : MonoBehaviour
    {
        public GameObject windowPrefab;
        private Button closeButton;

        public void Start()
        {
            closeButton = GetComponent(typeof(Button)) as Button;
            closeButton.onClick.AddListener(delegate { CloseButtonClicked(); });

            changeThemeSettings();
            VNyanInterface.VNyanInterface.VNyanUI.colorThemeChanged += changeThemeSettings; // Re-init colors when this event fires
        }

        public void CloseButtonClicked()
        {
            this.windowPrefab.SetActive(false);
        }

        public void changeThemeSettings()
        {
            closeButton.GetComponent<Image>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Panel));
            closeButton.GetComponent<Outline>().effectColor = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Borders));
            closeButton.GetComponentInChildren<Text>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Text));
        }
    }
}
