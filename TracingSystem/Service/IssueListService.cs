using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TracingSystem.Models;

namespace TracingSystem.Service
{
    public class IssueListService : IIssueListService
    {

        private readonly SystemTrackingDBContext _db;

        public IssueListService(SystemTrackingDBContext db)
        {
            _db = db;
        }
        public List<IssueList> GetIssueList()
        {
            var result = _db.IssueLists.ToList();
            return result;
        }

        public IssueList GetIssueList(int Id)
        {
            var result = _db.IssueLists.FirstOrDefault(x => x.Id == Id);
            return result;
        }

        public ServiceResult InsertIssue(IssueList issue, int userId)
        {
           
            var dt = DateTime.Now;
            issue.CreateDt = dt;
            issue.LstMaintDt = dt;
            issue.CreateUserId = userId;
            issue.LstMaintUserId = userId;
            issue.Status = 0;
            try
            {
                _db.IssueLists.Add(issue);
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                return ServiceResult.Fail(ex.ToString());
            }
          
            return ServiceResult.Success("新增成功");
        }

        public ServiceResult DeleteIssue(int Id)
        {          
            try
            {
                var record = _db.IssueLists.First(x => x.Id == Id);
                _db.IssueLists.Remove(record);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.ToString());
            }

            return ServiceResult.Success("刪除成功");
        }

        public ServiceResult UpdateIssue(IssueList issue, int userId)
        {
            try
            {
                var record = _db.IssueLists.FirstOrDefault(x => x.Id == issue.Id);
                var dt = DateTime.Now;
                record.Summary = issue.Summary;
                record.Description = issue.Description;
                record.LstMaintDt = dt;
                record.LstMaintUserId = userId;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.ToString());
            }

            return ServiceResult.Success("刪除成功");
        }

        public ServiceResult UpdateIssueStatus(int Id, int userId)
        {
            try
            {
                var record = _db.IssueLists.FirstOrDefault(x => x.Id == Id);
                var dt = DateTime.Now;
                record.Status = 1;
                record.LstMaintDt = dt;
                record.LstMaintUserId = userId;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.ToString());
            }

            return ServiceResult.Success("刪除成功");
        }

    }
}
