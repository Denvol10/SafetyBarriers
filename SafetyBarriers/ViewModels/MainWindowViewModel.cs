﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Architecture;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SafetyBarriers.Infrastructure;
using SafetyBarriers.Models;

namespace SafetyBarriers.ViewModels
{
    internal class MainWindowViewModel : Base.ViewModel
    {
        private RevitModelForfard _revitModel;

        internal RevitModelForfard RevitModel
        {
            get => _revitModel;
            set => _revitModel = value;
        }

        private int _postIndex = (int)Properties.Settings.Default["PostIndex"];

        #region Заголовок

        private string _title = "Барьерное ограждение";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #endregion

        #region Элементы оси барьерного ограждения
        private string _barrierAxisElemIds;
        public string BarrierAxisElemIds
        {
            get => _barrierAxisElemIds;
            set => Set(ref _barrierAxisElemIds, value);
        }
        #endregion

        #region Элемент линии границы 1
        private string _boundCurve1;
        public string BoundCurve1
        {
            get => _boundCurve1;
            set => Set(ref _boundCurve1, value);
        }
        #endregion

        #region Элемент линии границы 2
        private string _boundCurve2;
        public string BoundCurve2
        {
            get => _boundCurve2;
            set => Set(ref _boundCurve2, value);
        }
        #endregion

        #region Список семейств категории обобщенной модели
        private ObservableCollection<FamilySymbolSelector> _genericModelFamilySymbols;

        public ObservableCollection<FamilySymbolSelector> GenericModelFamilySymbols
        {
            get => _genericModelFamilySymbols;
            set => Set(ref _genericModelFamilySymbols, value);
        }
        #endregion

        #region Выбранный типоразмер семейства стойки
        private FamilySymbolSelector _postFamilySymbol;
        public FamilySymbolSelector PostFamilySymbol
        {
            get => _postFamilySymbol;
            set => Set(ref _postFamilySymbol, value);
        }
        #endregion

        #region Поворот на 180 градусов
        private bool _isRotateOn180 = (bool)Properties.Settings.Default["IsRotateOn180"];
        public bool IsRotateOn180
        {
            get => _isRotateOn180;
            set => Set(ref _isRotateOn180, value);
        }
        #endregion

        #region Начало построения ограждения
        private ObservableCollection<string> _alignmentSafityBarrier;
        public ObservableCollection<string> AlignmentSafityBarrier
        {
            get => _alignmentSafityBarrier;
            set => Set(ref _alignmentSafityBarrier, value);
        }
        #endregion

        #region Выбранное начало построения ограждения
        private string _selectedAlignmentSafityBarrier = (string)Properties.Settings.Default["SelectedAlignmentSafityBarrier"];
        public string SelectedAlignmentSafityBarrier
        {
            get => _selectedAlignmentSafityBarrier;
            set => Set(ref _selectedAlignmentSafityBarrier, value);
        }
        #endregion

        #region Начальная стойка ограждения
        private bool _isIncludeStartPost = (bool)Properties.Settings.Default["IsIncludeStartPost"];
        public bool IsIncludeStartPost
        {
            get => _isIncludeStartPost;
            set => Set(ref _isIncludeStartPost, value);
        }
        #endregion

        #region Конечная стойка ограждения
        private bool _isIncludeFinishPost = (bool)Properties.Settings.Default["IsIncludeFinishPost"];
        public bool IsIncludeFinishPost
        {
            get => _isIncludeFinishPost;
            set => Set(ref _isIncludeFinishPost, value);
        }
        #endregion

        #region Полотно ограждения
        private ObservableCollection<FamilySymbolSelector> _beamFamilySymbols;
        public ObservableCollection<FamilySymbolSelector> BeamFamilySymbols
        {
            get => _beamFamilySymbols;
            set => Set(ref _beamFamilySymbols, value);
        }
        #endregion

        #region Выбранное полотно ограждения
        private FamilySymbolSelector _selectedBeamFamilySymbol;
        public FamilySymbolSelector SelectedBeamFamilySymbol
        {
            get => _selectedBeamFamilySymbol;
            set => Set(ref _selectedBeamFamilySymbol, value);
        }
        #endregion

        #region Список полотен ограждения
        private ObservableCollection<BeamSetup> _beamCollection;
        public ObservableCollection<BeamSetup> BeamCollection
        {
            get => _beamCollection;
            set => Set(ref _beamCollection, value);
        }

        #endregion

        #region Выбранное полотно ограждения
        private BeamSetup _selectedBeam;
        public BeamSetup SelectedBeam
        {
            get => _selectedBeam;
            set => Set(ref _selectedBeam, value);
        }
        #endregion

        #region Развернуть балки
        private bool _isReverseBeams = (bool)Properties.Settings.Default["IsReverseBeams"];
        public bool IsReverseBeams
        {
            get => _isReverseBeams;
            set => Set(ref _isReverseBeams, value);
        }
        #endregion

        #region Шаг стоек
        private double _postStep = (double)Properties.Settings.Default["PostStep"];
        public double PostStep
        {
            get => _postStep;
            set => Set(ref _postStep, value);
        }
        #endregion

        #region Длина балок
        private double _beamLength = (double)Properties.Settings.Default["BeamLength"];
        public double BeamLength
        {
            get => _beamLength;
            set => Set(ref _beamLength, value);
        }
        #endregion

        #region Развернуть стойки
        private bool _isRotatePosts = Properties.Settings.Default.IsRotatePosts;
        public bool IsRotatePosts
        {
            get => _isRotatePosts;
            set => Set(ref _isRotatePosts, value);
        }
        #endregion

        #region Команды

        #region Получение оси барьерного ограждения
        public ICommand GetBarrierAxisCommand { get; }

        private void OnGetBarrierAxisCommandExecuted(object parameter)
        {
            RevitCommand.mainView.Hide();
            RevitModel.GetBarrierAxis();
            BarrierAxisElemIds = RevitModel.BarrierAxisElemIds;
            RevitCommand.mainView.ShowDialog();
        }

        private bool CanGetBarrierAxisCommandExecute(object parameter)
        {
            return true;
        }
        #endregion

        #region Получение границы барьерного ограждения 1
        public ICommand GetBoundCurve1Command { get; }

        private void OnGetBoundCurve1CommandExecuted(object parameter)
        {
            RevitCommand.mainView.Hide();
            RevitModel.GetBoundCurve1();
            BoundCurve1 = RevitModel.BoundCurveId1;
            RevitCommand.mainView.ShowDialog();
        }

        private bool CanGetBoundCurve1CommandExecute(object parameter)
        {
            return true;
        }
        #endregion

        #region Получение границы плиты барьерного ограждения 2
        public ICommand GetBoundCurve2Command { get; }

        private void OnGetBoundCurve2CommandExecuted(object parameter)
        {
            RevitCommand.mainView.Hide();
            RevitModel.GetBoundCurve2();
            BoundCurve2 = RevitModel.BoundCurveId2;
            RevitCommand.mainView.ShowDialog();
        }

        private bool CanGetBoundCurve2CommandExecute(object parameter)
        {
            return true;
        }
        #endregion

        #region Добавление полотна ограждения в список
        public ICommand AddBeamSetupCommand { get; }
        
        private void OnAddBeamSetupCommandExecuted(object parameter)
        {
            var newBeamSetup = new BeamSetup()
            {
                OffsetX = 0.3,
                OffsetZ = 0.5
            };

            BeamCollection.Add(newBeamSetup);
        }

        private bool CanAddBeamSetupCommandExecute(object parameter)
        {
            return true;
        }
        #endregion

        #region Удаление полотна ограждения из списка
        public ICommand DeleteBeamSetupCommand { get; }

        private void OnDeleteBeamSetupCommandExecuted(object parameter)
        {
            var lastBeamSetup = BeamCollection.LastOrDefault();

            if(!(lastBeamSetup is null))
            {
                BeamCollection.Remove(lastBeamSetup);
            }
        }

        private bool CanDeleteBeamSetupCommandExecute(object parameter)
        {
            return true;
        }
        #endregion

        #region Создание барьерного ограждения
        public ICommand CreateSafetyBarrierCommand { get; }

        private void OnCreateSafetyBarrierCommandExecuted(object parameter)
        {
            RevitModel.GetBoundParameters();
            RevitModel.GetLocationPostFamilyInstances(IsRotatePosts,
                                                 SelectedAlignmentSafityBarrier,
                                                 IsIncludeStartPost,
                                                 IsIncludeFinishPost,
                                                 PostStep);
            RevitModel.GetLocationBeamFamilyInstances(IsRotateOn180,
                                                      SelectedAlignmentSafityBarrier,
                                                      BeamCollection,
                                                      BeamLength);
            RevitModel.CreateSafetyBarrier(PostFamilySymbol);
            SaveSettings();
            RevitCommand.mainView.Close();
        }

        public bool CanCreateSafetyBarrierCommandExecute(object parameter)
        {
            return true;
        }
        #endregion

        #region Закрыть окно
        public ICommand CloseWindow { get; }

        private void OnCloseWindowCommandExecuted(object parameter)
        {
            SaveSettings();
            RevitCommand.mainView.Close();
        }

        private bool CanCloseWindowCommandExecute(object parameter)
        {
            return true;
        }
        #endregion

        #endregion

        private void SaveSettings()
        {
            Properties.Settings.Default["BarrierAxisElemIds"] = BarrierAxisElemIds;
            Properties.Settings.Default["BoundCurve1"] = BoundCurve1;
            Properties.Settings.Default["BoundCurve2"] = BoundCurve2;
            Properties.Settings.Default["PostIndex"] = GenericModelFamilySymbols.IndexOf(PostFamilySymbol);
            Properties.Settings.Default["PostStep"] = PostStep;
            Properties.Settings.Default["IsIncludeStartPost"] = IsIncludeStartPost;
            Properties.Settings.Default["IsIncludeFinishPost"] = IsIncludeFinishPost;
            Properties.Settings.Default["BeamLength"] = BeamLength;
            Properties.Settings.Default["IsReverseBeams"] = IsReverseBeams;
            Properties.Settings.Default["SelectedAlignmentSafityBarrier"] = SelectedAlignmentSafityBarrier;
            Properties.Settings.Default["IsRotateOn180"] = IsRotateOn180;
            Properties.Settings.Default.BeamCollection = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.IsRotatePosts = IsRotatePosts;
            foreach (var beam in BeamCollection)
            {
                Properties.Settings.Default.BeamCollection.Add(beam.ConvertToString(BeamFamilySymbols));
            }
            Properties.Settings.Default.Save();
        }


        #region Конструктор класса MainWindowViewModel
        public MainWindowViewModel(RevitModelForfard revitModel)
        {
            RevitModel = revitModel;

            GenericModelFamilySymbols = RevitModel.GetPostFamilySymbolNames();

            BeamFamilySymbols = RevitModel.GetBeamFamilySymbolNames();

            AlignmentSafityBarrier = new ObservableCollection<string>
            {
                "Начало",
                "Конец",
                "Середина"
            };

            BeamCollection = new ObservableCollection<BeamSetup>();

            if (!(Properties.Settings.Default.BeamCollection is null))
            {
                foreach (var beamString in Properties.Settings.Default.BeamCollection)
                {
                    var beam = beamString.Split();
                    double offsetX = double.Parse(beam[0]);
                    double offsetZ = double.Parse(beam[1]);
                    int indexBeamSymbol = int.Parse(beam[2]);
                    bool isMirrored = false;
                    if (beam.Length >= 4)
                    {
                        isMirrored = bool.Parse(beam[3]);
                    }

                    if (indexBeamSymbol >= 0 && indexBeamSymbol <= BeamFamilySymbols.Count - 1)
                    {
                        BeamCollection.Add(new BeamSetup()
                        {
                            OffsetX = offsetX,
                            OffsetZ = offsetZ,
                            FamilyAndSymbolName = BeamFamilySymbols.ElementAt(indexBeamSymbol),
                            IsMirrored = isMirrored
                        });
                    }
                    else
                    {
                        BeamCollection.Add(new BeamSetup()
                        {
                            OffsetX = offsetX,
                            OffsetZ = offsetZ,
                            IsMirrored = isMirrored
                        });
                    }
                }
            }

            #region Инициализация значения элементам оси из Settings
            if (!(Properties.Settings.Default["BarrierAxisElemIds"] is null))
            {
                string barrierAxisElementIdInSettings = Properties.Settings.Default["BarrierAxisElemIds"].ToString();
                if(RevitModel.IsAxisLinesExistInModel(barrierAxisElementIdInSettings) && !string.IsNullOrEmpty(barrierAxisElementIdInSettings))
                {
                    BarrierAxisElemIds = barrierAxisElementIdInSettings;
                    RevitModel.GetAxisBySettings(barrierAxisElementIdInSettings);
                }
            }
            #endregion

            #region Инициализация значения элемента границы 1
            if (!(Properties.Settings.Default["BoundCurve1"] is null))
            {
                string bound1ElementIdInSettings = Properties.Settings.Default["BoundCurve1"].ToString();
                if(RevitModel.IsBoundLineExistInModel(bound1ElementIdInSettings) && !string.IsNullOrEmpty(bound1ElementIdInSettings))
                {
                    BoundCurve1 = bound1ElementIdInSettings;
                    RevitModel.GetBound1BySettings(bound1ElementIdInSettings);
                }
            }
            #endregion

            #region Инициализация значения элемента граница 2
            if (!(Properties.Settings.Default["BoundCurve2"] is null))
            {
                string bound2ElementIdInSettings = Properties.Settings.Default["BoundCurve2"].ToString();
                if(RevitModel.IsBoundLineExistInModel(bound2ElementIdInSettings) && !string.IsNullOrEmpty(bound2ElementIdInSettings))
                {
                    BoundCurve2 = bound2ElementIdInSettings;
                    RevitModel.GetBound2BySettings(bound2ElementIdInSettings);
                }
            }
            #endregion

            #region Инициализация значения типоразмера стойки
            if(_postIndex >= 0 && _postIndex <= GenericModelFamilySymbols.Count - 1)
            {
                PostFamilySymbol = GenericModelFamilySymbols.ElementAt(_postIndex);
            }
            #endregion

            #region Команды
            GetBarrierAxisCommand = new LambdaCommand(OnGetBarrierAxisCommandExecuted, CanGetBarrierAxisCommandExecute);

            GetBoundCurve1Command = new LambdaCommand(OnGetBoundCurve1CommandExecuted, CanGetBoundCurve1CommandExecute);

            GetBoundCurve2Command = new LambdaCommand(OnGetBoundCurve2CommandExecuted, CanGetBoundCurve2CommandExecute);

            AddBeamSetupCommand = new LambdaCommand(OnAddBeamSetupCommandExecuted, CanAddBeamSetupCommandExecute);

            DeleteBeamSetupCommand = new LambdaCommand(OnDeleteBeamSetupCommandExecuted, CanDeleteBeamSetupCommandExecute);

            CreateSafetyBarrierCommand = new LambdaCommand(OnCreateSafetyBarrierCommandExecuted, CanCreateSafetyBarrierCommandExecute);

            CloseWindow = new LambdaCommand(OnCloseWindowCommandExecuted, CanCloseWindowCommandExecute);
            #endregion
        }

        public MainWindowViewModel() { }
        #endregion
    }
}
