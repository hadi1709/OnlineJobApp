﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineJobApplication.App_Data;
using OnlineJobApplication.Models;

namespace OnlineJobApplication
{
    public class CommonHelper
    {
        public static List<CountryModel> GetCountryList()
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var obj = (from country in db.Countries
                              select new CountryModel {
                                  CountryId = country.CountryID,
                                  CountryName = country.CountryName,
                                  Nationality = country.Nationality                               
                              }).ToList();

                    return obj;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public static List<ReligionModel> GetReligionList()
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var obj = (from religion in db.Religions
                               select new ReligionModel
                               {
                                   Id = religion.Id,
                                   Name = religion.Name
                               }).ToList();

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<CareerAreaModel> GetCareeerAreaList()
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var queryCareerAreas = (from career in db.CareerAreas
                                            select new CareerAreaModel
                                            {
                                                Id = career.Id,
                                                Name = career.Name
                                            }).ToList();

                    return queryCareerAreas;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<JobModel> GetAllJobList()
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var queryJobs = (from job in db.Jobs
                                     where job.IsDeleted == false
                                     select new JobModel
                                     {
                                         Id = job.Id,
                                         CareerAreasId = job.CareerAreasId,
                                         CareerAreas = job.CareerArea.Name,
                                         DateOpened = job.DateOpened,
                                         DateClosed = job.DateClosed,
                                         Description = job.Description,
                                         Qualification = job.Qualification,
                                         Title = job.Title
                                     }).ToList();

                    foreach(var jobElement in queryJobs)
                    {
                        jobElement.DateOpenedString = jobElement.DateOpened.ToString("dd MMMM yyyy");
                        jobElement.DateClosedString = jobElement.DateClosed.ToString("dd MMMM yyyy");
                    }

                    return queryJobs.OrderBy(x => x.DateOpened).ToList();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public static JobModel GetJobById(int? jobId)
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var queryJobs = (from job in db.Jobs
                                    where job.Id == jobId
                                    select new JobModel
                                    {
                                        Id = job.Id,
                                        CareerAreasId = job.CareerAreasId,
                                        CareerAreas = job.CareerArea.Name,
                                        DateOpened = job.DateOpened,
                                        DateClosed = job.DateClosed,
                                        Description = job.Description,
                                        Qualification = job.Qualification,
                                        Title = job.Title
                                    }).FirstOrDefault();

                        queryJobs.DateOpenedString = queryJobs.DateOpened.ToString("dd MMMM yyyy");
                        queryJobs.DateClosedString = queryJobs.DateClosed.ToString("dd MMMM yyyy");

                    return queryJobs;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public static List<JobModel> GetJobListbyDate()
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    DateTime currentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    var queryJobs = (from job in db.Jobs
                                     where job.IsDeleted == false &&
                                     job.DateOpened <= currentDate && job.DateClosed >= currentDate
                                     select new JobModel
                                     {
                                         Id = job.Id,
                                         CareerAreasId = job.CareerAreasId,
                                         CareerAreas = job.CareerArea.Name,
                                         DateOpened = job.DateOpened,
                                         DateClosed = job.DateClosed,
                                         Description = job.Description,
                                         Qualification = job.Qualification,
                                         Title = job.Title
                                     }).ToList();

                    foreach (var jobElement in queryJobs)
                    {
                        jobElement.DateOpenedString = jobElement.DateOpened.ToString("dd MMMM yyyy");
                        jobElement.DateClosedString = jobElement.DateClosed.ToString("dd MMMM yyyy");
                    }

                    return queryJobs.OrderBy(x => x.DateOpened).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int GetUserByAspId (string aspUserId)
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var queryUser = (from user in db.Users
                                     where user.AspUserId == aspUserId
                                     select user.Id).FirstOrDefault();

                    return queryUser;
                }
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public static List<UserModel> GetUserModelByJobAppliedId(int jobId)
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var queryUserJob = (from job in db.UserJobApplications
                                        join jobStage in db.UserJobApplicationStages on job.Id equals jobStage.UserJobApplicationId                                      
                                        where job.JobId == jobId
                                        select new UserModel
                                        {
                                            Id = job.User.Id,
                                            Name = job.User.Name,
                                            Address = job.User.Address,
                                            Country = job.User.Country.CountryName,
                                            IcNumber = job.User.IcNumber,
                                            PhoneNumber = job.User.PhoneNumber,
                                            Religion = job.User.Religion.Name,
                                            CurrentStage = jobStage.Stage.Name
                                        }).ToList();

                    return queryUserJob;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static UserModel GetUserById(int? userId)
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var queryUser = (from user in db.Users
                                     where user.Id == userId
                                     select new UserModel {
                                         Id = user.Id,
                                         Name = user.Name,
                                         Address = user.Address,
                                         Country = user.Country.CountryName,
                                         IcNumber = user.IcNumber,
                                         PhoneNumber = user.PhoneNumber,
                                         Religion = user.Religion.Name
                                     }).FirstOrDefault();

                    return queryUser;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static StageModel GetCurrentStage (int? jobId, int? userId)
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var queryStage = (from stage in db.UserJobApplicationStages
                                      where stage.UserJobApplication.JobId == jobId &&
                                      stage.UserJobApplication.User.Id == userId
                                      select new StageModel
                                      {
                                          Id = stage.StageId,
                                          Name = stage.Stage.Name,
                                          IndexNumber = stage.Stage.IndexNumber,
                                          UserJobApplicationId = stage.UserJobApplicationId
                                      }).FirstOrDefault();

                    return queryStage;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<StageModel> GetNextStageIndexNumber(StageModel currentStage)
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    if(currentStage.Id == 7)
                    {
                        List<StageModel> stage = new List<StageModel>();
                        stage.Add(currentStage);
                        return stage;
                    }

                    int? nextStageIndexNumber = currentStage.IndexNumber + 1;


                    var queryStage = (from stage in db.Stages
                                      where stage.IndexNumber == nextStageIndexNumber || stage.Name == "Rejected"
                                      select new StageModel {
                                          Id = stage.Id,
                                          Name = stage.Name,
                                          IndexNumber = stage.IndexNumber
                                      }).ToList();

                    return queryStage;
                }
            }
            catch (Exception ex)
            {
                throw;
            }           
        }

        public static List<JobModel> GetJobListByUserId(string userId)
        {
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var queryJobApplication = (from jobApplication in db.UserJobApplications
                                               join jobAppStage in db.UserJobApplicationStages on jobApplication.Id equals jobAppStage.UserJobApplicationId
                                               where jobApplication.User.AspUserId == userId &&
                                               jobApplication.Job.IsDeleted == false
                                               select new JobModel
                                               {
                                                   Title = jobApplication.Job.Title,
                                                   CurrentStage = jobAppStage.Stage.Name
                                               }).ToList();

                    return queryJobApplication;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public const int StatusError = 2;

        public const int StatusOk = 1;
    }
}