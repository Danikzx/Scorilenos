using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jiofoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

enum DataType
{
    INT16,
    UINT16,
    // И еще типы есть
}

interface IValueChangedEventArgsFactory
{
    IValueChangedEventArgs GetValueChangedEventArgs(string address, DataType dataType, OperateResult oldValue, OperateResult newValue);
}

class ValueChangedEventArgsFactory : IValueChangedEventArgsFactory
{
    private IDictionary<DataType, Func<string, DataType, OperateResult, OperateResult, IValueChangedEventArgs>> factory;

    public ValueChangedEventArgsFactory()
    {
        factory = new Dictionary<DataType, Func<string, DataType, OperateResult, OperateResult, IValueChangedEventArgs>>()
    {
      { DataType.INT16, (string address, DataType dataType, OperateResult oldValue, OperateResult newValue)
        => new ValueChangedEventArgs<short>(address, dataType, oldValue, newValue) },
      { DataType.UINT16, (string address, DataType dataType, OperateResult oldValue, OperateResult newValue)
        => new ValueChangedEventArgs<ushort>(address, dataType, oldValue, newValue) }
    };
    }

    public IValueChangedEventArgs GetValueChangedEventArgs(string address, DataType dataType, OperateResult oldValue, OperateResult newValue)
    {
        factory.TryGetValue(dataType, out Func<string, DataType, OperateResult, OperateResult, IValueChangedEventArgs> func);
        return (func == null) ? throw new NotImplementedException() : func.Invoke(address, dataType, oldValue, newValue);
    }
}

interface IValueChangedEventArgs
{
    string Address { get; }
    DataType DataType { get; }
}

interface IValueChangedEventArgs<T> : IValueChangedEventArgs
{
    OperateResult<T> NewValue { get; }
    OperateResult<T> OldValue { get; }
}

class ValueChangedEventArgs<T> : System.EventArgs, IValueChangedEventArgs<T>
{
    public string Address { get; private set; }
    public DataType DataType { get; private set; }
    public OperateResult<T> OldValue { get; private set; }
    public OperateResult<T> NewValue { get; private set; }

    public ValueChangedEventArgs(string address, DataType dataType, OperateResult oldValue, OperateResult newValue)
    {
        Address = address;
        DataType = dataType;
        OldValue = (OperateResult<T>)oldValue;
        NewValue = (OperateResult<T>)newValue;
    }
}

class OperateResult
{
    public bool IsSuccess;
}

class OperateResult<T> : OperateResult
{
    public T Content;
}

public class Program
{
    public static void Main()
    {
        var factory = new ValueChangedEventArgsFactory();
        var oldValue = new OperateResult<short>() { Content = 1 };
        var newValue = new OperateResult<short>() { Content = 2 };

        var args = factory.GetValueChangedEventArgs(string.Empty, DataType.INT16, oldValue, newValue);
    }
}