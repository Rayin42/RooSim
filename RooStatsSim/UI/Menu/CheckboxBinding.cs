﻿using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using System.Globalization;

using RooStatsSim.User;
using RooStatsSim.DB.Table;

namespace RooStatsSim.UI.Menu
{
    public enum SavePoint
    {
        A=1,
        B,
        C,
        D,
    }
    public class CheckboxBinding : INotifyPropertyChanged
    {
        public CheckboxBinding() { _job = JOB_SELECT_LIST.NOVICE; _point = SavePoint.A; OnPropertyChanged("Point"); }
        private SavePoint _point;
        private JOB_SELECT_LIST _job;
        public SavePoint Point
        {
            get { return _point; }
            set {
                if (_point == value)
                    return;

                MainWindow._user_data_manager.SetUserData((int)value);
                _point = value;
                OnPropertyChanged("Point");
            }
        }
        public JOB_SELECT_LIST Job
        {
            get { return _job; }
            set
            {
                if (_job == value)
                    return;

                MainWindow._user_data_manager.Data.Job = value;
                _job = value;
                OnPropertyChanged("Job");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }

    public class EnumToBooleanConverter : IValueConverter
    {
        #region 변환하기 - Convert(value, targetType, parameter, cultureInfo)
        /// <summary>
        /// 변환하기
        /// </summary>
        /// <param name="value">값</param>
        /// <param name="targetType">타겟 타입</param>
        /// <param name="parameter">매개 변수</param>
        /// <param name="cultureInfo">문화 정보</param>
        /// <returns>변환 값</returns>

        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            string parameterString = parameter as string;

            if (parameterString == null)
            {
                return DependencyProperty.UnsetValue;
            }
            if (Enum.IsDefined(value.GetType(), value) == false)
            {
                return DependencyProperty.UnsetValue;
            }
            object parameterValue = Enum.Parse(value.GetType(), parameterString);
            return parameterValue.Equals(value);
        }
        #endregion
        #region 역변환하기 - ConvertBack(value, targetType, parameter, cultureInfo)
        /// <summary>
        /// 역변환하기
        /// </summary>
        /// <param name="value">값</param>
        /// <param name="targetType">타겟 타입</param>
        /// <param name="parameter">매개 변수</param>
        /// <param name="cultureInfo">문화 정보</param>
        /// <returns>역변환 값</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            string parameterString = parameter as string;
            if (parameterString == null)
            {
                return DependencyProperty.UnsetValue;
            }
            return Enum.Parse(targetType, parameterString);
        }
        #endregion
    }
}
