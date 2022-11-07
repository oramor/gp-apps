namespace Lib.Wpf.Controls.Form
{
    // DTO содержит больше полей, но они пока не актуальны. Можно добавить TopMessage
    public class SuccessFormDto
    {
        public string? Message { get; set; } = string.Empty;
        
        /// <summary>
        /// Это поле является частью реализации HTTP-аутентификации вида Form
        /// и содержит такой же токен, которые передается для куки sid веб-клиентам
        /// </summary>
        public string? SessionToken { get; set; } = string.Empty;
    }
}
