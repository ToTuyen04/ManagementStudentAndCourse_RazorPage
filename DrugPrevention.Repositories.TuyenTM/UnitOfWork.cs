using DrugPrevention.Repositories.TuyenTM.DBContext;
using DrugPrevention.Repositories.TuyenTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Repositories.TuyenTM
{
    public interface IUnitOfWork : IDisposable
    {
        CommunityProgramToanNSRepository CommunityProgramToanNSRepository { get; }
        CoursesQuangTNVRepository CoursesQuangTNVRepository { get; }
        OrganizationProgramsTuyenTMRepository OrganizationProgramsTuyenTMRepository { get; }
        OrganizationsTuyenTMRepository organizationsTuyenTMRepository { get; }
        System_UserAccountRepository System_UserAccountRepository { get; }
        UserCoursesTuyenTMRepository UserCoursesTuyenTMRepository { get; }
        UsersTuyenTmRepository UsersTuyenTmRepository { get; }

        int SaveChangesWithTransaction();
        Task<int> SaveCHagesWithTransactionAsync();
    }
    internal class UnitOfWork
    {
        private readonly SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;
        private CommunityProgramToanNSRepository _communityProgramToanNSRepository;
        private CoursesQuangTNVRepository _coursesQuangTNVRepository;
        private OrganizationProgramsTuyenTMRepository _organizationProgramsTuyenTMRepository;
        private OrganizationsTuyenTMRepository _organizationsTuyenTMRepository;
        private System_UserAccountRepository _system_UserAccount;
        private UserCoursesTuyenTMRepository _userCoursesTuyenTMRepository;
        private UsersTuyenTmRepository _usersTuyenTmRepository;

        public UnitOfWork() => _context ??= new SU25_PRN222_SE1709_G2_DrugPreventionSystemContext();

        public System_UserAccountRepository System_UserAccountRepository
        {
            get { return _system_UserAccount ??= new System_UserAccountRepository(_context); }
        }

        public CommunityProgramToanNSRepository CommunityProgramToanNSRepository
        {
            get { return _communityProgramToanNSRepository ??= new CommunityProgramToanNSRepository(_context); }
        }

        public CoursesQuangTNVRepository CoursesQuangTNVRepository
        {
            get { return _coursesQuangTNVRepository ??= new CoursesQuangTNVRepository(_context); }
        }

        public OrganizationProgramsTuyenTMRepository OrganizationProgramsTuyenTMRepository
        {
            get { return _organizationProgramsTuyenTMRepository ??= new OrganizationProgramsTuyenTMRepository(_context); }
        }
        public OrganizationsTuyenTMRepository OrganizationsTuyenTM
        {
            get { return _organizationsTuyenTMRepository ??= new OrganizationsTuyenTMRepository(_context); }
        }

        public UserCoursesTuyenTMRepository UserCoursesTuyenTMRepository
        {
            get { return _userCoursesTuyenTMRepository ??= new UserCoursesTuyenTMRepository(_context); }
        }
        public UsersTuyenTmRepository UsersTuyenTmRepository
        {
            get { return _usersTuyenTmRepository ??= new UsersTuyenTmRepository(_context); }
        }

        public void Dispose() => _context.Dispose();
        public int SaveChangesWithTransaction()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }
    }
}
