using System;
using Business.Interfaces;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;

namespace Business.Services
{
    public class TestService : IService<TestServiceCondition, TestServiceResult>
    {
        /// <summary>
        /// 商業邏輯傳遞參數
        /// </summary>
        private TestServiceCondition _Resource;
        public TestServiceCondition Resources
        {
            get { return _Resource; }
            set { _Resource = value; }
        }

        /// <summary>
        /// 執行狀態
        /// </summary>
        public bool State
        {
            get;
            set;
        }

        /// <summary>
        /// 執行狀態訊息
        /// </summary>
        public string StateMessage
        {
            get;
            set;
        }

        /// <summary>
        /// 檢查傳入參數
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
            if(_Resource == null)
            {
                this.StateMessage = "請傳入 TestServiceCondition";
                this.State = false;
            }
            return true;
        }

        /// <summary>
        /// 執行商業邏輯
        /// </summary>
        /// <returns></returns>
        public TestServiceResult Work()
        {
            TestServiceResult result = new TestServiceResult();
            try
            {

            }
            catch(Exception ex)
            {

            }
            return result;
        }
    }
}
