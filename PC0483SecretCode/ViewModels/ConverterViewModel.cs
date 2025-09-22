using System;
using System.Reactive;
using PC0483SecretCode.Helpers;
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

        private string _input1 = "";
        public string Input1
        {
            get => _input1;
            set => this.RaiseAndSetIfChanged(ref _input1, value);
        }

        private string _input2 = "";
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
                if (ConvertToCode)
                {
                    // convert code to text
                    var result = ConvertTextToCode(Input1);
                    Input2 = result;
                }
                else
                {
                    var result = ConvertCodeToText(Input1);
                    Input2 = result;
                }
            });
        }
        
        public static string ConvertCodeToText(string content)
        {
            var codes = content.Split(" ");
            string decodedContent = string.Empty;
            
            foreach (var code in codes)
            {
                var texts = ConvertCodeToTextHelper.ConvertToText(code);

                for (int i = 0; i < texts.Count; i++)
                {
                    var tone = VietNameseNormalizeHelper.AddTone(texts[i]);
                    texts[i]  = VietNameseNormalizeHelper.NormalizeVietnameseAccent(tone);
                }
                
                if (texts.Count == 1)
                {
                    decodedContent += texts[0] + " ";
                }
                else
                {
                    decodedContent += $"({string.Join(",", texts)}) ";
                }
            }
            return decodedContent;
        }

        public static string ConvertTextToCode(string content)
        {
            var texts = content.Split(" ");
            string codes = "";
            foreach (var text in texts)
            {
                var code = ConvertTextToCodeHelper.SeparateVietnameseWord(text);
                codes += code + " ";
            }
            return codes;
        }
        
        public override void Dispose()
        {
            // các lệnh giải phóng tài nguyên
            base.Dispose();
        }
    }
}