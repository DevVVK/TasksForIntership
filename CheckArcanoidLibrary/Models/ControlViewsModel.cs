using System.Collections.Generic;
using System.Windows.Forms;
using CheckArcanoidLibrary.Enumerables;

namespace CheckArcanoidLibrary.Models
{
    public class ControlViewsModel
    {
        private readonly Dictionary<NameControlEnum, Control> _controlDictionary;

        public ControlViewsModel()
        {
            _controlDictionary = new Dictionary<NameControlEnum, Control>();
        }

        public void AddControl(NameControlEnum nameInterface, Control userInterface)
        {
            _controlDictionary.Add(nameInterface, userInterface);
        }

        public Control GetControl(NameControlEnum nameInterface)
        {
            Control valueControl;

            _controlDictionary.TryGetValue(nameInterface, out valueControl);

            return valueControl;
        }

        public void Remove(NameControlEnum nameInterface)
        {
            if (_controlDictionary.ContainsKey(nameInterface))
            {
                _controlDictionary.Remove(nameInterface);
            }
        }
    }
}