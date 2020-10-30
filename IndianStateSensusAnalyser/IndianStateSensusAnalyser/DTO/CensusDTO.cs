﻿using System;
using System.Collections.Generic;
using System.Text;
using IndianStateSensusAnalyser.POCO;
namespace IndianStateSensusAnalyser.DTO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;
        public CensusDTO(StateCodeDAO stateCodeDao)
        {
            this.serialNumber = stateCodeDao.serialNumber;
            this.stateName = stateCodeDao.stateName;
            this.tin = stateCodeDao.tin;
            this.stateCode = stateCodeDao.stateCode;
        }
        public CensusDTO(CensusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }

        public CensusDTO(POCO.CensusDataDAO censusDataDAO)
        {
        }
        //public CensusDTO(USCensusDAO usCensusDao)
        //{
        //    this.stateCode = usCensusDao.stateId;
        //    this.stateName = usCensusDao.stateName;
        //    this.population = usCensusDao.population;
        //    this.housingUnits = usCensusDao.housingUnits;
        //    this.totalArea = usCensusDao.totalArea;
        //    this.waterArea = usCensusDao.waterArea;
        //    this.landArea = usCensusDao.landArea;
        //}
    }
    public class CensusDataDAO
    {
        public string state;
        public long population;
        public long area;
        public long density;
        public CensusDataDAO(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToUInt32(population);
            this.area = Convert.ToUInt32(area);
            this.density = Convert.ToUInt32(density);
        }
    }
}



