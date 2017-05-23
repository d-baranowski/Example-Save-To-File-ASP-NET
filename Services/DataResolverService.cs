using System;

namespace SaveToTextFileOnServer.Services
{
    public interface IDataResolver
    {
        void addToText(string one, string two);
        string getEntireText();
    }

    public class DataResolverService : IDataResolver
    {
        private readonly IDataProvider _dataProvider;

        public DataResolverService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void addToText(string one, string two)
        {
            _dataProvider.Write(one + two);
        }

        public string getEntireText()
        {
            return _dataProvider.Read();
        }
    }
}