using System.Linq;

namespace Business.Interfaces
{
    public interface IRepository<TCondition, TSource, TResult, TKey> where TCondition : class
    {
        /// <summary>
        /// 執行狀態
        /// </summary>
        bool State { get; set; }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="content">新增資料內容</param>
        /// <returns>索引值</returns>
        TKey Create(TSource content);

        /// <summary>
        /// 讀取單一資料
        /// </summary>
        /// <param name="key">主鍵</param>
        /// <returns></returns>
        TResult Get(TKey key);

        /// <summary>
        /// 取得列表
        /// </summary>
        /// <param name="condition">條件</param>
        /// <returns>回傳多個結果</returns>
        IQueryable<TResult> Read(TCondition condition);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="content">內容</param>
        /// <returns>修改後的資料</returns>
        TResult Update(TCondition content);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <typeparam name="TCondition">查詢條件型態</typeparam>
        /// <param name="condition">查詢條件</param>
        /// <returns>受影響的資料筆數</returns>
        int UpdateAll(TCondition condition);

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="condition">條件</param>
        /// <returns>結果成功失敗</returns>
        bool Delete(TKey key);
        /// <summary>
        /// 批量刪除
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>結果成功失敗</returns>
        bool DeleteAll(TCondition condition);
    }

    /// <summary>
    /// 實作一般資料維護(Ex:Entity Database)
    /// </summary>
    /// <typeparam name="TSource">輸入屬性類別</typeparam>
    public interface IRepository<TCondition, TSource> : IRepository<TCondition, TSource, TSource, int>
        where TSource : class
        where TCondition : class
    {
    }

    /// <summary>
    /// 實作一般資料維護(Ex:Entity Database)
    /// </summary>
    /// <typeparam name="TSource">輸入屬性類別</typeparam>
    /// <typeparam name="TCondition">條件</typeparam>
    /// <typeparam name="TDbContext">DbContext</typeparam>
    public interface IRepositoryTransaction<TCondition, TSource, TDbContext> : IRepository<TCondition, TSource>
        where TCondition : class
        where TSource : class
        where TDbContext : System.Data.Entity.DbContext
    {
        /// <summary>
        /// 內容實體
        /// </summary>
        TDbContext Context { get; set; }
    }
}
