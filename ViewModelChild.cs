using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace WpfAppPerformance
{
    public sealed class ViewModelChild : ReactiveObject
    {
        [Reactive]
        public int Count
        {
            get;
            set;
        }
    }
}
