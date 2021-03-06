﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service;
using Utility;
using DL.Entity;

namespace BL
{
    public class LookUpManager : ILookupService
    {
        public List<LookupModel> AdvanceSearch(LookUp lookUp, string searchText)
        {
            try
            {
                List<LookupModel> list = new List<LookupModel>();
                switch (lookUp)
                {
                    case LookUp.Department:
                        Department departmentEntity = new Department();
                        return list = departmentEntity.AdvanceSearch(searchText);
                    case LookUp.RoleCategory:
                        RoleCategory roleCategoryEntity = new RoleCategory();
                        return list = roleCategoryEntity.AdvanceSearch(searchText);
                    case LookUp.Status:
                        Status statusEntity = new Status();
                        return list = statusEntity.AdvanceSearch(searchText);
                    case LookUp.OPDRate:
                        OPDRate OPDRateEntity = new OPDRate();
                        return list = OPDRateEntity.AdvanceSearch(searchText);
                    case LookUp.RoomType:
                        RoomType RoomTypeEntity = new RoomType();
                        return list = RoomTypeEntity.AdvanceSearch(searchText);
                    case LookUp.Ward:
                        WardDetail WardDetailEntity = new WardDetail();
                        return list = WardDetailEntity.AdvanceSearch(searchText);
                    default:
                        return list;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public bool Create(LookUp lookUp, LookupModel model)
        {
            try
            {
                bool isSaved = false;
                switch (lookUp)
                {
                    case LookUp.Department:
                        Department departmentEntity = new Department();
                        return isSaved = departmentEntity.Create(model);
                    case LookUp.RoleCategory:
                        RoleCategory roleCategoryEntity = new RoleCategory();
                        return isSaved = roleCategoryEntity.Create(model);
                    case LookUp.Status:
                        Status statusEntity = new Status();
                        return isSaved = statusEntity.Create(model);
                    case LookUp.OPDRate:
                        OPDRate OPDRateEntity = new OPDRate();
                        return isSaved = OPDRateEntity.Create(model);
                    case LookUp.RoomType:
                        RoomType roomTypeEntity = new RoomType();
                        return isSaved = roomTypeEntity.Create(model);
                    case LookUp.Ward:
                        WardDetail wardEntity = new WardDetail();
                        return isSaved = wardEntity.Create(model);
                    case LookUp.TPLab:
                        TPLabPatientMapping labMap = new TPLabPatientMapping();
                        return isSaved = labMap.Create(model);
                    default:
                        return isSaved;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(LookUp lookUp, Guid id)
        {
            throw new NotImplementedException();
        }

        public List<LookupModel> Get(LookUp lookUp)
        {
            try
            {
                List<LookupModel> list = new List<LookupModel>();
                switch (lookUp)
                {
                    case LookUp.Department:
                        Department departmentEntity = new Department();
                        return list = departmentEntity.Get();
                    case LookUp.RoleCategory:
                        RoleCategory roleCategoryEntity = new RoleCategory();
                        return list = roleCategoryEntity.Get();
                    case LookUp.Status:
                        Status statusEntity = new Status();
                        return list = statusEntity.Get();
                    case LookUp.OPDRate:
                        OPDRate OPDRateEntity = new OPDRate();
                        return list = OPDRateEntity.Get();
                    case LookUp.RoomType:
                        RoomType roomTypeEntity = new RoomType();
                        return list = roomTypeEntity.Get();
                    case LookUp.Ward:
                        WardDetail wardEntity = new WardDetail();
                        return list = wardEntity.Get();
                    default:
                        return list;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<LookupModel> GetNextStatus(LookUp lookUp, int sequence)
        {
            try
            {
                List<LookupModel> list = new List<LookupModel>();
                switch (lookUp)
                {
                    case LookUp.Status:
                        Status statusEntity = new Status();
                        return list = statusEntity.GetNextStatus(sequence);
                    default:
                        return list;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LookupModel GetById(LookUp lookUp, Guid id)
        {
            try
            {
                LookupModel model = new LookupModel();
                switch (lookUp)
                {
                    case LookUp.Department:
                        Department departmentEntity = new Department();
                        return model = departmentEntity.GetById(id);
                    case LookUp.RoleCategory:
                        RoleCategory roleCategoryEntity = new RoleCategory();
                        return model = roleCategoryEntity.GetById(id);
                    case LookUp.Status:
                        Status statusEntity = new Status();
                        return model = statusEntity.GetById(id);
                    case LookUp.OPDRate:
                        OPDRate OPDRateEntity = new OPDRate();
                        return model = OPDRateEntity.GetById(id);
                    case LookUp.RoomType:
                        RoomType roomTypeEntity = new RoomType();
                        return model = roomTypeEntity.GetById(id);
                    case LookUp.Ward:
                        WardDetail wardEntity = new WardDetail();
                        return model = wardEntity.GetById(id);
                    case LookUp.TPLab:
                        TPLabPatientMapping labMap = new TPLabPatientMapping();
                        return model = labMap.GetById(id);
                    default:
                        return model;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LookupModel GetByName(LookUp lookUp, string name)
        {
            try
            {
                LookupModel model = new LookupModel();
                switch (lookUp)
                {
                    case LookUp.Department:
                        Department departmentEntity = new Department();
                        return model = departmentEntity.GetByName(name);
                    case LookUp.RoleCategory:
                        RoleCategory roleCategoryEntity = new RoleCategory();
                        return model = roleCategoryEntity.GetByName(name);
                    case LookUp.Status:
                        Status statusEntity = new Status();
                        return model = statusEntity.GetByName(name);
                    case LookUp.OPDRate:
                        return model = OPDRate.GetRatesByType(name);
                    case LookUp.RoomType:
                        RoomType roomTypeEntity = new RoomType();
                        return model = roomTypeEntity.GetByName(name);
                    case LookUp.Ward:
                        WardDetail wardEntity = new WardDetail();
                        return model = wardEntity.GetByName(name);
                    default:
                        return model;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LookupModel GetByParentId(LookUp lookUp, Guid id)
        {
            try
            {
                LookupModel model = new LookupModel();
                switch (lookUp)
                {
                    case LookUp.Status:
                        Status statusEntity = new Status();
                        return model = statusEntity.GetByParentId(id);
                    default:
                        return model;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(LookUp lookUp, LookupModel model)
        {
            try
            {
                bool isSaved = false;
                switch (lookUp)
                {
                    case LookUp.Department:
                        Department departmentEntity = new Department();
                        return isSaved = departmentEntity.Update(model);
                    case LookUp.RoleCategory:
                        RoleCategory roleCategoryEntity = new RoleCategory();
                        return isSaved = roleCategoryEntity.Update(model);
                    case LookUp.Status:
                        Status statusEntity = new Status();
                        return isSaved = statusEntity.Update(model);
                    case LookUp.OPDRate:
                        OPDRate OPDRateEntity = new OPDRate();
                        return isSaved = OPDRateEntity.Update(model);
                    case LookUp.RoomType:
                        RoomType roomTypeEntity = new RoomType();
                        return isSaved = roomTypeEntity.Update(model);
                    case LookUp.Ward:
                        WardDetail wardEntity = new WardDetail();
                        return isSaved = wardEntity.Update(model);
                    case LookUp.TPLab:
                        TPLabPatientMapping labMap = new TPLabPatientMapping();
                        return isSaved = labMap.Update(model);
                    default:
                        return isSaved;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LookupModel GetRatesByType(string type)
        {
            return OPDRate.GetRatesByType(type);
        }

        public List<LookupModel> GetByOPDId(Guid id)
        {
            return new TPLabPatientMapping().GetByOPDId(id);
        }

        public bool CreateUpdate(List<LookupModel> model)
        {
            return new TPLabPatientMapping().CreateUpdate(model);
        }

        public decimal GetTPAmount(Guid id)
        {
            return TPLabPatientMapping.GetTPAmount(id);
        }
    }
}
