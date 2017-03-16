namespace Business.Interfaces
{
    /// <summary>
    /// 商業邏輯運算介面
    /// </summary>
    /// <typeparam name="TCondition">商業邏輯條件</typeparam>
    /// <typeparam name="TResult">結果</typeparam>
    public interface IService<TCondition, TResult>
    {
        /// <summary>
        /// 執行階段的訊息
        /// </summary>
        string StateMessage { get; set; }

        /// <summary>
        /// 執行狀態
        /// </summary>
        bool State { get; set; }

        /// <summary>
        /// 屬性/資料 來源
        /// </summary>
        TCondition Resources { set; get; }

        /// <summary>
        /// 執行階段的訊息
        /// </summary>
        bool Check();

        /// <summary>
        /// 實作結果
        /// </summary>
        /// <returns>輸出結果</returns>
        TResult Work();
    }
}
