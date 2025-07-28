using System;
using UnityEngine;
using UnityEngine.UI;
using VNyanInterface;

namespace LZUI
{
    class LZ_InputTextField : MonoBehaviour
    {
        // Adapted from Sjatar's UI code
        // This input field is tied to a particular bone in our dictionary
        // We will allow to set the bone number its linked to and the default value.
        private string fieldValue = "";

        private InputField mainField;
        private Button mainButton;
        private Text mainText;
        private Text mainButtonText;

        public void Start()
        {
            // We add the inputfield as the mainfield
            mainField = GetComponent(typeof(InputField)) as InputField;
            // We add a button as confirmation to change the inputted value
            mainButton = GetComponentInChildren(typeof(Button)) as Button;
            mainText = GetComponentInChildren<Text>();
            mainButtonText = mainButton.GetComponentInChildren<Text>();

            changeThemeSettings();
            VNyanInterface.VNyanInterface.VNyanUI.colorThemeChanged += getChangeThemeSettings(); // Re-init colors when this event fires

            // We add a listener that will run ButtonPressCheck if the button is pressed.
            mainButton.onClick.AddListener(delegate { ButtonPressCheck(); });
            VNyan_MiniMonitor.MiniMonitor.setParamName(fieldValue);
            mainField.text = fieldValue;
        }

        public void changeThemeSettings()
        {
            // Set UI Colors
            mainText.GetComponentInChildren<Text>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Text));
            mainButton.GetComponent<Image>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.Button));
            mainButtonText.GetComponent<Text>().color = LZ_UI.hexToColor(VNyanInterface.VNyanInterface.VNyanUI.getCurrentThemeColor(ThemeComponent.ButtonText));
        }

        // set up system action to handle theme change event
        public Action getChangeThemeSettings()
        {
            return changeThemeSettings;
        }


        public void ButtonPressCheck()
        {
            fieldValue = mainField.text;
            VNyan_MiniMonitor.MiniMonitor.setParamName(fieldValue);
        }
    }
}
