using Lib.Core;

namespace Lib.Services.Print
{
    /// <summary>
    /// Сетап связывает поддерживаемую этикетку с принтером пользователя.
    /// Таким образом, сетап является объектом диспетчеризации, по котором
    /// система определяет, какой принтер следует выбрать для печати этикетки
    /// данного вида. При этом один тип (CommonLabel) может печататься только
    /// на одном принтере.
    /// </summary>
    public interface ILabelSetup : IEntity
    {
        ISupportedLabel SupportedLabel { get; init; }
        IPrinter SystemPrinter { get; init; }
    }
}
