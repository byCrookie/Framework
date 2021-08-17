namespace Framework.Test.Flow.ConfigStep
{
    public class TestStepConfiguration
    {
        public string Param1 { get; set; }
        public string Param2 { get; set; }

        public TestStepConfiguration SetParam1(string param)
        {
            Param1 = param;
            return this;
        }
        
        public TestStepConfiguration SetParam2(string param)
        {
            Param2 = param;
            return this;
        }
    }
}