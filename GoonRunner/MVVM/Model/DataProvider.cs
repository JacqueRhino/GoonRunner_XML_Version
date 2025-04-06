namespace GoonRunner.MVVM.Model
{
    public class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider Ins { get { if (_ins == null) _ins = new DataProvider(); return _ins; } set { _ins = value; } }
        public GoonRunnerEntities goonRunnerDB { get; set; }
        private DataProvider()
        {
            goonRunnerDB = new GoonRunnerEntities();
        }
    }
}
