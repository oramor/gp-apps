using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Wpf.Controls.Form
{
    //public interface ILocalFormResult
    //{
    //    void SetDto(InvalidFormDto dto);
    //    void SetDto(SuccessFormDto dto);
    //    void SetDto(ErrorFormDto dto);
    //}

    public class LocalFormResult
    {
        private InvalidFormDto? _invalidFormDto;
        private SuccessFormDto? _successFormDto;
        private ErrorFormDto? _errorFormDto;

        public InvalidFormDto? Invalid { get => _invalidFormDto; }
        public SuccessFormDto? Success { get => _successFormDto; }
        public ErrorFormDto? Error { get => _errorFormDto; }

        public void SetDto(InvalidFormDto dto) { _invalidFormDto = dto; }
        public void SetDto(SuccessFormDto dto) { _successFormDto = dto; }
        public void SetDto(ErrorFormDto dto) { _errorFormDto = dto; }
    }
}
