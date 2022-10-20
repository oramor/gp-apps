using System.Windows.Controls;

namespace LibForm
{
    /// <summary>
    /// Этому интерфейсу должны соответствовать поля внутри FormData
    /// </summary>
    interface IFormField
    {
        string FieldName { get; set; }
        string Value { get; set; }
    }

    public class Form : StackPanel
    {
        static Form()
        {
        }
        public Form() : base()
        {
        }
    }
}
