using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TracingSystem.Models;

namespace TracingSystem.Service
{
    public interface IIssueListService
    {
        public List<IssueList> GetIssueList();
        public ServiceResult InsertIssue(IssueList issue ,int userId);
        public ServiceResult DeleteIssue(int Id);

        public ServiceResult UpdateIssue(IssueList issue, int userId);
        public IssueList GetIssueList(int Id);
        public ServiceResult UpdateIssueStatus(int Id, int userId);
    }
}
