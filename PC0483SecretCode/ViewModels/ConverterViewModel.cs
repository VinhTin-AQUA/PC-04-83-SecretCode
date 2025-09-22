using System;
using System.Reactive;
using ReactiveUI;

namespace PC0483SecretCode.ViewModels
{
    public class ConverterViewModel : ViewModelBase
    {
        private bool _convertToCode;
        public bool ConvertToCode
        {
            get => _convertToCode;
            set => this.RaiseAndSetIfChanged(ref this._convertToCode, value);
        }

        private string _input1;
        public string Input1
        {
            get => _input1;
            set => this.RaiseAndSetIfChanged(ref _input1, value);
        }

        private string _input2;

        public string Input2
        {
            get => _input2;
            set => this.RaiseAndSetIfChanged(ref _input2, value);
        }
        
        public ReactiveCommand<Unit, Unit> ConvertCommand { get; set; }

        public ConverterViewModel()
        {
            ConvertCommand = ReactiveCommand.Create(() =>
            {
                
            });
        }
        
        public override void Dispose()
        {
            // các lệnh giải phóng tài nguyên
            base.Dispose();
        }
    }
}