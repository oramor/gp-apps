using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lib.Wpf.Core
{
    public abstract class ContextBase : INotifyPropertyChanged
    {
        /// <summary>
        /// ������� ��������� �������������� WPF � ���, ��� �������� ����������
        /// �, ��� ���������, ���������� �������� ��� ����������, �������
        /// � ���� ��������
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// ����� ������������ ��� ���������� �������������� WPF � ���, ��� ��������
        /// ��������� ���� �������� � ���������� �������� ����������, ������� ��������
        /// �� ���� ����� �������. ����� ���������� �� �������������� Set(), � ��� ��
        /// ����� ���� ������ ��������.
        /// </summary>
        protected virtual void OnPropertyChaged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        /// <summary>
        /// ����� ���� �������, ������� ������� ������������� �������� OnPropertyChanged
        /// �������� � �������� ������� ���������.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentValue"></param>
        /// <param name="fieldValue"></param>
        /// <param name="PropertyName">��������� ��� ��������, ���������� ����� ��������� nameof()</param>
        /// <returns></returns>
        protected virtual bool Set<T>(ref T currentValue, T fieldValue, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(fieldValue, currentValue)) return false;

            currentValue = fieldValue;
            OnPropertyChaged(PropertyName);

            return true;
        }
    }
}
