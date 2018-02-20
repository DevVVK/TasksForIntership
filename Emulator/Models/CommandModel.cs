using System;
using System.Collections.Generic;
using System.Linq;
using Emulator.ViewModels.Base;
using Emulator.ViewModels.Enumerables;
using Emulator.ViewModels.ModelsForView;
using RobotObjects.Enumerables;

namespace Emulator.Models
{
    /// <summary>
    /// Модель для интерфейса команд
    /// </summary>
    public class CommandModel : BaseViewModel
    {
        private int _id;
        private int _currentName;

        public int CommandId
        {
            get => _id;
            set
            {
                _id = value;
                CommandSelector((CommandName)CurrentName, value);
            }
        }
        public int CurrentName
        {
            get => _currentName;
            set
            {
                if (value != _currentName)
                {
                    CommandSelector((CommandName)value, CommandId);
                    _currentName = value;
                }
            }
        }
        public int CurrentOneParameter { get; set; }
        public int CurrentTwoParameter { get; set; }

        public List<BaseCombo> CommandNameSource { get; set; } = new List<BaseCombo>
        {
            new BaseCombo {Name = "Движение", Value = (int)CommandName.Move},
            new BaseCombo {Name = "Поворот", Value = (int)CommandName.Rotation},
            new BaseCombo {Name = "Заливка", Value = (int)CommandName.Pouring},
            new BaseCombo {Name = "Изучение", Value = (int)CommandName.Learn}
        };
        public List<BaseCombo> OneParameterSource { get; set; }
        public List<BaseCombo> TwoParameterSource { get; set; }

        public void CommandSelector(CommandName name, int id)
        {
            var range = GenerateRowNumbers(0, id + 2);
            var list = new List<BaseCombo>
            {
                new BaseCombo {Name = "0", Value = 0},
                new BaseCombo {Name = $"{id + 1}", Value = id + 1}
            };

            switch (name)
            {
                case CommandName.Move:
                    OneParameterSource = GenerateRowNumbers(1, 100);
                    TwoParameterSource = list;
                    break;

                case CommandName.Pouring:
                    OneParameterSource = GetColorCellSource();
                    TwoParameterSource = list;
                    break;

                case CommandName.Rotation:
                    OneParameterSource = GetRouteMoveSource();
                    TwoParameterSource = list;
                    break;

                case CommandName.Learn:
                    OneParameterSource = range;
                    TwoParameterSource = range;
                    break;

                default: throw new ArgumentException();
            }

            CurrentOneParameter = OneParameterSource[0].Value;
            CurrentTwoParameter = TwoParameterSource[TwoParameterSource.Count - 1].Value;

            OnPropertyChanged(nameof(CurrentOneParameter));
            OnPropertyChanged(nameof(CurrentTwoParameter));
        }

        private List<BaseCombo> GetRouteMoveSource()
        {
            return new List<BaseCombo>
            {
                new BaseCombo{ Name = "Направо", Value = (int)RouteMove.Right},
                new BaseCombo{ Name = "Налево", Value = (int)RouteMove.Left }
            };
        }
        private List<BaseCombo> GetColorCellSource()
        {
            return new List<BaseCombo>
            {
                new BaseCombo { Name = "Черный", Value = (int)ColorCell.Black },
                new BaseCombo { Name = "Белый", Value = (int)ColorCell.White}
            };
        }
        private static List<BaseCombo> GenerateRowNumbers(int begin, int end)
        {
            return Enumerable.Range(begin, end - begin).Select(item => new BaseCombo { Name = item.ToString(), Value = item }).ToList();
        }
    }
}