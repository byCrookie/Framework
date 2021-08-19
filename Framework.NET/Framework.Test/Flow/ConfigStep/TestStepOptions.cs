namespace Framework.Test.Flow.ConfigStep
{
    public class TestStepOptions
    {
        public string Param1 { get; set; }
        public string Param2 { get; set; }

        public TestStepOptions SetParam1(string param)
        {
            Param1 = param;
            return this;
        }
        
        public TestStepOptions SetParam2(string param)
        {
            Param2 = param;
            return this;
        }
    }
}