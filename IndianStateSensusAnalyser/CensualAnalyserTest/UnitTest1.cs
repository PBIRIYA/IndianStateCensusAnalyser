using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndianStateSensusAnalyser;
using IndianStateSensusAnalyser.DTO;
using static IndianStateSensusAnalyser.CensusAnalyser;
using Assert = NUnit.Framework.Assert;

namespace CensusAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles\IndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles\IndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles\WrongIndiaStateCensus.csv.";
        static string wrongIndianStateCensusFileType = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles";
        static string delimiterIndianStateCodeFilePath = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles\WrongIndiaStateCode.csv";
        //US Census FilePath
        static string usCensusHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        static string usCensusFilepath = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles\USCSVFiles\USCensusData.csv";
        static string wrongUSCensusFilePath = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles\USCSVFiles\USData.csv";
        static string wrongUSCensusFileType = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles\USCSVFiles\USCensusData.txt";
        static string wrongHeaderUSCensusFilePath = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles\USCSVFiles\WrongHeaderUSCensusData.csv";
        static string delimeterUSCensusFilePath = @"D:\IndianStateSensusAnalyser\NUnitTestProject1\CSVFiles\USCSVFiles\DelimiterUSCensusData.csv";

        [TestMethod]
        public void TestMethod1()
        {
                    

        }
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
    }
}
