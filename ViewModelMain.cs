using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Text;
using System.Windows.Data;

namespace WpfAppPerformance
{
    public sealed class ViewModelMain : ReactiveObject
    {
        [Reactive]
        public string Name
        {
            get;
            set;
        }

        [Reactive]
        public string Value
        {
            get;
            set;
        }

        [Reactive]
        public ViewModelChild Child
        {
            get;
            set;
        }

        public string Validate(BindingGroup bindingGroup)
        {
            StringBuilder errors = new StringBuilder();
            ViewModelMain item = (ViewModelMain)bindingGroup.Items[0]!;
            if (!bindingGroup.TryGetValue(item, nameof(Name), out object name) || string.IsNullOrWhiteSpace((string)name))
            {
                errors.AppendLine("Es obligatorio el nombre");
            }

            if (!bindingGroup.TryGetValue(item, nameof(Value), out object value) || string.IsNullOrWhiteSpace((string)value))
            {
                errors.AppendLine("Es obligatorio el valor");
            }

            return errors.ToString();
        }
    }
}