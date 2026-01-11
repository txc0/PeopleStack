using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class PeopleStackDbContext : DbContext
    {
        public PeopleStackDbContext(DbContextOptions<PeopleStackDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        public DbSet<Notice> Notices { get; set; }
        public DbSet<NoticeTarget> NoticeTargets { get; set; }
        public DbSet<NoticeRead> NoticeReads { get; set; }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        public DbSet<PayrollRun> PayrollRuns { get; set; }
        public DbSet<Payslip> Payslips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // same fluent config as before
                        base.OnModelCreating(modelBuilder);

            // -----------------------------
            // Core HR relationships
            // -----------------------------

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Designation)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee.ManagerId self reference (Manager -> Subordinates)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany(m => m.Subordinates)
                .HasForeignKey(e => e.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            // -----------------------------
            // Attendance
            // -----------------------------

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // One attendance per employee per date
            modelBuilder.Entity<Attendance>()
                .HasIndex(a => new { a.EmployeeId, a.Date })
                .IsUnique();

            // -----------------------------
            // Leave Management
            // -----------------------------

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(lr => lr.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.LeaveType)
                .WithMany(lt => lt.LeaveRequests)
                .HasForeignKey(lr => lr.LeaveTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Approver relationship (Employee approves LeaveRequest)
            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.Approver)
                .WithMany()
                .HasForeignKey(lr => lr.ApproverId)
                .OnDelete(DeleteBehavior.Restrict);

            // -----------------------------
            // Notice Board
            // -----------------------------

            modelBuilder.Entity<Notice>()
                .HasOne(n => n.CreatedByEmployee)
                .WithMany(e => e.NoticesCreated)
                .HasForeignKey(n => n.CreatedByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NoticeTarget>()
                .HasOne(nt => nt.Notice)
                .WithMany(n => n.Targets)
                .HasForeignKey(nt => nt.NoticeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NoticeTarget>()
                .HasOne(nt => nt.Department)
                .WithMany()
                .HasForeignKey(nt => nt.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NoticeTarget>()
                .HasOne(nt => nt.Employee)
                .WithMany()
                .HasForeignKey(nt => nt.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NoticeRead>()
                .HasOne(nr => nr.Notice)
                .WithMany(n => n.Reads)
                .HasForeignKey(nr => nr.NoticeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NoticeRead>()
                .HasOne(nr => nr.Employee)
                .WithMany(e => e.NoticeReads)
                .HasForeignKey(nr => nr.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Prevent duplicate read entries (one read per notice per employee)
            modelBuilder.Entity<NoticeRead>()
                .HasIndex(nr => new { nr.NoticeId, nr.EmployeeId })
                .IsUnique();

            // -----------------------------
            // Recruitment (Application Frequency)
            // -----------------------------

            modelBuilder.Entity<JobPost>()
                .HasOne(jp => jp.Department)
                .WithMany(d => d.JobPosts)
                .HasForeignKey(jp => jp.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.Candidate)
                .WithMany(c => c.Applications)
                .HasForeignKey(ja => ja.CandidateId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.JobPost)
                .WithMany(jp => jp.Applications)
                .HasForeignKey(ja => ja.JobPostId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique Candidate Email
            modelBuilder.Entity<Candidate>()
                .HasIndex(c => c.Email)
                .IsUnique();

            // Optional rule: candidate can apply once per job post
            modelBuilder.Entity<JobApplication>()
                .HasIndex(ja => new { ja.CandidateId, ja.JobPostId })
                .IsUnique();

            // -----------------------------
            // Payroll
            // -----------------------------

            modelBuilder.Entity<Payslip>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Payslips)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payslip>()
                .HasOne(p => p.PayrollRun)
                .WithMany(pr => pr.Payslips)
                .HasForeignKey(p => p.PayrollRunId)
                .OnDelete(DeleteBehavior.Cascade);

            // One payroll run per month/year
            modelBuilder.Entity<PayrollRun>()
                .HasIndex(pr => new { pr.Month, pr.Year })
                .IsUnique();

            // One payslip per employee per payroll run
            modelBuilder.Entity<Payslip>()
                .HasIndex(p => new { p.PayrollRunId, p.EmployeeId })
                .IsUnique();
        }
    }

}
